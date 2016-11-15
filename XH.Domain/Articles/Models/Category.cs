using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Domain.Models;

namespace XH.Domain.Articles.Models
{
    public class Category : EntityBase
    {
        public virtual string Code { get; set; }

        public virtual string Name { get; set; }

        public virtual int DisplayOrder { get; set; }

        public virtual Category ParentCategory { get; set; }
    }
}
