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

        //[Authorize]
        //[HttpGet]
        //[Produces("application/json")]
        //[Route("GetAllUsers")]
        //public async Task<ActionResult<List<UserBO>>> GetAll()
        //{
        //    var result = await _userService.GetAllUsers();
        //    return Ok(result);
        //}

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
            user = _userService.GetUserByTenDangNhap(login.TenTaiKhoan).Result;
            bool validPassword = BCryptService.CheckPassword(login.MatKhau, user.MatKhau);

            if (validPassword)
            {
                return user;
            }

            return null;
        }

        private string GetJSONWebToken(UserBO userInfo)
        {
            var claims = new[]
            {
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, userInfo.TenTaiKhoan),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, userInfo.Id)
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
    }
}