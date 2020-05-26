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
        //private readonly string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=Bank_LTHD;Integrated Security=True";
        private readonly string connectionString = "workstation id=InternetBankingDB.mssql.somee.com;packet size=4096;user id=bankadmin;pwd=abcdef@12345;data source=InternetBankingDB.mssql.somee.com;persist security info=False;initial catalog=InternetBankingDB";
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
