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
    /// ThongBao api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ThongBaoController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IThongBaoService _thongBaoService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="thongBaoService"></param>
        public ThongBaoController(IConfiguration config, IThongBaoService thongBaoService)
        {
            _config = config;
            _thongBaoService = thongBaoService;
        }

        /// <summary>
        /// Lấy danh sách thông báo theo mã tài khoản
        /// </summary>
        /// <param name="maTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetDSThongBao")]
        public async Task<ActionResult<List<ThongBaoBO>>> GetDanhSachTheoMaTaiKhoan(string maTaiKhoan)
        {
            var result = await _thongBaoService.GetDanhSachTheoMaTaiKhoan(maTaiKhoan);
            return Ok(result);
        }
    }
}