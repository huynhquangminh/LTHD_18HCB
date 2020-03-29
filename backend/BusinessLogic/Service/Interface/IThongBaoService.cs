using BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Interface
{
    public interface IThongBaoService
    {
        Task<List<ThongBaoBO>> GetDanhSachTheoMaTaiKhoan(string maTaiKhoan);
        Task<int> Them(string maTaiKhoan, string noiDung);
        Task<int> Update(int id);
    }
}
