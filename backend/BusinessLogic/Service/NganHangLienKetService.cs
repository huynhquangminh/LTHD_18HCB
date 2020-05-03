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
    public class NganHangLienKetService : INganHangLienKetService
    {
        public async Task<List<NganHangLienKetBO>> GetDanhSach()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NganHangLienKetDO, NganHangLienKetBO>();
            });

            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.NganHangLienKetRepository.GetDanhSach();
                return mapper.Map<List<NganHangLienKetBO>>(result);
            }
        }

        public async Task<NganHangLienKetBO> GetNganHangLienKetByIdOrTenNganHang(int id, string tenNganHang)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NganHangLienKetDO, NganHangLienKetBO>();
            });
            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.NganHangLienKetRepository.GetNganHangLienKetByIdOrTenNganHang(id, tenNganHang);
                return mapper.Map<NganHangLienKetBO>(result);
            }
        }

        public async Task<int> Them(NganHangLienKetBO nganHangLienKet)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NganHangLienKetBO, NganHangLienKetDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<NganHangLienKetDO>(nganHangLienKet);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.NganHangLienKetRepository.Them(addParam);
                    dal.UnitOfWork.Commit();
                }
                catch (Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                }
                return result;
            }
        }

        public async Task<int> ThemThongTinGiaoDichKhacNganhang(ThongTinGiaoDichLienNganHangBO thongTinGiaoDichLienNganHang)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ThongTinGiaoDichLienNganHangBO, ThongTinGiaoDichLienNganHangDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<ThongTinGiaoDichLienNganHangDO>(thongTinGiaoDichLienNganHang);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.NganHangLienKetRepository.ThemThongTinGiaoDichKhacNganhang(addParam);
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
