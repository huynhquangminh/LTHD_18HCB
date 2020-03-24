using BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Interface
{
    public interface IThongTinChuyenTienNoiBoService
    {
        Task<int> ChuyenKhoanNoiBo(ThongTinChuyenTienNoiBoBO danhBa);
        Task<List<ThongTinChuyenTienNoiBoBO>> GetGiaoDichNhanTienNoiBo(string soTaiKhoan);
        Task<List<ThongTinChuyenTienNoiBoBO>> GetGiaoDichGuiTienNoiBo(string maTaiKhoan);
    }
}
