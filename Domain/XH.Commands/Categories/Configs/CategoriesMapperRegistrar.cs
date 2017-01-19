using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using XH.Infrastructure.Mapper;
using XH.Commands.Categories.Commands;
using XH.Domain.Catalogs.Models;

namespace XH.Commands.Categories.Configs
{
    public class CategoriesMapperRegistrar : IAutoMapperRegistrar
    {
        public void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateCategoryCommand, Category>();
            cfg.CreateMap<UpdateCategoryCommand, Category>();
        }
    }
}
