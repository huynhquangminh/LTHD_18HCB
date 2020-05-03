using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObject
{
    public class NganHangLienKetBO
    {
        public int Id { get; set; }
        public string TenNganHang { get; set; }
        public string SecretKey { get; set; }
        public string PublicKey { get; set; }
    }
}
