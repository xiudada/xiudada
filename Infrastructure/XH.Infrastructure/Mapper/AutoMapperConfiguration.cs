using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using XH.Infrastructure.Dependency;

namespace XH.Infrastructure.Mapper
{
    public class AutoMapperConfiguration : IAutoMapperConfiguration
    {
        private readonly IIocManager _iocManager;

        private AutoMapperConfiguration(IIocManager iocManager)
        {
            _iocManager = iocManager;
        }

        public int Priority
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Register(IMapperConfigurationExpression cfg)
        {
            IMapper mapper =AutoMapper.Mapper.Instance;
        }
    }
}
