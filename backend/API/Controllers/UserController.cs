using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Models.Request;
using API.Services;
using BusinessLogic.Service.Interface;
using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MimeKit;

namespace API.Controllers
{
    /// <summary>
    /// User Api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IUserService _userService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="userService"></param>
        public UserController(IConfiguration config, IUserService userService)
        {
            _config = config;
            _userService = userService;
        }

        /// <summary>
        /// Láy tất cả thông tin tài khoản người dùng
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetAllUsers")]
        public async Task<ActionResult<List<UserBO>>> GetAll()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }

        /// <summary>
        /// Tìm kiếm thông tin tài khoản
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("TimKiemThongTinTaiKhoan")]
        public async Task<ActionResult<List<UserBO>>> TimKiemThongTinTaiKhoan(string key)
        {
            var result = await _userService.TimKiemThongTinTaiKhoan(key);
            return Ok(result);
        }

        //[AllowAnonymous]
        //[HttpPost]
        //[Produces("application/json")]
        //[Route("Register")]
        //public async Task<ActionResult<int>> Register(UserBO user)
        //{
        //    var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
        //    user.UserId = Guid.NewGuid().ToString();
        //user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, salt);
        //    return await _userService.AddUser(user);
        //}

        /// <summary>
        /// Đăng nhập vào hệ thống
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        ///  <response code="200">Returns the user </response>
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginUserRequest request)
        {
            UserBO login = new UserBO();
            login.TenTaiKhoan = request.tenDangNhap;
            login.MatKhau = request.matKhau;

            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);

            if (user != null)
            {
                var stringToken = GetJSONWebToken(user);
                
                //var stringRefreshToken = GenerateRefreshToken();
                //user.RefreshToken = stringRefreshToken;
                //var result = _userService.EditUserRefreshToken(user.UserName, user.RefreshToken);
                response = Ok(new { user, token = stringToken
                    //refreshToken = stringRefreshToken 
                });
            }

            return response;
        }

        /// <summary>
        /// Lấy thông tin tài khoản theo mã tài khoản
        /// </summary>
        /// <param name="maTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("ThongTinTaiKhoan")]
        public async Task<ActionResult<UserBO>> GetThongTinTaiKhoan(string maTaiKhoan)
        {
            var result = _userService.GetThongTinTaiKhoan(maTaiKhoan);
            return await result;
        }

        /// <summary>
        /// Lấy danh sách tài khoản admin
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetDanhSachTaiKhoanAdmin")]
        public async Task<ActionResult<List<TaiKhoanNhanVienBO>>> GetDanhSachTaiKhoanAdmin()
        {
            var result = _userService.GetDanhSachTaiKhoanAdmin();
            return await result;
        }

        /// <summary>
        /// Đổi mật khẩu
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Produces("application/json")]
        [Route("DoiMatKhau")]
        public async Task<ActionResult<int>> DoiMatKhau(DoiMatKhauRequest request)
        {
            int result = 0;
            string hashPassword = _userService.GetPasswordByMaTk(request.maTaiKhoan);
            if (hashPassword != null)
            {
                bool checkPassword = BCryptService.CheckPassword(request.matKhau, hashPassword);

                if (checkPassword == true)
                {
                    string newPassword = BCryptService.HashPassword(request.matKhauMoi);
                    result = await _userService.DoiMatKhau(request.maTaiKhoan, newPassword);
                }
            }
            return  result;
        }

        /// <summary>
        /// Gửi mã xác nhận qua email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [Route("SendMailOTP")]
        public async Task<IActionResult> SendMailOTP(string email)
        {
            // Generate OTP
            var otp = SendMailService.GenerateOTP();

            var subject = "Xác nhận quên mật khẩu";
            StringBuilder body = new StringBuilder();
            body.AppendFormat("Mã xác nhận của bạn là: {0}", otp);

            try
            {
                var message = SendMailService.InitEmailMessage(email, subject, body.ToString());
                SendMailService.SendMail(message);
                return Ok(otp);
            } catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Quên mật khẩu
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [Route("QuenMatKhau")]
        public async Task<IActionResult> QuenMatKhau(QuenMatKhauRequest request)
        {
            int result = 0;
            string newPassword = SendMailService.GenerateString();
            string newHashPassword = BCryptService.HashPassword(newPassword);
            result = await _userService.QuenMatKhau(request.tenDangNhap, request.email, newHashPassword);

            if (result == 1)
            {
                var subject = "Xác nhận quên mật khẩu";
                StringBuilder body = new StringBuilder();
                body.AppendFormat("Mật khẩu mới của bạn là: {0}", newPassword);

                try
                {
                    var message = SendMailService.InitEmailMessage(request.email, subject, body.ToString());
                    SendMailService.SendMail(message);
                    return Ok(result);
                }
                catch (Exception ex)
                {
                    return StatusCode(500);
                }
            }

            return NotFound();
        }

        /// <summary>
        /// Lấy thông tin tài khoản theo số tài khoản
        /// </summary>
        /// <param name="soTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetThongTinTaiKhoanBySoTaiKhoan")]
        public async Task<ActionResult<UserBO>> GetThongTinTaiKhoanBySoTaiKhoan(string soTaiKhoan)
        {
            var result = _userService.GetThongTinTaiKhoanBySoTaiKhoan(soTaiKhoan);
            return await result;
        }

        /// <summary>
        /// Cập nhật số dư sau khi chuyển khoản nội bộ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Produces("application/json")]
        [Route("UpdateSoDuSauKhiChuyenKhoanNoiBo")]
        public async Task<ActionResult<int>> UpdateSoDuSauKhiChuyenKhoanNoiBo(UpdateSoDuRequest request)
        {
            var result = _userService.UpdateSoDuSauKhiChuyenKhoanNoiBo(request.TaiKhoanGui, request.TaiKhoanNhan, request.SoTienGui);
            return await result;
        }

        /// <summary>
        /// Đăng ký tài khoản khách hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [Route("DangKyTaiKhoanKhachHang")]
        public async Task<ActionResult<int>> DangKyTaiKhoanKhachHang(DangKyRequest request)
        {
            var result = 0;

            string maTaiKhoan = GenerateMaTaiKhoan(request.Sdt);

            string password = SendMailService.GenerateString();
            string hashPassword = BCryptService.HashPassword(password);
            string soTaiKhoan = GenerateSoTaiKhoan(request.Sdt);

            TaiKhoanDangNhapBO taiKhoanDangNhap = new TaiKhoanDangNhapBO();
            taiKhoanDangNhap.MaTaiKhoan = maTaiKhoan;
            taiKhoanDangNhap.TenDangNhap = request.TenDangNhap;
            taiKhoanDangNhap.MatKhau = hashPassword;
            taiKhoanDangNhap.IdLoaiTaiKhoan = 1;

            TaiKhoanKhachHangBO taiKhoanKhachHang = new TaiKhoanKhachHangBO();
            taiKhoanKhachHang.MaTk = maTaiKhoan;
            taiKhoanKhachHang.Sdt = request.Sdt;
            taiKhoanKhachHang.Email = request.Email;
            taiKhoanKhachHang.SoTaiKhoan = soTaiKhoan;
            taiKhoanKhachHang.TenTaiKhoan = request.HoTen;
            taiKhoanKhachHang.SoDu = 0;

            var themTaiKhoanResult = _userService.ThemTaiKhoanDangNhap(taiKhoanDangNhap);
            
            if (themTaiKhoanResult.Result == 1)
            {
                // Send mail after create success
                var subject = "Đăng ký tài khoản";
                StringBuilder body = new StringBuilder();
                body.AppendFormat("Mật khẩu của bạn là: {0}", password);
                var message = SendMailService.InitEmailMessage(request.Email, subject, body.ToString());
                SendMailService.SendMail(message);

                result = _userService.ThemThongTinTaiKhoanKhachHang(taiKhoanKhachHang).Result;
                return result;

            } else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Đăng ký tài khoản nhân viên
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        [Route("DangKyTaiKhoanNhanVien")]
        public async Task<ActionResult<int>> DangKyTaiKhoanNhanVien(DangKyNhanVienRequest request)
        {
            var result = 0;

            string maTaiKhoan = GenerateMaTaiKhoanNhanVien(request.Sdt);

            string password = SendMailService.GenerateString();
            string hashPassword = BCryptService.HashPassword(password);

            TaiKhoanDangNhapBO taiKhoanDangNhap = new TaiKhoanDangNhapBO();
            taiKhoanDangNhap.MaTaiKhoan = maTaiKhoan;
            taiKhoanDangNhap.TenDangNhap = request.TenDangNhap;
            taiKhoanDangNhap.MatKhau = hashPassword;
            taiKhoanDangNhap.IdLoaiTaiKhoan = 2;

            TaiKhoanNhanVienBO taiKhoanNhanVien = new TaiKhoanNhanVienBO();
            taiKhoanNhanVien.MaTk = maTaiKhoan;
            taiKhoanNhanVien.TenNhanVien = request.TenNhanVien;
            taiKhoanNhanVien.Cmnd = request.Cmnd;
            taiKhoanNhanVien.Sdt = request.Sdt;
            taiKhoanNhanVien.Email = request.Email;
            taiKhoanNhanVien.DiaChi = request.DiaChi;

            var themTaiKhoanResult = _userService.ThemTaiKhoanDangNhap(taiKhoanDangNhap);

            if (themTaiKhoanResult.Result == 1)
            {
                // Send mail after create success
                var subject = "Đăng ký tài khoản nhân viên";
                StringBuilder body = new StringBuilder();
                body.AppendFormat("Mật khẩu của bạn là: {0}", password);
                var message = SendMailService.InitEmailMessage(request.Email, subject, body.ToString());
                SendMailService.SendMail(message);

                result = _userService.ThemTaiKhoanNhanVien(taiKhoanNhanVien).Result;
                return result;

            }
            else
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Cập nhật thông tin tài khoản khách hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Produces("application/json")]
        [Route("UpdateThongTinTaiKhoanKhachHang")]
        public async Task<ActionResult<int>> UpdateThongTinTaiKhoanKhachHang(UpdateThongTinTaiKhoanKhachHangRequest request)
        {
            var taiKhoanKhachHang = new TaiKhoanKhachHangBO();
            taiKhoanKhachHang.Id = request.Id;
            taiKhoanKhachHang.Email = request.Email;
            taiKhoanKhachHang.Sdt = request.Sdt;

            var result = _userService.UpdateThongTinTaiKhoanKhachHang(taiKhoanKhachHang);
            return await result;
        }

        /// <summary>
        /// Cập nhật thông tin tài khoản nhân viên
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Produces("application/json")]
        [Route("UpdateThongTinTaiKhoanNhanVien")]
        public async Task<ActionResult<int>> UpdateThongTinTaiKhoanNhanVien(UpdateThongTinTaiKhoanNhanVienRequest request)
        {
            var taiKhoanNhanVien = new TaiKhoanNhanVienBO();
            taiKhoanNhanVien.Id = request.Id;
            taiKhoanNhanVien.TenNhanVien = request.TenNv;
            taiKhoanNhanVien.Cmnd = request.Cmnd;
            taiKhoanNhanVien.Email = request.Email;
            taiKhoanNhanVien.Sdt = request.Sdt;

            var result = _userService.UpdateThongTinTaiKhoanNhanVien(taiKhoanNhanVien);
            return await result;
        }

        /// <summary>
        /// Xóa tài khoản theo mã tài khoản
        /// </summary>
        /// <param name="maTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        [Produces("application/json")]
        [Route("XoaTaiKhoan")]
        public async Task<ActionResult<int>> XoaTaiKhoan(string maTaiKhoan)
        {
            var result = _userService.XoaTaiKhoan(maTaiKhoan);
            return await result;
        }

        //[HttpPost]
        //[Produces("application/json")]
        //[Route("RefreshToken")]
        //public async Task<IActionResult> Refresh(string token, string refreshToken)
        //{
        //    var princial = GetPrincipalFromExpiredToken(token);
        //    var userName = princial.Claims.ToList()[0].Value;
        //    var user = _userService.GetUserByUserName(userName).Result;

        //    // Check current request token of user
        //    if (user == null || user.RefreshToken != refreshToken)
        //    {
        //        return BadRequest();
        //    }

        //    var newJwtToken = GenerateJSONWebToken(user);
        //    var newRefreshToken = GenerateRefreshToken();

        //    var result = _userService.EditUserRefreshToken(userName, refreshToken);

        //    return new ObjectResult(new
        //    {
        //        token = newJwtToken,
        //        refreshToken = newRefreshToken
        //    });
        //}

        //[Authorize]
        //[HttpPost]
        //[Produces("application/json")]
        //[Route("RevokeToken")]
        //public async Task<IActionResult> Revoke()
        //{
        //    var userName = User.Claims.ToList()[0].Value;

        //    var user = _userService.GetUserByUserName(userName).Result;
        //    if (user == null) return BadRequest();

        //    user.RefreshToken = null;
        //    var result = _userService.EditUserRefreshToken(userName, null);
        //    return NoContent();
        //}

        private UserBO AuthenticateUser(UserBO login)
        {
            UserBO user = null;
            UserBO userAdmin = null;
            UserBO userKhachHang = null;
            user = _userService.GetUserByTenDangNhap(login.TenTaiKhoan).Result;

            if (user != null)
            {
                bool validPassword = BCryptService.CheckPassword(login.MatKhau, user.MatKhau);

                if (validPassword)
                {
                    if (user.IdLoaiTaiKhoan == 1)
                    {
                        userKhachHang = _userService.GetThongTinTaiKhoanKhachHang(user.MaTk).Result;
                        return userKhachHang;
                    } 
                    else
                    {
                        userAdmin = _userService.GetThongTinTaiKhoanAdmin(user.MaTk).Result;
                        return userAdmin;
                    }
                }
            }

            return null;
        }

        private string GetJSONWebToken(UserBO userInfo)
        {
            var claims = new[]
            {
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, userInfo.TenTaiKhoan),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, userInfo.MaTk)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var encodeToken = TokenService.GenerateJSONToken(claims);
            return encodeToken;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"])),
                ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }

        private string GenerateMaTaiKhoan(string soDienThoai)
        {
            var autoGen = AutoGenerateNumber(3);
            string maTaiKhoan = $"tk{soDienThoai.Substring(soDienThoai.Length - 3)}{autoGen}";
            
            return maTaiKhoan;
        }

        private string GenerateMaTaiKhoanNhanVien(string soDienThoai)
        {
            var autoGen = AutoGenerateNumber(3);
            string maTaiKhoan = $"nv{soDienThoai.Substring(soDienThoai.Length - 3)}{autoGen}";

            return maTaiKhoan;
        }

        private string GenerateSoTaiKhoan(string soDienThoai)
        {
            var autoGen = AutoGenerateNumber(3);
            string soTaiKhoan = $"{soDienThoai.Substring(soDienThoai.Length - 4)}{soDienThoai.Substring(0, 4)}{autoGen}";

            return soTaiKhoan;
        }

        private string AutoGenerateNumber(int count)
        {
            const string chars = "0123456789";
            var random = new Random();
            var autoGen = new string(Enumerable.Repeat(chars, count)
              .Select(s => s[random.Next(s.Length)]).ToArray());

            return autoGen;
        }
    }
}