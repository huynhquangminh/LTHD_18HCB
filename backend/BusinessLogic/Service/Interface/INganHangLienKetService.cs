using BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Interface
{
    public interface INganHangLienKetService
    {
        Task<List<NganHangLienKetBO>> GetDanhSach();
        Task<int> Them(NganHangLienKetBO nganHangLienKet);
        Task<NganHangLienKetBO> GetNganHangLienKetByIdOrTenNganHang(int id, string tenNganHang);
        Task<int> ThemThongTinGiaoDichKhacNganhang(ThongTinGiaoDichLienNganHangBO thongTinGiaoDichLienNganHang);
        Task<List<ThongTinGiaoDichLienNganHangBO>> XemGiaoDichKhacNganHang(string soTaiKhoan);
    }
}
