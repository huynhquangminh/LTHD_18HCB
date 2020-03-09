using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.AutoMapperConfig
{
    public interface IMyMapper
    {
        T MapFrom<T>(object entity);
    }
}
