using DataAccess.Interface;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        public UnitOfWork(IDbConnection connection)
        {
            _id = Guid.NewGuid();
            _connection = connection;
        }

        readonly IDbConnection _connection = null;
        IDbTransaction _transaction = null;
        readonly Guid _id;

        IDbConnection IUnitOfWork.Connection
        {
            get { return _connection; }
        }
        IDbTransaction IUnitOfWork.Transaction
        {
            get { return _transaction; }
        }
        Guid IUnitOfWork.Id
        {
            get { return _id; }
        }

        public void Begin()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();
            _transaction = null;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository(_connection, _transaction));
            }
        }
    }
}
