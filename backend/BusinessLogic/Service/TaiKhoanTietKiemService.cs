using AutoMapper;
using BusinessLogic.AutoMapperConfig;
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
    public class TaiKhoanTietKiemService : ITaiKhoanTietKiemService
    {
        public async Task<List<TaiKhoanTietKiemBO>> GetDanhSachTheoMaTaiKhoan(string maTaiKhoan)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaiKhoanTietKiemDO, TaiKhoanTietKiemBO>();
            });
            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.TaiKhoanTietKiemRepository.GetDanhSachTheoMaTaiKhoan(maTaiKhoan);
                return mapper.Map<List<TaiKhoanTietKiemBO>>(result);
            }
        }
    }
}
