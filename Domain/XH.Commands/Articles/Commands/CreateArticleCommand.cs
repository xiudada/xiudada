using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Command;

namespace XH.Commands.Articles.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CreateArticleCommand : CommandBase
    {
        public string Title { get; set; }
    }
}
