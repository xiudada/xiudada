using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XH.Infrastructure.Mapper;
using XH.Queries.Articles.Dtos;
using XH.Domain.Catalogs.Models;

namespace XH.Queries.Articles.Configs
{
    public class AritclesMapperRegistrar : IAutoMapperRegistrar
    {
        public AritclesMapperRegistrar()
        {
        }

        public void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Article, ArticleDto>();
        }
    }
}