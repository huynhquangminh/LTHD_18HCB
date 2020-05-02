using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.Request;
using API.Services;
using BusinessLogic.Service.Interface;
using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
            var textHash = BCryptService.HashPassword(text);
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

        private bool CheckHash(string textValue, string hashValue)
        {
            return BCryptService.CheckPassword(textValue, hashValue);
        }
    }
}