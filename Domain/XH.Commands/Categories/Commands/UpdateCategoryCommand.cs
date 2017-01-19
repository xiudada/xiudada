using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Commands.Categories.Commands
{
    public class UpdateCategoryCommand : CreateOrUpdateCategoryCommand
    {
        public string Id { get; set; }
    }
}
