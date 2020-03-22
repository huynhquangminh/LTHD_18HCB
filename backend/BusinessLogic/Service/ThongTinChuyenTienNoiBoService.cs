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
    public class ThongTinChuyenTienNoiBoService : IThongTinChuyenTienNoiBoService
    {
        public async Task<int> ChuyenKhoanNoiBo(ThongTinChuyenTienNoiBoBO thongTinChuyenTienNoiBo)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ThongTinChuyenTienNoiBoBO, ThongTinChuyenTienNoiBoDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<ThongTinChuyenTienNoiBoDO>(thongTinChuyenTienNoiBo);

            using (DalSession dal = new DalSession())
            {
                try
                {
                    dal.UnitOfWork.Begin();
                    result = await dal.UnitOfWork.ThongTinChuyenTienNoiBoRepository.ChuyenKhoanNoiBo(addParam);
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
