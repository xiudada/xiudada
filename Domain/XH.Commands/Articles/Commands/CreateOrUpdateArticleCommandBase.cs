using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Command;

namespace XH.Commands.Articles.Commands
{
    public class CreateOrUpdateArticleCommandBase : CommandBase
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}
