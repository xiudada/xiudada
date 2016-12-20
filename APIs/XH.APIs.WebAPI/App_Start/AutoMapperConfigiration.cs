using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using AutoMapper;
using XH.Infrastructure.Mapper;
using XH.Infrastructure.Models;

namespace XH.APIs.WebAPI.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public class WebApiAutoMapperConfigiration : IAutoMapperConfiguration
    {
        Singleton<IContainer> 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cfg"></param>
        public void Register(IMapperConfigurationExpression cfg)
        {
            
        }
    }
}