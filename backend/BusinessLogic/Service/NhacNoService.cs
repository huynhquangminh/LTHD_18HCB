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
    public class NhacNoService : INhacNoService
    {
        public async Task<List<NhacNoBO>> GetDanhSachNguoiNo(string maTaiKhoan)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NhacNoDO, NhacNoBO>();
            });
            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.NhacNoRepository.GetDanhSachNguoiNo(maTaiKhoan);
                return mapper.Map<List<NhacNoBO>>(result);
            }
        }

        public async Task<List<NhacNoBO>> GetDanhSachNo(string maTaiKhoan)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NhacNoDO, NhacNoBO>();
            });
            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.NhacNoRepository.GetDanhSachNo(maTaiKhoan);
                return mapper.Map<List<NhacNoBO>>(result);
            }
        }

        public async Task<int> Them(NhacNo_ThemBO nhacNo)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NhacNo_ThemBO, NhacNo_ThemDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<NhacNo_ThemDO>(nhacNo);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.NhacNoRepository.Them(addParam);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                }
                return result;
            }
        }

        public async Task<int> UpdateTrangThai(NhacNo_UpdateBO nhacNo)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NhacNo_UpdateBO, NhacNo_UpdateDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<NhacNo_UpdateDO>(nhacNo);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.NhacNoRepository.UpdateTrangThai(addParam);
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
