using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XH.Infrastructure.Dependency;
using Autofac;
using XH.Infrastructure.Bus;
using XH.Infrastructure.Query;
using XH.Queries.Articles.Queries;
using XH.Queries.Articles.Dtos;

namespace XH.Infrastructure.Tests.Dependency
{
    [TestClass]
    public class IocManager_Tests
    {
        [TestMethod]
        public void IocManager_Constructor_Test()
        {
            IIocManager iocManager = IocManager.Instance;

            var queryBus = iocManager.IocContainer.Resolve<IQueryBus>();
            var article = queryBus.Send<GetArticleQuery, ArticleDto>(new GetArticleQuery()
            {
                Id = Guid.NewGuid().ToString()
            });

            int i = 0;
        }
    }
}
