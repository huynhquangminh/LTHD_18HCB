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
        public const string USER_INSERT = "sp_User_Insert";
        public const string USER_EDIT_REFRESHTOKEN = "sp_User_Edit_RefreshToken";
        public const string USER_DOIMATKHAU = "DoiMatKhau";
        public const string USER_GETPASSWORDBY_MATK = "GetPasswordByMaTk";
        public const string USER_QUENMATKHAU = "QuenMatKhauUser";
        public const string USER_GETBY_TENDANGNHAP = "GetUserByTenDangNhap";
        public const string USER_GETTHONGTINTAIKHOANKHACHHANG = "GetThongTinTaiKhoanKhachHang";
        public const string USER_GET_THONGTINTAIKHOAN = "GetThongTinTaiKhoan";
        public const string USER_GET_THONGTINTAIKHOAN_ADMIN = "GetThongTinTaiKhoanAdmin";
        public const string USER_GET_THONGTINTAIKHOAN_SOTAIKHOAN = "GetThongTinTaiKhoanBySTK";
        public const string USER_UPDATE_SODUSAUKHICHUYENKHOANNOIBO = "UpdateSoDuSauKhiChuyenKhoanNoiBo";
        public const string USER_TIMKIEM_THONGTINTAIKHOAN = "TimKiemThongTinTaiKhoan";

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

        // ThongTinChuyenTienNoiBo
        public const string THONGTINCHUYENTIENNOIBO_CHUYENKHOANNOIBO = "ChuyenKhoanNoiBo";
        public const string THONGTINCHUYENTIENNOIBO_GETGIAODICHNHANTIENNOIBO = "XemGiaoDichNhanTienNoiBo";
        public const string THONGTINCHUYENTIENNOIBO_GETGIAODICHGUITIENNOIBO = "XemGiaoDichGuiTienNoiBo";

        // NhacNo
        public const string NHACNO_GETDANHSACHNO = "GetDSNo";
        public const string NHACNO_GETDANHSACHNGUOINO = "GetDSNguoiNo";
        public const string NHACNO_THEM = "ThemNhacNo";
        public const string NHACNO_UPDATETRANGTHAI = "UpdateTrangThaiNhacNo";
    }
}
