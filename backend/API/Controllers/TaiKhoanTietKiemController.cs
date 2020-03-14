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
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanTietKiemController : ControllerBase
    {
        private IConfiguration _config;
        private readonly ITaiKhoanTietKiemService _taiKhoanTietKiemService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="taiKhoanTietKiemService"></param>
        public TaiKhoanTietKiemController(IConfiguration config, ITaiKhoanTietKiemService taiKhoanTietKiemService)
        {
            _config = config;
            _taiKhoanTietKiemService = taiKhoanTietKiemService;
        }

        /// <summary>
        /// Lấy danh sách tài khoản tiết kiệm theo mã tài khoản
        /// </summary>
        /// <param name="maTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetDanhSachTheoMaTaiKhoan")]
        public async Task<ActionResult<List<TaiKhoanTietKiemBO>>> GetDanhSachTheoMaTaiKhoan(string maTaiKhoan)
        {
            var result = await _taiKhoanTietKiemService.GetDanhSachTheoMaTaiKhoan(maTaiKhoan);
            return Ok(result);
        }
    }
}