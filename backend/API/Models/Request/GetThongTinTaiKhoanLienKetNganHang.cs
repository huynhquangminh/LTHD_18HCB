using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class GetThongTinTaiKhoanLienKetNganHang
    {
        public string soTaiKhoan { get; set; }
        public string timer { get; set; }
        public string hashStr { get; set; }
    }
}
