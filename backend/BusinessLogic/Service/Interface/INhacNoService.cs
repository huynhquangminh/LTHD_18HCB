using BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Interface
{
    public interface INhacNoService
    {
        Task<List<NhacNoBO>> GetDanhSachNo(string maTaiKhoan);
        Task<List<NhacNoBO>> GetDanhSachNguoiNo(string maTaiKhoan);
        Task<int> Them(NhacNo_ThemBO nhacNo);
        Task<int> UpdateTrangThai(NhacNo_UpdateBO nhacNo);
    }
}
