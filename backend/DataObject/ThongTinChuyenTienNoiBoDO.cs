using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
    public class ThongTinChuyenTienNoiBoDO
    {
        public int? Id { get; set; }
        public string MaTk { get; set; }
        public string NgayGd { get; set; }
        public string StkGui { get; set; }
        public string StkNhan { get; set; }
        public int SoTienGui { get; set; }
        public string NoiDung { get; set; }
        public bool LoaiTraPhi { get; set; }
        public bool? TrangThaiChuyenTien { get; set; }
    }
}
