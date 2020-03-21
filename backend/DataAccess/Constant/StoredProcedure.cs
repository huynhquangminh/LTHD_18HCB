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
        public const string USER_EDIT_REFRESHTOKEN = "sp_User_Edit_RefreshToken";
        public const string USER_DOIMATKHAU = "DoiMatKhau";
        public const string USER_GETPASSWORDBY_MATK = "GetPasswordByMaTk";
        public const string USER_QUENMATKHAU = "QuenMatKhauUser";

        // User
        public const string USER_GETBY_TENDANGNHAP = "GetUserByTenDangNhap";
        public const string USER_GET_THONGTINTAIKHOAN = "GetThongTinTaiKhoan";

        // TaiKhoanTietKiem
        public const string TAIKHOANTIETKIEM_GET_BY_MATAIKHOAN = "GetDsTaiKhoanTietKiem";

        // DanhBa
        public const string DANHBA_GETDANHSACH = "GetDSDanhBa";
        public const string DANHBA_THEM = "ThemDanhBa";
        public const string DANHBA_SUA = "SuaDanhBa";
        public const string DANHBA_XOA = "XoaDanhBa";

        // ThongBao
        public const string THONGBAO_GETDANHSACH = "GetDSThongBao";
    }
}
