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
    /// DanhBa api
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DanhBaController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IDanhBaService _danhBaService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="config"></param>
        /// <param name="danhBaService"></param>
        public DanhBaController(IConfiguration config, IDanhBaService danhBaService)
        {
            _config = config;
            _danhBaService = danhBaService;
        }

        /// <summary>
        /// Lấy danh sách danh bạ theo mã tài khoản
        /// </summary>
        /// <param name="maTaiKhoan"></param>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        [Produces("application/json")]
        [Route("GetDSDanhBa")]
        public async Task<ActionResult<List<DanhBaBO>>> GetDSDanhBa(string maTaiKhoan)
        {
            var result = await _danhBaService.GetDanhSachDanhBa(maTaiKhoan);
            return Ok(result);
        }

        /// <summary>
        /// Thêm danh bạ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost]
        [Produces("application/json")]
        [Route("ThemDanhBa")]
        public async Task<ActionResult<int>> ThemDanhBa(DanhBaBO request)
        {
            return await _danhBaService.ThemDanhBa(request);
        }

        /// <summary>
        /// Sửa danh bạ
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPut]
        [Produces("application/json")]
        [Route("SuaDanhBa")]
        public async Task<ActionResult<int>> SuaDanhBa(DanhBaBO request)
        {
            return await _danhBaService.SuaDanhBa(request);
        }

        /// <summary>
        /// Xóa danh bạ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [HttpDelete]
        [Produces("application/json")]
        [Route("XoaDanhBa")]
        public async Task<ActionResult<int>> XoaDanhBa(int id)
        {
            return await _danhBaService.XoaDanhBa(id);
        }
    }
}