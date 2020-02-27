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
    public class UserService : IUserService
    {
        public async Task<int> AddUser(UserBO user)
        {
            var result = 0;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserBO, UserDO>();
            });

            var mapper = config.CreateMapper();
            var addParam = mapper.Map<UserDO>(user);

            using (DalSession dal = new DalSession())
            {
                try
                {

                } catch(Exception ex)
                {
                    dal.UnitOfWork.Rollback();
                    throw new AggregateException();
                }
                return result;
            }
        }

        public async Task<List<UserBO>> GetAllUsers()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDO, UserBO>();
            });
            var mapper = config.CreateMapper();

            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetAllUser();
                return mapper.Map<List<UserBO>>(result);
            }
        }

        public async Task<UserBO> GetUserByUserNamePassword(string userName, string password)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDO, UserBO>();
            });
            var mapper = config.CreateMapper();
            using (DalSession dal = new DalSession())
            {
                var result = await dal.UnitOfWork.UserRepository.GetUserByUserNamePassword(userName, password);
                return mapper.Map<UserBO>(result);
            }
        }
    }
}
