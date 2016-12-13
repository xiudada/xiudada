using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Domain.Models;

namespace XH.Domain.Model.Catalogs
{
    public class Category : FullAuditableEntity
    {
        public virtual string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string Url { get; set; }

        public virtual string Description { get; set; }

        public virtual ICollection<string> Keywords { get; set; }

        /// <summary>
        /// Reference to parent category
        /// </summary>
        public virtual string ParentCategoryId { get; set; }

        public int 
    }
}
