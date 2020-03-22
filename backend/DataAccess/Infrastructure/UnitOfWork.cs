using DataAccess.Interface;
using DataAccess.Repository;
using DataAccess.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccess.UnitOfWork
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private IUserRepository _userRepository;
        private ITaiKhoanTietKiemRepository _taiKhoanTietKiemRepository;
        private IDanhBaRepository _danhBaRepository;
        private IThongBaoRepository _thongBaoRepository;
        private INganHangLienKetRepository _nganHangLienKetRepository;
        private IThongTinChuyenTienNoiBoRepository _thongTinChuyenTienNoiBoRepository;
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

        // Repositories
        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository ?? (_userRepository = new UserRepository(_connection, _transaction));
            }
        }

        public ITaiKhoanTietKiemRepository TaiKhoanTietKiemRepository
        {
            get
            {
                return _taiKhoanTietKiemRepository ?? (_taiKhoanTietKiemRepository = new TaiKhoanTietKiemRepository(_connection, _transaction));
            }
        }

        public IDanhBaRepository DanhBaRepository
        {
            get
            {
                return _danhBaRepository ?? (_danhBaRepository = new DanhBaRepository(_connection, _transaction));
            }
        }

        public IThongBaoRepository ThongBaoRepository
        {
            get
            {
                return _thongBaoRepository ?? (_thongBaoRepository = new ThongBaoRepository(_connection, _transaction));
            }
        }

        public INganHangLienKetRepository NganHangLienKetRepository
        {
            get
            {
                return _nganHangLienKetRepository ?? (_nganHangLienKetRepository = new NganHangLienKetRepository(_connection, _transaction));
            }
        }

        public IThongTinChuyenTienNoiBoRepository ThongTinChuyenTienNoiBoRepository
        {
            get
            {
                return _thongTinChuyenTienNoiBoRepository ?? (_thongTinChuyenTienNoiBoRepository = new ThongTinChuyenTienNoiBoRepository(_connection, _transaction));
            }
        }
    }
}
