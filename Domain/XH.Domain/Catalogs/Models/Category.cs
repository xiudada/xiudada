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
    /// 
    /// </summary>
    public class Category : FullAuditableEntity, IAggregateRoot
    {
        public virtual string Name { get; set; }

        public virtual string Code { get; set; }

        public virtual string Slug { get; set; }

        public virtual bool IsActive { get; set; }

        public virtual string ParentId { get; set; }

        public virtual int DisplayOrder { get; set; }

        public virtual SEOMetaData Meta { get; set; }
    }
}
