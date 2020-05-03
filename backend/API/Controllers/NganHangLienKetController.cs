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

        /// <summary>
        /// Thêm thông tin giao dịch khác ngân hàng
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [Route("ThemThongTinGiaoDichKhacNganHang")]
        public async Task<IActionResult> ThemThongTinGiaoDichKhacNganHang(ThemThongTinGiaoDichKhacNganHangRequest request)
        {
            var nganHang = GetNganHangLienKetByIdOrTenNganHang(-1, request.TenNganHangGui);
            var secretKey = nganHang.Result.Value.SecretKey;
            var publicKey = nganHang.Result.Value.PublicKey;

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
                if(verifySignRsa)
                {
                    var result = _nganHangLienKetService.ThemThongTinGiaoDichKhacNganhang(thongTinGiaoDichLienNganHangBO);
                    return Ok(new { mesError = "request success", status = true });
                }
                else
                {
                    return Ok(new { mesError = "request false", status = false });
                }
            }
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

        private bool VerifySignRsa (string secretKey, string publicKey, string signature) 
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

    }
}