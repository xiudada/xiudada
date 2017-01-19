using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Queries.Categories.Dtos
{
    public class CategoryOverviewDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Slug { get; set; }

        public bool IsActive { get; set; }

        public string ParentId { get; set; }
    }
}
