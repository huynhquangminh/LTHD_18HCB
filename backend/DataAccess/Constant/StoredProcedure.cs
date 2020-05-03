using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Constant
{
    public static class StoredProcedure
    {
        // User
        public const string USER_GETALL = "GetAllUser";
        public const string USER_GETBY_USERNAME = "sp_User_GetBy_UserName";
        public const string USER_GETBY_USERNAME_PASSWORD = "sp_User_GetBy_UserName_Password";
        public const string USER_GET_REFRESHTOKEN_BYMATK = "GetRefreshTokenByMatk";
        public const string USER_INSERT = "sp_User_Insert";
        public const string USER_DOIMATKHAU = "DoiMatKhau";
        public const string USER_GETPASSWORDBY_MATK = "GetPasswordByMaTk";
        public const string USER_QUENMATKHAU = "QuenMatKhauUser";
        public const string USER_GETBY_TENDANGNHAP = "GetUserByTenDangNhap";
        public const string USER_GETTHONGTINTAIKHOANKHACHHANG = "GetThongTinTaiKhoanKhachHang";
        public const string USER_GET_THONGTINTAIKHOAN = "GetThongTinTaiKhoan";
        public const string USER_GET_THONGTINTAIKHOAN_ADMIN = "GetThongTinTaiKhoanAdmin";
        public const string USER_GET_THONGTINTAIKHOAN_SOTAIKHOAN = "GetThongTinTaiKhoanBySTK";
        public const string USER_GETDANHSACHTAIKHOANADMIN = "GetDanhSachTaiKhoanAdmin";
        public const string USER_UPDATE_SODUSAUKHICHUYENKHOANNOIBO = "UpdateSoDuSauKhiChuyenKhoanNoiBo";
        public const string USER_UPDATE_SODUGIAODICHKHACNGANHANG = "UpdateSoDuGiaoDichKhacNganHang";
        public const string USER_TIMKIEM_THONGTINTAIKHOAN = "TimKiemThongTinTaiKhoan";
        public const string USER_THEM_TAIKHOANDANGNHAP = "ThemTaiKhoanDangNhap";
        public const string USER_THEM_THONGTINTAIKHOANKHACHHANG = "ThemThongTinTaiKhoanKhachHang";
        public const string USER_THEM_THONGTINTAIKHOANNHANVIEN = "ThemTaiKhoanNhanVien";
        public const string USER_XOA_TAIKHOAN = "XoaTaiKhoan";
        public const string USER_UPDATE_THONGTINTAIKHOANKHACHHANG = "UpdateThongTinTaiKhoanKhachHang";
        public const string USER_UPDATE_THONGTINTAIKHOANNHANVIEN = "UpdateThongTinTaiKhoanNhanVien";
        public const string USER_UPDATE_REFRESHTOKEN = "UpdateRefreshToken";

        // TaiKhoanTietKiem
        public const string TAIKHOANTIETKIEM_GET_BY_MATAIKHOAN = "GetDsTaiKhoanTietKiem";

        // DanhBa
        public const string DANHBA_GETDANHSACH = "GetDSDanhBa";
        public const string DANHBA_THEM = "ThemDanhBa";
        public const string DANHBA_SUA = "SuaDanhBa";
        public const string DANHBA_XOA = "XoaDanhBa";

        // ThongBao
        public const string THONGBAO_GETDANHSACH = "GetDSThongBao";
        public const string THONGBAO_THEM = "ThemThongBao";
        public const string THONGBAO_UPDATE = "UpdateThongBao";

        // NganHangLienKet
        public const string NGANHANGLIENKET_GETALL = "GetDSNganHangLienKet";
        public const string NGANHANGLIENKET_THEM = "ThemNganHangLienKet";
        public const string NGANHANGLIENKET_GETBYID_TENNGANHANG = "GetNganHangLienKetByIdOrTenNganHang";
        public const string NGANHANGLIENKET_THEMTHONGTINGIAODICHKHACNGANHANG = "ThemThongTinGiaoDichKhacNganHang";

        // ThongTinChuyenTienNoiBo
        public const string THONGTINCHUYENTIENNOIBO_CHUYENKHOANNOIBO = "ChuyenKhoanNoiBo";
        public const string THONGTINCHUYENTIENNOIBO_GETDANHSACHGIAODICH = "GetDanhSachGiaoDich";
        public const string THONGTINCHUYENTIENNOIBO_TIMKIEMGIAODICH = "TimKiemGiaoDich";
        public const string THONGTINCHUYENTIENNOIBO_GETGIAODICHNHANTIENNOIBO = "XemGiaoDichNhanTienNoiBo";
        public const string THONGTINCHUYENTIENNOIBO_GETGIAODICHGUITIENNOIBO = "XemGiaoDichGuiTienNoiBo";
        public const string THONGTINCHUYENTIENNOIBO_XOA_GIAODICH = "XoaGiaoDich";

        // NhacNo
        public const string NHACNO_GETDANHSACHNO = "GetDSNo";
        public const string NHACNO_GETDANHSACHNGUOINO = "GetDSNguoiNo";
        public const string NHACNO_THEM = "ThemNhacNo";
        public const string NHACNO_UPDATETRANGTHAI = "UpdateTrangThaiNhacNo";
    }
}
