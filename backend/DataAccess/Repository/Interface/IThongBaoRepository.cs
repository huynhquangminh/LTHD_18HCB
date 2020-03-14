using DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface IThongBaoRepository
    {
        Task<List<ThongBaoDO>> GetDanhSachTheoMaTaiKhoan(string maTaiKhoan);
    }
}
