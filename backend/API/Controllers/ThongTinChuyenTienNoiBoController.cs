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
    }
}