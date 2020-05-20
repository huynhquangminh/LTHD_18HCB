using Dapper;
using DataAccess.Constant;
using DataAccess.Interface;
using DataObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class UserRepository : DataProvider, IUserRepository
    {
        public UserRepository(IDbConnection dbConnection, IDbTransaction transaction)
               : base(dbConnection, transaction)
        {

        }

        public async Task<int> UpdateRefreshToken(string maTaiKhoan, string refreshToken)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);
            param.Add("@refreshToken", refreshToken);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_UPDATE_REFRESHTOKEN, param);
            return result;
        }

        public async Task<List<UserDO>> GetAllUser()
        {
            var result = await QueryCommandAsync<UserDO>(StoredProcedure.USER_GETALL);
            return result.ToList();
        }

        public Task<UserDO> GetUserByUserName(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<UserDO> GetUserByUserNamePassword(string userName, string password)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        //public async Task<int> AddUser(UserDO user)
        //{
        //    var param = new DynamicParameters();

        //    param.Add("@UserId", user.UserId);
        //    param.Add("@UserName", user.UserName);
        //    param.Add("@FirstName", user.FirstName);
        //    param.Add("@LastName", user.LastName);
        //    param.Add("@Password", user.Password);
        //    param.Add("@EmailAddress", user.EmailAddress);

        //    var result = await ExecuteCommandAsync(StoredProcedure.USER_INSERT, param);
        //    return result;
        //}

        //public async Task<int> EditUserRefreshToken(string userName, string refreshToken)
        //{
        //    var param = new DynamicParameters();

        //    param.Add("@UserName", userName);
        //    param.Add("@RefreshToken", refreshToken);

        //    var result = await ExecuteCommandAsync(StoredProcedure.USER_EDIT_REFRESHTOKEN, param);
        //    return result;
        //}

        /// <summary>
        /// Get all user
        /// </summary>
        /// <returns></returns>
        //public async Task<List<UserDO>> GetAllUser()
        //{
        //    var result = await QueryCommandAsync<UserDO>(StoredProcedure.USER_GETALL);
        //    return result.ToList();
        //}


        /// <summary>
        /// Get user by userName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        //public async Task<UserDO> GetUserByUserName(string userName)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@UserName", userName);

        //    var result = await QueryCommandSingleAsync<UserDO>(StoredProcedure.USER_GETBY_USERNAME, param);
        //    return result;
        //}

        /// <summary>
        /// Get user by userName and pasword
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //public async Task<UserDO> GetUserByUserNamePassword(string userName, string password)
        //{
        //    var param = new DynamicParameters();
        //    param.Add("@UserName", userName);
        //    param.Add("@Password", password);

        //    var result = await QueryCommandSingleAsync<UserDO>(StoredProcedure.USER_GETBY_USERNAME_PASSWORD, param);
        //    return result;
        //}

        public async Task<UserDO> GetUserByTenDangNhap(string tenDangNhap)
        {
            var param = new DynamicParameters();
            param.Add("@tendangnhap", tenDangNhap);

            var result = await QueryCommandSingleAsync<UserDO>(StoredProcedure.USER_GETBY_TENDANGNHAP, param);
            return result;
        }

        public async Task<UserDO> GetThongTinTaiKhoanKhachHang(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = await QueryCommandSingleAsync<UserDO>(StoredProcedure.USER_GETTHONGTINTAIKHOANKHACHHANG, param);
            return result;
        }

        public async Task<UserDO> GetThongTinTaiKhoan(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = await QueryCommandSingleAsync<UserDO>(StoredProcedure.USER_GET_THONGTINTAIKHOAN, param);
            return result;
        }
        public async Task<UserDO> GetThongTinTaiKhoanBySoTaiKhoan(string soTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@sotaikhoan", soTaiKhoan);

            var result = await QueryCommandSingleAsync<UserDO>(StoredProcedure.USER_GET_THONGTINTAIKHOAN_SOTAIKHOAN, param);
            return result;
        }

        public async Task<int> DoiMatKhau(string maTaiKhoan, string matKhauMoi)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);
            param.Add("@matkhaumoi", matKhauMoi);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_DOIMATKHAU, param);
            return result;
        }

        public string GetPasswordByMaTk(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = QueryCommandSingle<string>(StoredProcedure.USER_GETPASSWORDBY_MATK, param);
            return result;
        }

        public async Task<int> QuenMatKhau(string tenDangNhap, string email, string matKhauMoi)
        {
            var param = new DynamicParameters();
            param.Add("@tendangnhap", tenDangNhap);
            param.Add("@email", email);
            param.Add("@matkhaumoi", matKhauMoi);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_QUENMATKHAU, param);
            return result;
        }

        public async Task<int> UpdateSoDuSauKhiChuyenKhoanNoiBo(string taiKhoanGui, string taiKhoanNhan, int soTienGui)
        {
            var param = new DynamicParameters();
            param.Add("@taikhoangui", taiKhoanGui);
            param.Add("@taikhoannhan", taiKhoanNhan);
            param.Add("@sotiengui", soTienGui);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_UPDATE_SODUSAUKHICHUYENKHOANNOIBO, param);
            return result;
        }

        public async Task<List<UserDO>> TimKiemThongTinTaiKhoan(string key)
        {
            var param = new DynamicParameters();
            param.Add("@key", key);

            var result = await QueryCommandAsyncWithParam<UserDO>(StoredProcedure.USER_TIMKIEM_THONGTINTAIKHOAN, param);
            return result.ToList();
        }

        public async Task<UserDO> GetThongTinTaiKhoanAdmin(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = await QueryCommandSingleAsync<UserDO>(StoredProcedure.USER_GET_THONGTINTAIKHOAN_ADMIN, param);
            return result;
        }

        public async Task<int> ThemTaiKhoanDangNhap(TaiKhoanDangNhapDO taiKhoanDangNhap)
        {
            var param = new DynamicParameters();
            param.Add("@tendangnhap", taiKhoanDangNhap.TenDangNhap);
            param.Add("@matkhau", taiKhoanDangNhap.MatKhau);
            param.Add("@idloaitaikhoan", taiKhoanDangNhap.IdLoaiTaiKhoan);
            param.Add("@mataikhoan", taiKhoanDangNhap.MaTaiKhoan);
            param.Add("@refreshToken", null);
            var result = await ExecuteCommandAsync(StoredProcedure.USER_THEM_TAIKHOANDANGNHAP, param);
            return result;
        }

        public async Task<int> ThemThongTinTaiKhoanKhachHang(TaiKhoanKhachHangDO taiKhoanKhachHang)
        {
            var param = new DynamicParameters();
            param.Add("@mataikhoan", taiKhoanKhachHang.MaTk);
            param.Add("@email", taiKhoanKhachHang.Email);
            param.Add("@sdt", taiKhoanKhachHang.Sdt);
            param.Add("@sotaikhoan", taiKhoanKhachHang.SoTaiKhoan);
            param.Add("@tentaikhoan", taiKhoanKhachHang.TenTaiKhoan);
            param.Add("@sodu", taiKhoanKhachHang.SoDu);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_THEM_THONGTINTAIKHOANKHACHHANG, param);
            return result;
        }

        public async Task<int> UpdateThongTinTaiKhoanKhachHang(TaiKhoanKhachHangDO taiKhoanKhachHang)
        {
            var param = new DynamicParameters();
            param.Add("@id", taiKhoanKhachHang.Id);
            param.Add("@email", taiKhoanKhachHang.Email);
            param.Add("@sdt", taiKhoanKhachHang.Sdt);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_UPDATE_THONGTINTAIKHOANKHACHHANG, param);
            return result;
        }

        public async Task<int> UpdateThongTinTaiKhoanNhanVien(TaiKhoanNhanVienDO taiKhoanNhanVien)
        {
            var param = new DynamicParameters();
            param.Add("@id", taiKhoanNhanVien.Id);
            param.Add("@email", taiKhoanNhanVien.Email);
            param.Add("@sdt", taiKhoanNhanVien.Sdt);
            param.Add("@tennv", taiKhoanNhanVien.TenNhanVien);
            param.Add("@cmnd", taiKhoanNhanVien.Cmnd);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_UPDATE_THONGTINTAIKHOANNHANVIEN, param);
            return result;
        }
        public async Task<int> XoaTaiKhoan(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_XOA_TAIKHOAN, param);
            return result;
        }

        public async Task<List<TaiKhoanNhanVienDO>> GetDanhSachTaiKhoanAdmin()
        {
            var result = await QueryCommandAsync<TaiKhoanNhanVienDO>(StoredProcedure.USER_GETDANHSACHTAIKHOANADMIN);
            return result.ToList();
        }

        public async Task<int> ThemTaiKhoanNhanVien(TaiKhoanNhanVienDO taiKhoanNhanVien)
        {
            var param = new DynamicParameters();
            param.Add("@matk", taiKhoanNhanVien.MaTk);
            param.Add("@tennhanvien", taiKhoanNhanVien.TenNhanVien);
            param.Add("@cmnd", taiKhoanNhanVien.Cmnd);
            param.Add("@sdt", taiKhoanNhanVien.Sdt);
            param.Add("@email", taiKhoanNhanVien.Email);
            param.Add("@diachi", taiKhoanNhanVien.DiaChi);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_THEM_THONGTINTAIKHOANNHANVIEN, param);
            return result;
        }

        public async Task<string> GetRefreshTokenByMaTk(string maTaiKhoan)
        {
            var param = new DynamicParameters();
            param.Add("@matk", maTaiKhoan);

            var result = await QueryCommandSingleAsync<string>(StoredProcedure.USER_GET_REFRESHTOKEN_BYMATK, param);
            return result;
        }

        public async Task<int> UpdateSoDuGiaoDichKhacNganHang(string soTaiKhoan, int soTien, bool loaiGiaoDich)
        {
            var param = new DynamicParameters();
            param.Add("@sotaikhoan", soTaiKhoan);
            param.Add("@sotien", soTien);
            param.Add("@loaigiaodich", loaiGiaoDich);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_UPDATE_SODUGIAODICHKHACNGANHANG, param);
            return result;
        }
    }
}
