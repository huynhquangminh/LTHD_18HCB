using System;

namespace DataObject
{
    public class UserDO
    {
        public string Id { get; set; }
        public string MaTk { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Image { get; set; }
        public string SoTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public decimal SoDu { get; set; }
        public int IdLoaiTaiKhoan { get; set; }
        public string RefreshToken { get; set; }
    }
}
