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
    }
}
