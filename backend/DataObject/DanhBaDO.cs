using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
    public class DanhBaDO
    {
        public int Id { get; set; }
        public string MaTk { get; set; }
        public string TenGoiNho { get; set; }
        public string TenNganHang { get; set; }
        public string SoTaiKhoan { get; set; }

        public int idNganHangLienKet { get; set; }
    }
}
