using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    /// <summary>
    /// 
    /// </summary>
    public class ThemNganHangLienKetRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public string TenNganHang { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PublicKey { get; set; }
    }
}
