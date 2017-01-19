using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using XH.APIs.WebAPI.Models.Articles;
using XH.APIs.WebAPI.Models.Shared;
using XH.Commands.Articles.Commands;
using XH.Commands.Shared.Commands;
using XH.Infrastructure.Mapper;
using XH.Queries.Articles.Queries;
using XH.APIs.WebAPI.Models.Categories;
using XH.Commands.Categories.Commands;
using XH.Queries.Categories.Queries;

namespace XH.APIs.WebAPI.App_Start
{
    public class WebApiAutoMapperRegistrar : IAutoMapperRegistrar
    {
        public void Register(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateArticleRequest, CreateArticleCommand>();
            cfg.CreateMap<UpdateArticleRequest, UpdateArticleCommand>();
            cfg.CreateMap<SEOMetaDataRequestModel, CreateOrUpdateCommandSEOMetaData>();
            cfg.CreateMap<ListArticlesRequest, ListArticlesQuery>();

            cfg.CreateMap<CreateCategoryRequest, CreateCategoryCommand>();
            cfg.CreateMap<UpdateCategoryRequest, UpdateCategoryCommand>();
            cfg.CreateMap<ListCategoriesRequest, ListCategoriesQuery>();
        }
    }
}