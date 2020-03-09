using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.AutoMapperConfig
{
    public class MyMapper : IMyMapper
    {
        IMapper mapper;

        public MyMapper(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public T MapFrom<T>(object entity)
        {
            return mapper.Map<T>(entity);
        }
    }
}
