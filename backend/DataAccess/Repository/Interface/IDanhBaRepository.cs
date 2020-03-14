using DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface IDanhBaRepository
    {
        Task<List<DanhBaDO>> GetDanhSachDanhBa(string maTaiKhoan);
        Task<int> ThemDanhBa(DanhBaDO danhBa);
        Task<int> SuaDanhBa(DanhBaDO danhBa);
        Task<int> XoaDanhBa(int id);
    }
}
