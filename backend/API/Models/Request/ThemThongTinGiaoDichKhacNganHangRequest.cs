using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class ThemThongTinGiaoDichKhacNganHangRequest
    {
        public string SoTKGui { get; set; }
        public string TenNganHangGui { get; set; }
        public string SoTKNhan { get; set; }
        public string TenNganHangNhan { get; set; }
        public int SoTien { get; set; }
        public string NoiDung { get; set; }
        public string NgayTao { get; set; }
        public string Signature { get; set; }
    }
}
