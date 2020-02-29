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
        Task<UserBO> GetUserByUserNamePassword(string userName, string password);
        Task<int> AddUser(UserBO user);
    }
}
