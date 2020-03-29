using DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface INhacNoRepository
    {
        Task<List<NhacNoDO>> GetDanhSachNo(string maTaiKhoan);
        Task<List<NhacNoDO>> GetDanhSachNguoiNo(string maTaiKhoan);
        Task<int> Them(NhacNo_ThemDO nhacNo);
        Task<int> UpdateTrangThai(NhacNo_UpdateDO nhacNo);
    }
}
