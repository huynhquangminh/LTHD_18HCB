using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Constant
{
    public static class StoredProcedure
    {
        // User
        public const string USER_GETALL = "sp_User_GetAll";
        public const string USER_GETBY_USERNAME = "sp_User_GetBy_UserName";
        public const string USER_GETBY_USERNAME_PASSWORD = "sp_User_GetBy_UserName_Password";
        public const string USER_INSERT = "sp_User_Insert";
        public const string USER_EDIT_REFRESHTOKEN = "EditUserRefreshToken";
        public const string USER_DOIMATKHAU = "DoiMatKhau";
        public const string USER_GETPASSWORDBY_MATK = "GetPasswordByMaTk";
        public const string USER_QUENMATKHAU = "QuenMatKhauUser";
        public const string USER_GETBY_TENDANGNHAP = "GetUserByTenDangNhap_v2";
        public const string USER_GETBY_MATAIKHOAN = "GetUserByMaTaiKhoan";
        public const string USER_GET_THONGTINTAIKHOAN = "GetThongTinTaiKhoan";
        public const string USER_GET_THONGTINTAIKHOAN_SOTAIKHOAN = "GetThongTinTaiKhoanBySTK";
        public const string USER_UPDATE_SODUSAUKHICHUYENKHOANNOIBO = "UpdateSoDuSauKhiChuyenKhoanNoiBo";

        // TaiKhoanTietKiem
        public const string TAIKHOANTIETKIEM_GET_BY_MATAIKHOAN = "GetDsTaiKhoanTietKiem";

        // DanhBa
        public const string DANHBA_GETDANHSACH = "GetDSDanhBa";
        public const string DANHBA_THEM = "ThemDanhBa";
        public const string DANHBA_SUA = "SuaDanhBa";
        public const string DANHBA_XOA = "XoaDanhBa";

        // ThongBao
        public const string THONGBAO_GETDANHSACH = "GetDSThongBao";

        // NganHangLienKet
        public const string NGANHANGLIENKET_GETALL = "GetDSNganHangLienKet";

        // ThongTinChuyenTienNoiBo
        public const string THONGTINCHUYENTIENNOIBO_CHUYENKHOANNOIBO = "ChuyenKhoanNoiBo";
        public const string THONGTINCHUYENTIENNOIBO_GETGIAODICHNHANTIENNOIBO = "XemGiaoDichNhanTienNoiBo";
        public const string THONGTINCHUYENTIENNOIBO_GETGIAODICHGUITIENNOIBO = "XemGiaoDichGuiTienNoiBo";
    }
}
