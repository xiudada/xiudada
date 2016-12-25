using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Dependency;
using Autofac;
using XH.Infrastructure.Domain.Repositories;
using XH.Domain.Catalogs.Models;
using XH.Config;

namespace XH.Infrastructure.Tests.Repository
{
    [TestClass]
    public class MongoRepository_Tests
    {

        [TestMethod]
        public void IocManager_Constructor_Test()
        {
            Type t = typeof(WebApiConfigurationRegistrar);
            IocManager.Instance.Initialize();
            IIocManager iocManager = IocManager.Instance;

            IRepository<Article> articleRepository = iocManager.IocContainer.Resolve<IRepository<Article>>();

            var result = articleRepository.Insert(new Article
            {
                Id = Guid.NewGuid().ToString(),
                Title = "test title"
            });

            int i = 0;
        }
    }
}
