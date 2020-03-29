using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObject
{
    public class NhacNoBO
    {
        public int Id { get; set; }
        public string MaTkTao { get; set; }
        public string MaTkNo { get; set; }
        public int SoTienNo { get; set; }
        public string NoiDungNhacNo { get; set; }
        public DateTime NgayTao { get; set; }
        public string NoiDungHuyNhacNo { get; set; }
        public int TrangThai { get; set; }
        public string TenTaiKhoan { get; set; }
        public string SoTaiKhoan { get; set; }
        public string Email { get; set; }
    }
}
