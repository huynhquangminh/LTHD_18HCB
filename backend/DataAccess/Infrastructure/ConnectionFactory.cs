using DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace DataAccess.Infrastructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Bank_LTHD;Integrated Security=True";

        public IDbConnection GetConnection
        {
            get
            {
                var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
                var connect = factory.CreateConnection();
                connect.ConnectionString = connectionString;
                connect.Open();
                return connect;
            }
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
