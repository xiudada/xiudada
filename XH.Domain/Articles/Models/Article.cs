using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Domain.Models;

namespace XH.Domain.Articles.Models
{
    public class Article : EntityBase
    {
        public virtual string Title { get; set; }

        public virtual string Name { get; set; }

        public virtual string Author { get; set; }

        public virtual string Description { get; set; }

        public virtual string Content { get; set; }


    }
}
