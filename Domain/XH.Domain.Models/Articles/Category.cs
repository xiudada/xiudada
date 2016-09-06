using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Domain.Models;

namespace XH.Domain.Models.Article
{
    /// <summary>
    /// Category
    /// </summary>
    public class Category : FullAuditableEntityBase
    {
        /// <summary>
        /// Name
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Parent category
        /// </summary>
        public virtual Category ParentCategory { get; set; }
    }
}
