using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class DangKyNhanVienRequest
    {
        public string TenDangNhap { get; set; }
        public string TenNhanVien { get; set; }
        public string Cmnd { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
    }
}
