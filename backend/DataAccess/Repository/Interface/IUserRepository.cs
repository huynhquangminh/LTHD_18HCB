using DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interface
{
    public interface IUserRepository
    {
        Task<List<UserDO>> GetAllUser();

        Task<UserDO> GetUserByUserName(string userName);
        Task<UserDO> GetThongTinTaiKhoanKhachHang(string maTaiKhoan);
        Task<UserDO> GetUserByUserNamePassword(string userName, string password);
        Task<int> EditUserRefreshToken(string userName, string refreshToken);
        Task<UserDO> GetUserByTenDangNhap(string tenDangNhap);
        Task<UserDO> GetThongTinTaiKhoan(string maTaiKhoan);
        Task<UserDO> GetThongTinTaiKhoanAdmin(string maTaiKhoan);
        Task<UserDO> GetThongTinTaiKhoanBySoTaiKhoan(string soTaiKhoan);
        Task<List<UserDO>> TimKiemThongTinTaiKhoan(string key);
        Task<int> DoiMatKhau(string maTaiKhoan, string matKhauMoi);
        string GetPasswordByMaTk(string maTaiKhoan);
        Task<int> QuenMatKhau(string tenDangNhap, string email, string matKhauMoi);
        Task<int> UpdateSoDuSauKhiChuyenKhoanNoiBo(string taiKhoanGui, string taiKhoanNhan, int soTienGui);
        Task<int> ThemTaiKhoanDangNhap(TaiKhoanDangNhapDO taiKhoanDangNhap);
        Task<int> ThemThongTinTaiKhoanKhachHang(TaiKhoanKhachHangDO taiKhoanKhachHang);
    }
}
