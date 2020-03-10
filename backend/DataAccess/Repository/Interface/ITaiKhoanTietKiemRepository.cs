using DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface ITaiKhoanTietKiemRepository
    {
        Task<List<TaiKhoanTietKiemDO>> GetDanhSachTheoMaTaiKhoan(string maTaiKhoan);
    }
}
