using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XH.Commands.Articles.Commands;
using XH.Domain.Catalogs.Models;
using XH.Infrastructure.Mapper;
using XH.Domain.Seo.Models;

namespace XH.Commands.Articles.Configs
{
    public class AritclesMapperRegistrar : IAutoMapperRegistrar
    {
        public void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateArticleCommand, Article>();
            cfg.CreateMap<UpdateArticleCommand, Article>();
            cfg.CreateMap<CreateOrUpdateCommandSEOMetaData, SEOMetaData>();
        }
    }
}
