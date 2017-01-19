using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Command;
using XH.Commands.Shared.Commands;

namespace XH.Commands.Categories.Commands
{
    public class CreateOrUpdateCategoryCommand : CommandBase
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Slug { get; set; }

        public bool IsActive { get; set; }

        public string ParentId { get; set; }

        public int DisplayOrder { get; set; }

        public CreateOrUpdateCommandSEOMetaData Meta { get; set; }
    }
}
