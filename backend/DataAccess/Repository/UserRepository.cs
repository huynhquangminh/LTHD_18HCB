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
        public async Task<int> AddUser(UserDO user)
        {
            var param = new DynamicParameters();

            param.Add("@UserName", user.UserName);
            param.Add("@FirstName", user.FirstName);
            param.Add("@LastName", user.LastName);
            param.Add("@Password", user.Password);
            param.Add("@EmailAddress", user.EmailAddress);

            var result = await ExecuteCommandAsync(StoredProcedure.USER_INSERT, param);
            return result;
        }

        public async Task<List<UserDO>> GetAllUser()
        {
            var result = await QueryCommandAsync<UserDO>(StoredProcedure.USER_GETALL);
            return result.ToList();
        }

        public async Task<UserDO> GetUserByUserNamePassword(string userName, string password)
        {
            var param = new DynamicParameters();
            param.Add("@UserName", userName);
            param.Add("@Password", password);

            var result = await QueryCommandSingleAsync<UserDO>(StoredProcedure.USER_GETBY_USERNAME_PASSWORD, param);
            return result;
        }
    }
}
