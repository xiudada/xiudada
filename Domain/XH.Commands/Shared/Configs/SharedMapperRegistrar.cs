using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XH.Commands.Shared.Commands;
using XH.Domain.Seo.Models;
using XH.Infrastructure.Mapper;

namespace XH.Commands.Shared.Configs
{
    public class SharedMapperRegistrar : IAutoMapperRegistrar
    {
        public void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateOrUpdateCommandSEOMetaData, SEOMetaData>();
        }
    }
}
