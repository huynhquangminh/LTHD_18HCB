using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
    public class TaiKhoanNhanVienDO
    {
        public int Id { get; set; }
        public string MaTk { get; set; }
        public string TenNhanVien { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Cmnd { get; set; }
        public string DiaChi { get; set; }
        public int IdLoaiTaiKhoan { get; set; }
    }
}
