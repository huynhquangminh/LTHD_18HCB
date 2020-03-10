using BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Interface
{
    public interface ITaiKhoanTietKiemService
    {
        Task<List<TaiKhoanTietKiemBO>> GetDanhSachTheoMaTaiKhoan(string maTaiKhoan);
    }
}
