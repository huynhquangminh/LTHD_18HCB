using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Infrastructure
{
    public sealed class DalSession : IDisposable
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=BanHangDB;Integrated Security=True";
        private readonly IDbConnection _connection = null;
        private readonly UnitOfWork.UnitOfWork _unitOfWork = null;

        public DalSession()
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _unitOfWork = new UnitOfWork.UnitOfWork(_connection);
        }

        public UnitOfWork.UnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
            _connection.Dispose();
        }
    }
}
