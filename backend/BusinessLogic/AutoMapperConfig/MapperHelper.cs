using AutoMapper;
using BusinessObject;
using DataObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.AutoMapperConfig
{
    public static class MapperHelper
    {
        static IMapper staticMapper;

        static MapperHelper()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<UserBO, UserDO>();
                config.CreateMap<UserDO, UserBO>();
                config.CreateMap<TaiKhoanTietKiemBO, TaiKhoanTietKiemDO>();
                config.CreateMap<TaiKhoanTietKiemDO, TaiKhoanTietKiemBO>();
            });

            staticMapper = config.CreateMapper();
        }

        public static TDestination Map<TSource, TDestination> (TSource entity)
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<TSource, TDestination>();
            });

            var _mapper = config.CreateMapper();
            return _mapper.Map<TDestination>(entity);
        }
    }
}
