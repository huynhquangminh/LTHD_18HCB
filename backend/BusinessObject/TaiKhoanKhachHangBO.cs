using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObject
{
    public class TaiKhoanKhachHangBO
    {
        public int Id { get; set; }
        public string MaTk { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Image { get; set; }
        public string SoTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public int SoDu { get; set; }
    }
}
