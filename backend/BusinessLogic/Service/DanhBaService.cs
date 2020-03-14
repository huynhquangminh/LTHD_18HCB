using AutoMapper;
using BusinessLogic.Service.Interface;
using BusinessObject;
using DataAccess.Infrastructure;
using DataObject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class DanhBaService : IDanhBaService
    {
        public async Task<List<DanhBaBO>> GetDanhSachDanhBa(string maTaiKhoan)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DanhBaDO, DanhBaBO>();
            });
            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.DanhBaRepository.GetDanhSachDanhBa(maTaiKhoan);
                return mapper.Map<List<DanhBaBO>>(result);
            }
        }

        public async Task<int> ThemDanhBa(DanhBaBO danhBa)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DanhBaBO, DanhBaDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<DanhBaDO>(danhBa);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.DanhBaRepository.ThemDanhBa(addParam);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                }
                return result;
            }
        }

        public async Task<int> SuaDanhBa(DanhBaBO danhBa)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<DanhBaBO, DanhBaDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<DanhBaDO>(danhBa);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.DanhBaRepository.SuaDanhBa(addParam);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                }
                return result;
            }
        }

        public async Task<int> XoaDanhBa(int id)
        {
            var result = 0;

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.DanhBaRepository.XoaDanhBa(id);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                }
                return result;
            }
        }
    }
}
