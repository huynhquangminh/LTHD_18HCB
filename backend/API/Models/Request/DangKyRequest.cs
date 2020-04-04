using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class DangKyRequest
    {
        public string TenDangNhap { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
    }
}
