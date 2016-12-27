using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace XH.Infrastructure.Mapper
{
    public interface IAutoMapperRegistrar
    {
        void Register(IMapperConfigurationExpression cfg);
    }
}
