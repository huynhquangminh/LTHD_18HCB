using System;
using System.Collections.Generic;
using System.Text;

namespace DataObject
{
    public class NganHangLienKetDO
    {
        public int Id { get; set; }
        public string TenNganHang { get; set; }
        public string SecretKey { get; set; }
        public string PublicKey { get; set; }
    }
}
