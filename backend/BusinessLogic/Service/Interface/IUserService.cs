using BusinessObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service.Interface
{
    public interface IUserService
    {
        Task<List<UserBO>> GetAllUsers();
        Task<UserBO> GetUserByUserName(string userName);
        Task<UserBO> GetThongTinTaiKhoanKhachHang(string maTaiKhoan);
        Task<UserBO> GetUserByUserNamePassword(string userName, string password);
        //Task<int> AddUser(UserBO user);
        Task<int> UpdateRefreshToken(string maTaiKhoan, string refreshToken);
        Task<UserBO> GetUserByTenDangNhap(string tenDangNhap);
        Task<UserBO> GetThongTinTaiKhoan(string maTaiKhoan);
        Task<UserBO> GetThongTinTaiKhoanAdmin(string maTaiKhoan);
        Task<UserBO> GetThongTinTaiKhoanBySoTaiKhoan(string soTaiKhoan);
        Task<string> GetRefreshTokenByMaTk(string maTaiKhoan);
        Task<List<UserBO>> TimKiemThongTinTaiKhoan(string key);
        Task<List<TaiKhoanNhanVienBO>> GetDanhSachTaiKhoanAdmin();
        Task<int> DoiMatKhau(string maTaiKhoan, string matKhauMoi);
        string GetPasswordByMaTk(string maTaiKhoan);
        Task<int> QuenMatKhau(string tenDangNhap, string email, string matKhauMoi);
        Task<int> UpdateSoDuSauKhiChuyenKhoanNoiBo(string taiKhoanGui, string taiKhoanNhan, int soTienGui);
        Task<int> ThemTaiKhoanDangNhap(TaiKhoanDangNhapBO taiKhoanDangNhap);
        Task<int> ThemThongTinTaiKhoanKhachHang(TaiKhoanKhachHangBO taiKhoanKhachHang);
        Task<int> ThemTaiKhoanNhanVien(TaiKhoanNhanVienBO taiKhoanNhanVien);
        Task<int> UpdateThongTinTaiKhoanKhachHang(TaiKhoanKhachHangBO taiKhoanKhachHang);
        Task<int> UpdateThongTinTaiKhoanNhanVien(TaiKhoanNhanVienBO taiKhoanNhanVien);
        Task<int> XoaTaiKhoan(string maTaiKhoan);
    }
}
