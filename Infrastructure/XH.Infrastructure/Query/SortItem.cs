using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Shared.Enums;

namespace XH.Infrastructure.Query
{
    public class SortItem
    {
        public string SortBy { get; set; }

        public SortDirection SortDirection { get; set; }
    }
}
