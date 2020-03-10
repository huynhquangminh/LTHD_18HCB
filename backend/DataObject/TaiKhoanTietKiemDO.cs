using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
    public class TaiKhoanTietKiemDO
    {
        public int Id { get; set; }
        public string MaTk { get; set; }
        public string TenTaiKhoanTietKiem { get; set; }
        public DateTime NgayTao { get; set; }
        public decimal SoTienTietKiem { get; set; }
    }
}
