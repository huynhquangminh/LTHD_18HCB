using Dapper;
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

        public Task<List<UserDO>> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<UserDO> GetUserByUserNamePassword(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
