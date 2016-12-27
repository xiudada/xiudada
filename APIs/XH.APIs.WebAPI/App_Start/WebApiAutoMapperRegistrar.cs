using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using XH.APIs.WebAPI.Models.Articles;
using XH.Commands.Articles.Commands;
using XH.Infrastructure.Mapper;

namespace XH.APIs.WebAPI.App_Start
{
    public class WebApiAutoMapperRegistrar : IAutoMapperRegistrar
    {
        public void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateArticleRequest, CreateArticleCommand>();
        }
    }
}