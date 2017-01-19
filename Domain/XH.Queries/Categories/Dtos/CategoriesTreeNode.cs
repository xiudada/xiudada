using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Queries.Categories.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class CategoriesTreeNode : CategoryOverviewDto
    {
        public IEnumerable<CategoriesTreeNode> ChildNodes { get; set; }
    }

    public class CategoriesTree
    {
        public CategoriesTreeNode Root { get; set; }
    }
}
