using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Domain.Catalogs.Models;
using XH.Infrastructure.Domain.Repositories;

namespace XH.Domain.Catalogs.Repositories
{
    public interface IArticleRepository : IRepository<Article>
    {
    }
}
