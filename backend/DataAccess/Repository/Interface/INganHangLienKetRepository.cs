using DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.Interface
{
    public interface INganHangLienKetRepository
    {
        Task<List<NganHangLienKetDO>> GetDanhSach();
        Task<int> Them(NganHangLienKetDO nganHangLienKet);
        Task<NganHangLienKetDO> GetNganHangLienKetByIdOrTenNganHang(int id, string tenNganHang);
        Task<int> ThemThongTinGiaoDichKhacNganhang(ThongTinGiaoDichLienNganHangDO thongTinGiaoDichLienNganHang);
        Task<List<ThongTinGiaoDichLienNganHangDO>> XemGiaoDichKhacNganHang(string soTaiKhoan);
        Task<List<ThongTinGiaoDichLienNganHangDO>> GetAllGiaoDichKhacNganHang();
        Task<List<ThongTinGiaoDichLienNganHangDO>> TimKiemGiaoDichKhacNganHang(string soTaiKhoan, string tenNganHang);
        Task<int> XoaThongTinGiaoDichKhacNganHang(int id);
    }
}
