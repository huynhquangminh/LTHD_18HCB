using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Service.Interface;
using BusinessObject;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace API.Controllers
{
    /// <summary>
    /// ThongTinChuyenTienNoiBo api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinChuyenTienNoiBoController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IThongTinChuyenTienNoiBoService _thongTinChuyenTienNoiBoService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="thongTinChuyenTienNoiBoService"></param>
        public ThongTinChuyenTienNoiBoController(IConfiguration config, IThongTinChuyenTienNoiBoService thongTinChuyenTienNoiBoService)
        {
            _config = config;
            _thongTinChuyenTienNoiBoService = thongTinChuyenTienNoiBoService;
        }

        /// <summary>
        /// Chuyển khoản nội bộ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Produces("application/json")]
        [Route("ChuyenKhoanNoiBo")]
        public async Task<ActionResult<int>> ChuyenKhoanNoiBo(ThongTinChuyenTienNoiBoBO request)
        {
            var result = await _thongTinChuyenTienNoiBoService.ChuyenKhoanNoiBo(request);
            return Ok(result);
        }

        /// <summary>
        /// Lấy thông tin giao dịch gửi tiền nội bộ theo mã tài khoản
        /// </summary>
        /// <param name="maTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetGiaoDichGuiTienNoiBo")]
        public async Task<ActionResult<List<ThongTinChuyenTienNoiBoBO>>> GetGiaoDichGuiTienNoiBo(string soTaiKhoan)
        {
            var result = await _thongTinChuyenTienNoiBoService.GetGiaoDichGuiTienNoiBo(soTaiKhoan);
            return Ok(result);
        }

        /// <summary>
        /// Lấy thông tin giao dịch nhận tiền nội bộ theo số tài khoản
        /// </summary>
        /// <param name="soTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetGiaoDichNhanTienNoiBo")]
        public async Task<ActionResult<List<ThongTinChuyenTienNoiBoBO>>> GetGiaoDichNhanTienNoiBo(string soTaiKhoan)
        {
            var result = await _thongTinChuyenTienNoiBoService.GetGiaoDichNhanTienNoiBo(soTaiKhoan);
            return Ok(result);
        }
    }
}