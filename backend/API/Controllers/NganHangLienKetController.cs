using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Models.Request;
using API.Services;
using BusinessLogic.Service.Interface;
using BusinessObject;
using DidiSoft.Pgp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace API.Controllers
{
    /// <summary>
    /// NganHangLienKet api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NganHangLienKetController : ControllerBase
    {
        private IConfiguration _config;
        private readonly INganHangLienKetService _nganHangLienKetService;
        private readonly IUserService _userService;
        private readonly string publicStr = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDNdjzB5D42fbkMeM9GDIqyUfEf3rJNolSj9loyDiFmeBeiGt2ulBiOmOf0SKs3C+DO99VooDPC4AMqmrhEMT+NVVYacelIPu1MccTCS6x0ySZXny2JkSmpjHreQ5Q66SH+T+8D+9O4leNJek2Vtw8YWJuJhQPuZfaPfZaht1mxlQIDAQAB";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="nganHangLienKetService"></param>
        /// <param name="userService"></param>
        public NganHangLienKetController(IConfiguration config, INganHangLienKetService nganHangLienKetService, IUserService userService)
        {
            _config = config;
            _nganHangLienKetService = nganHangLienKetService;
            _userService = userService;
        }

        /// <summary>
        /// Lấy danh sách ngân hàng liên kết
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetDanhSach")]
        public async Task<ActionResult<List<NganHangLienKetBO>>> GetDanhSach()
        {
            var result = await _nganHangLienKetService.GetDanhSach();
            return Ok(result);
        }

        /// <summary>
        /// Lấy thông tin tài khoản theo số tài khoản
        /// </summary>
        /// <param name="soTaiKhoan"></param>
        /// <param name="timer"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Produces("application/json")]
        [Route("GetThongTinTaiKhoan")]
        public async Task<IActionResult> GetThongTinTaiKhoan(GetThongTinTaiKhoanLienKetNganHang request)
        {
            var secretKey = "nhom9";
            var text = $"{request.soTaiKhoan}{request.timer}{secretKey}";
            //var textHash = BCryptService.HashPassword(text);
            //var signStr = SignDataRsa(secretKey);
            //var checkSign = VerifySignRsa(secretKey, publicStr, signStr);
            var result = CheckHash(text, request.hashStr);

            if (result)
            {
                var user = _userService.GetThongTinTaiKhoanBySoTaiKhoan(request.soTaiKhoan);
                dynamic accountInfo = new ExpandoObject();
                accountInfo.maTk = user.Result.MaTk;
                accountInfo.soTaiKhoan = user.Result.SoTaiKhoan;
                accountInfo.tenTaiKhoan = user.Result.TenTaiKhoan;
                accountInfo.email = user.Result.Email;
                accountInfo.status = true;
                return Ok(accountInfo);
            }
            return Ok(new {mesError = "request false", status = false });
        }

        /// <summary>
        /// Thêm ngân hàng liên kết
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Route("ThemNganHangLienKet")]
        public async Task<ActionResult<int>> Them(ThemNganHangLienKetRequest request)
        {
            NganHangLienKetBO nganHangLienKet = new NganHangLienKetBO();
            nganHangLienKet.TenNganHang = request.TenNganHang;
            nganHangLienKet.PublicKey = request.PublicKey;
            nganHangLienKet.SecretKey = request.SecretKey;

            var result = await _nganHangLienKetService.Them(nganHangLienKet);
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách ngân hàng liên kết theo id hay tên ngân hàng
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tenNganHang"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("GetNganHangLienKetByIdOrTenNganHang")]
        public async Task<ActionResult<NganHangLienKetBO>> GetNganHangLienKetByIdOrTenNganHang(int id, string tenNganHang)
        {
            var result = await _nganHangLienKetService.GetNganHangLienKetByIdOrTenNganHang(id, tenNganHang);
            return Ok(result);
        }

        /// <summary>
        /// Lấy data rsa
        /// </summary>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("GetSignDataRSA")]
        public async Task<ActionResult<string>> GetSignDataRSA(string secretKey)
        {
            var result = SignDataRsa(secretKey);
            return Ok(result);
        }

        [HttpGet]
        [Produces("application/json")]
        [Route("GetHashString")]
        public async Task<ActionResult<string>> GetHashString(string hashString)
        {
            var result = BCrypt.Net.BCrypt.HashPassword(hashString);
            return Ok(result);
        }

        /// <summary>
        /// Thêm thông tin giao dịch khác ngân hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Produces("application/json")]
        [Route("GiaoDichKhacNganHang")]
        public async Task<IActionResult> GiaoDichKhacNganHang(ThemThongTinGiaoDichKhacNganHangRequest request)
        {
            //var nganHang = GetNganHangLienKetByIdOrTenNganHang(-1, request.TenNganHangGui);
            var nganHang = _nganHangLienKetService.GetNganHangLienKetByIdOrTenNganHang(-1, request.TenNganHangGui);
            var secretKey = nganHang.Result.SecretKey;
            var publicKey = nganHang.Result.PublicKey;

            var thongTinGiaoDichLienNganHangBO = new ThongTinGiaoDichLienNganHangBO();
            thongTinGiaoDichLienNganHangBO.NgayTao = request.NgayTao;
            thongTinGiaoDichLienNganHangBO.NoiDung = request.NoiDung;
            thongTinGiaoDichLienNganHangBO.SoTien = request.SoTien;
            thongTinGiaoDichLienNganHangBO.SoTKGui = request.SoTKGui;
            thongTinGiaoDichLienNganHangBO.SoTKNhan = request.SoTKNhan;
            thongTinGiaoDichLienNganHangBO.TenNganHangGui = request.TenNganHangGui;
            thongTinGiaoDichLienNganHangBO.TenNganHangNhan = request.TenNganHangNhan;

            if (secretKey == "" || secretKey == null || publicKey == "" || publicKey == null)
            {
                return Ok(new { mesError = "request false", status = false });
            }
            else
            {
                var verifySignRsa = VerifySignRsa(secretKey, publicKey, request.Signature);
                
                if (verifySignRsa)
                {
                    var result = _nganHangLienKetService.ThemThongTinGiaoDichKhacNganhang(thongTinGiaoDichLienNganHangBO);
                    var updateSoDu = _userService.UpdateSoDuGiaoDichKhacNganHang(request.SoTKNhan, request.SoTien, true);
                    return Ok(new { mesError = "request success", status = true });
                }
                else
                {
                    return Ok(new { mesError = "request false", status = false });
                }
            }
        }

        /// <summary>
        /// Thêm thông tin giao dịch khác ngân hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Produces("application/json")]
        [Route("LuuGiaoDichKhacNganHang")]
        public async Task<IActionResult> LuuGiaoDichKhacNganHang(ThemThongTinGiaoDichKhacNganHangRequest request)
        {

            var thongTinGiaoDichLienNganHangBO = new ThongTinGiaoDichLienNganHangBO();
            thongTinGiaoDichLienNganHangBO.NgayTao = request.NgayTao;
            thongTinGiaoDichLienNganHangBO.NoiDung = request.NoiDung;
            thongTinGiaoDichLienNganHangBO.SoTien = request.SoTien;
            thongTinGiaoDichLienNganHangBO.SoTKGui = request.SoTKGui;
            thongTinGiaoDichLienNganHangBO.SoTKNhan = request.SoTKNhan;
            thongTinGiaoDichLienNganHangBO.TenNganHangGui = request.TenNganHangGui;
            thongTinGiaoDichLienNganHangBO.TenNganHangNhan = request.TenNganHangNhan;

            var result = _nganHangLienKetService.ThemThongTinGiaoDichKhacNganhang(thongTinGiaoDichLienNganHangBO);
            var updateSoDu = _userService.UpdateSoDuGiaoDichKhacNganHang(request.SoTKGui, request.SoTien, false);
            return Ok(new { mesError = "request success", status = true });
        }

        [Authorize]
        [HttpPost]
        [Produces("application/json")]
        [Route("GiaoDichChuyenTienAdmin")]
        public async Task<IActionResult> GiaoDichChuyenTienAdmin(ThemThongTinGiaoDichKhacNganHangRequest request)
        {
            var thongTinGiaoDichLienNganHangBO = new ThongTinGiaoDichLienNganHangBO();
            thongTinGiaoDichLienNganHangBO.NgayTao = request.NgayTao;
            thongTinGiaoDichLienNganHangBO.NoiDung = request.NoiDung;
            thongTinGiaoDichLienNganHangBO.SoTien = request.SoTien;
            thongTinGiaoDichLienNganHangBO.SoTKGui = request.SoTKGui;
            thongTinGiaoDichLienNganHangBO.SoTKNhan = request.SoTKNhan;
            thongTinGiaoDichLienNganHangBO.TenNganHangGui = request.TenNganHangGui;
            thongTinGiaoDichLienNganHangBO.TenNganHangNhan = request.TenNganHangNhan;

            var result = _nganHangLienKetService.ThemThongTinGiaoDichKhacNganhang(thongTinGiaoDichLienNganHangBO);
            var updateSoDu = _userService.UpdateSoDuGiaoDichKhacNganHang(request.SoTKGui, request.SoTien, false);
            return Ok(result);
            
        }

        /// <summary>
        /// Xem thông tin giao dịch khác ngân hàng theo số tài khoản
        /// </summary>
        /// <param name="soTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("XemGiaoDichKhacNganHang")]
        public async Task<ActionResult<List<ThongTinGiaoDichLienNganHangBO>>> XemGiaoDichKhacNganHang(string soTaiKhoan)
        {
            var result = await _nganHangLienKetService.XemGiaoDichKhacNganHang(soTaiKhoan);
            return Ok(result);
        }

        /// <summary>
        /// Lấy tất cả giao dịch khác ngân hàng
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetAllGiaoDichKhacNganHang")]
        public async Task<ActionResult<List<ThongTinGiaoDichLienNganHangBO>>> GetAllGiaoDichKhacNganHang()
        {
            var result = await _nganHangLienKetService.GetAllGiaoDichKhacNganHang();
            return Ok(result);
        }

        /// <summary>
        /// Tìm kiếm thông tin giao dịch khác ngân hàng theo số tài khoản, tên ngân hàng
        /// </summary>
        /// <param name="soTaiKhoan"></param>
        /// <param name="tenNganHang"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("TimKiemGiaoDichKhacNganHang")]
        public async Task<ActionResult<List<ThongTinGiaoDichLienNganHangBO>>> TimKiemGiaoDichKhacNganHang(string soTaiKhoan, string tenNganHang)
        {
            var result = await _nganHangLienKetService.TimKiemGiaoDichKhacNganHang(soTaiKhoan, tenNganHang);
            return Ok(result);
        }

        [HttpDelete]
        [Produces("application/json")]
        [Route("XoaThongTinGiaoDichKhacNganHang")]
        public async Task<ActionResult<int>> XoaThongTinGiaoDichKhacNganHang(int id)
        {
            var result = await _nganHangLienKetService.XoaThongTinGiaoDichKhacNganHang(id);
            return Ok(result);
        }


        /// <summary>
        /// Lấy data PGP
        /// </summary>
        /// <param name="secretKey"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [Route("GetSignDataPGP")]
        public async Task<ActionResult<string>> GetSignDataPGP()
        {
            var result = signDataPgp();
            return Ok(result);
        }

        private bool CheckHash(string textValue, string hashValue)
        {
            return BCryptService.CheckPassword(textValue, hashValue);
        }

        private string SignDataRsa(string secretKey)
        {
            string privateKeyPem = Directory.GetCurrentDirectory().ToString() + @"\Services\fileKey\privateKey.pem";
            try
            {
                byte[] signedBytes;
                StreamReader readerStr = new StreamReader(privateKeyPem);
                PemReader pr = new PemReader(readerStr);
                AsymmetricCipherKeyPair KeyPair = (AsymmetricCipherKeyPair)pr.ReadObject();
                RSAParameters rsaParams = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)KeyPair.Private);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(rsaParams);
                var encoder = new UTF8Encoding();
                byte[] originalData = encoder.GetBytes(secretKey);
                signedBytes = rsa.SignData(originalData, CryptoConfig.MapNameToOID("SHA512"));
                return Convert.ToBase64String(signedBytes);
            } catch(Exception e)
            {
                return null;
            }
        }

        private bool VerifySignRsa(string secretKey, string publicKey, string signature) 
        {
            bool result = false;
            try
            {
                byte[] publicKeyBytes = Convert.FromBase64String(publicKey);
                AsymmetricKeyParameter asymmetricKeyParameter = PublicKeyFactory.CreateKey(publicKeyBytes);
                RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)asymmetricKeyParameter;
                RSAParameters rsaParameters = new RSAParameters();
                rsaParameters.Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned();
                rsaParameters.Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned();
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.ImportParameters(rsaParameters);

                var encoder = new UTF8Encoding();
                byte[] originalData = encoder.GetBytes(secretKey);
                byte[] signatureData = Convert.FromBase64String(signature);
                result = rsa.VerifyData(originalData, CryptoConfig.MapNameToOID("SHA512"), signatureData);

            }
            catch (Exception e)
            {
                return false;
            }
            return result;
        }

        private string signDataPgp()
        {
            PGPLib pgp = new PGPLib();
            try
            {
                string privateKeyPem = Directory.GetCurrentDirectory().ToString() + @"\Services\fileKey\privateKeyPGP.asc";
                string secretKeyFile = Directory.GetCurrentDirectory().ToString() + @"\Services\fileKey\secretKeyFile.txt";
                string signPGPFile = Directory.GetCurrentDirectory().ToString() + @"\Services\fileKey\signPGP.pgp";
                pgp.SignFile(secretKeyFile, privateKeyPem, "nhom9", signPGPFile, true);
                //var signText =  pgp.SignString("nhom9", privateKeyPem, "nhom9");
                string signText = System.IO.File.ReadAllText(Directory.GetCurrentDirectory().ToString() + @"\Services\fileKey\signPGP.pgp");
                return signText;
            } catch(Exception e)
            {
                return "";
            }

        }

    }
}