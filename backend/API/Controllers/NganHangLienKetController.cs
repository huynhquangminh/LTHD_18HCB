using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet]
        [Produces("application/json")]
        [Route("GetThongTinTaiKhoan")]
        public async Task<IActionResult> GetThongTinTaiKhoan(string soTaiKhoan, string timer)
        {
            var secretKey = "nhom9";
            var text = $"{soTaiKhoan}{timer}{secretKey}";
            var textHash = BCryptService.HashPassword(text);
            var result = CheckHash(text, textHash);

            if (result)
            {
                var user = _userService.GetThongTinTaiKhoanBySoTaiKhoan(soTaiKhoan);
                return Ok(new { user.Result, status = true });
            }

            return Ok(new {mesError = "request false", status = false });
        }

        private bool CheckHash(string textValue, string hashValue)
        {
            return BCryptService.CheckPassword(textValue, hashValue);
        }
    }
}