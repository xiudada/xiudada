using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Domain.Seo.Models
{
    public class SEOMetaData
    {
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }

        public virtual string Keywords { get; set; }
    }
}
