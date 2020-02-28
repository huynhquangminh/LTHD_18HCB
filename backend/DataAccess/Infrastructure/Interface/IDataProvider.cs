using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Infrastructure.Interface
{
    public interface IDataProvider
    {
        public Task<IEnumerable<T>> QueryCommandAsync<T>(string storedProcedure);

        public Task<IEnumerable<T>> QueryCommandAsyncWithParam<T>(string storedProcedure, DynamicParameters param = null);

        public Task<T> QueryCommandSingleAsync<T>(string storedProcedure, DynamicParameters param = null);

        public Task<int> ExecuteCommandAsync(string storedProcedure, DynamicParameters param = null);
    }
}
