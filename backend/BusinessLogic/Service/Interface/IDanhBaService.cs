using BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Interface
{
    public interface IDanhBaService
    {
        Task<List<DanhBaBO>> GetDanhSachDanhBa(string maTaiKhoan);
        Task<int> ThemDanhBa(DanhBaBO danhBa);
        Task<int> SuaDanhBa(DanhBaBO danhBa);
        Task<int> XoaDanhBa(int id);
    }
}
