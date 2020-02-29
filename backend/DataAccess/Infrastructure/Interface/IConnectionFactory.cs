using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Interface
{
    public interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
