using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public abstract class DataProvider
    {
        protected IDbTransaction Transaction { get; private set; }

        protected IDbConnection Connection { get; private set; }

        protected DataProvider(IDbConnection dbConnection, IDbTransaction transaction)
        {
            Transaction = transaction;
            Connection = dbConnection;
        }

        public async Task<IEnumerable<T>> QueryCommandAsync<T>(string storedProcedure)
        {
            return await Connection.QueryAsync<T>(storedProcedure);
        }

        public async Task<T> QueryCommandSingleAsync<T>(string storedProcedure, DynamicParameters param = null)
        {
            var result = await Connection.QueryAsync<T>(storedProcedure, param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> ExecuteCommandAsync(string storedProcedure, DynamicParameters param = null)
        {
            var result = await Connection.ExecuteAsync(sql: storedProcedure, param: param,
                commandType: CommandType.StoredProcedure, transaction: Transaction);

            return result;
        }
    }
}
