using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateSoDuKhacNganHangRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string SoTaiKhoan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SoTien { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool LoaiGiaoDich { get; set; }
    }
}
