using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Query;

namespace XH.Queries.Categories.Queries
{
    /// <summary>
    /// List all 
    /// </summary>
    public class ListCategoriesQuery : ListQueryBase
    {
        public string ParentId { get; set; }
    }
}
