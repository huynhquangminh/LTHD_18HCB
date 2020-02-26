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
        private readonly string connectionString = "Server=.\\SQLExpress;Database=EmployeeDB;Trusted_Connection=True;";

        public IDbConnection GetConnection
        {
            get
            {
                //DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
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
