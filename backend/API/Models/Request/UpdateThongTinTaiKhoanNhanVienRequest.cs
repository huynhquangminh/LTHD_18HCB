﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.Request
{
    public class UpdateThongTinTaiKhoanNhanVienRequest
    {
        public int Id { get; set; }
        public string TenNv { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Cmnd { get; set; }
    }
}
