using DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface IThongTinChuyenTienNoiBoRepository
    {
        Task<int> ChuyenKhoanNoiBo(ThongTinChuyenTienNoiBoDO thongTinChuyenTienNoiBo);
        Task<List<ThongTinChuyenTienNoiBoDO>> GetDanhSachGiaoDich();
        Task<List<ThongTinChuyenTienNoiBoDO>> GetGiaoDichNhanTienNoiBo(string soTaiKhoan);
        Task<List<ThongTinChuyenTienNoiBoDO>> GetGiaoDichGuiTienNoiBo(string maTaiKhoan);
        Task<List<ThongTinChuyenTienNoiBoDO>> TimKiemGiaoDich(string key);
        Task<int> XoaGiaoDich(int id);
    }
}
