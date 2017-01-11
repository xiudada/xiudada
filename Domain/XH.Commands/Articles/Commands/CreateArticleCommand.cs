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
    public class CreateArticleCommand : CreateOrUpdateArticleCommandBase
    {
        public string Id { get; set; }
    }
}
