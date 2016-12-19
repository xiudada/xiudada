using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Domain.Catalogs.Models;
using XH.Infrastructure.Persistence.MongoDb;
using XH.Infrastructure.Persistence.MongoDb.Repositories;

namespace XH.Domain.Catalogs.Repositories
{
    public class ArticleRepository : MongoDbRepositoryBase<Article>, IArticleRepository
    {
        public ArticleRepository(IMongoDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }
}
