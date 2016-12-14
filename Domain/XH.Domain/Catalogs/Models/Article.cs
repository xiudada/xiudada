using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Domain.Seo.Models;
using XH.Infrastructure.Domain.Models;

namespace XH.Domain.Catalogs.Models
{
    /// <summary>
    /// Article
    /// </summary>
    public class Article : FullAuditableEntity, IAggregateRoot
    {

        public virtual string Title { get; set; }

        public virtual string Content { get; set; }

        public virtual SEOMetaData Meta { get; set; }
    }
}
