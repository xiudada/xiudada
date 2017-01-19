using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Queries.Articles.Dtos;

namespace XH.Queries.Categories.Dtos
{
    public class CategoryDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Slug { get; set; }

        public bool IsActive { get; set; }

        public string ParentId { get; set; }

        public SEOMetaDataDto Meta { get; set; }
    }
}
