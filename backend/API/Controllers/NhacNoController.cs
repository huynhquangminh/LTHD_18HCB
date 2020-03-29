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
    /// NhacNo api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class NhacNoController : ControllerBase
    {
        private IConfiguration _config;
        private readonly INhacNoService _nhacNoService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="nhacNoService"></param>
        public NhacNoController(IConfiguration config, INhacNoService nhacNoService)
        {
            _config = config;
            _nhacNoService = nhacNoService;
        }

        /// <summary>
        /// Get danh sách người nợ theo mã tài khoản
        /// </summary>
        /// <param name="maTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetDanhSachNguoiNo")]
        public async Task<ActionResult<List<NhacNoBO>>> GetDanhSachNguoiNo(string maTaiKhoan)
        {
            var result = await _nhacNoService.GetDanhSachNguoiNo(maTaiKhoan);
            return Ok(result);
        }

        /// <summary>
        /// Get danh sách nợ theo mã tài khoản
        /// </summary>
        /// <param name="maTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetDanhSachNo")]
        public async Task<ActionResult<List<NhacNoBO>>> GetDanhSachNo(string maTaiKhoan)
        {
            var result = await _nhacNoService.GetDanhSachNo(maTaiKhoan);
            return Ok(result);
        }

        /// <summary>
        /// Thêm nhắc nợ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Produces("application/json")]
        [Route("Them")]
        public async Task<ActionResult<int>> Them(NhacNo_ThemBO request)
        {
            return await _nhacNoService.Them(request);
        }

        /// <summary>
        /// Update trạng thái nhắc nợ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Produces("application/json")]
        [Route("UpdateTrangThai")]
        public async Task<ActionResult<int>> UpdateTrangThai(NhacNo_UpdateBO request)
        {
            return await _nhacNoService.UpdateTrangThai(request);
        }
    }
}