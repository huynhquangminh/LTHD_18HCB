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

        public Task<int> AddUser(UserDO user)
        {
            throw new NotImplementedException();
        }

        public Task<int> EditUserRefreshToken(string userName, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserDO>> GetAllUser()
        {
            throw new NotImplementedException();
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
    }
}
