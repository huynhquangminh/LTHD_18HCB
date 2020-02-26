using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.Interface
{
    interface IConnectionFactory : IDisposable
    {
        IDbConnection GetConnection { get; }
    }
}
