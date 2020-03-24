using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class UpdateSoDuRequest
    {
        public string TaiKhoanGui { get; set; }
        public string TaiKhoanNhan { get; set; }
        public int SoTienGui { get; set; }
    }
}
