﻿using AutoMapper;
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
    public class ThongBaoService : IThongBaoService
    {
        public async Task<List<ThongBaoBO>> GetDanhSachTheoMaTaiKhoan(string maTaiKhoan)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ThongBaoDO, ThongBaoBO>();
            });

            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.ThongBaoRepository.GetDanhSachTheoMaTaiKhoan(maTaiKhoan);
                return mapper.Map<List<ThongBaoBO>>(result);
            }
        }

        public async Task<int> Them(string maTaiKhoan, string noiDung)
        {
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.ThongBaoRepository.Them(maTaiKhoan, noiDung);
                return result;
            }
        }

        public async Task<int> Update(int id)
        {
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.ThongBaoRepository.Update(id);
                return result;
            }
        }
    }
}
