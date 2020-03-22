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
        Task<UserBO> GetUserByUserNamePassword(string userName, string password);
        Task<int> AddUser(UserBO user);
        Task<int> EditUserRefreshToken(string userName, string refreshToken);
        Task<UserBO> GetUserByTenDangNhap(string tenDangNhap);
        Task<UserBO> GetThongTinTaiKhoan(string maTaiKhoan);
        Task<int> DoiMatKhau(string maTaiKhoan, string matKhauMoi);
        string GetPasswordByMaTk(string maTaiKhoan);
        Task<int> QuenMatKhau(string tenDangNhap, string email, string matKhauMoi);
    }
}
