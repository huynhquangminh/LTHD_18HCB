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
        Task<UserDO> GetUserByUserNamePassword(string userName, string password);
        Task<int> AddUser(UserDO user);
        Task<int> EditUserRefreshToken(string userName, string refreshToken);
        Task<UserDO> GetUserByTenDangNhap(string tenDangNhap);
        Task<UserDO> GetThongTinTaiKhoan(string maTaiKhoan);
        Task<int> DoiMatKhau(string maTaiKhoan, string matKhauMoi);
    }
}
