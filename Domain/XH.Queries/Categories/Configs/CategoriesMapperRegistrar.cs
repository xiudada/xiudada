using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XH.Domain.Catalogs.Models;
using XH.Infrastructure.Mapper;
using XH.Queries.Categories.Dtos;

namespace XH.Queries.Categories.Configs
{
    public class CategoriesMapperRegistrar : IAutoMapperRegistrar
    {
        public void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<Category, CategoryDto>();
            cfg.CreateMap<Category, CategoryOverviewDto>();
        }
    }
}
