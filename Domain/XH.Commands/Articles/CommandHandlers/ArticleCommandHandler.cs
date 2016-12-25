using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Commands.Articles.Commands;
using XH.Infrastructure.Command;

namespace XH.Commands.Articles.CommandHandlers
{
    public class ArticleCommandHandler :
        ICommandHandler<CreateArticleCommand>
    {
        public ArticleCommandHandler()
        {

        }

        public void Handle(CreateArticleCommand parameter)
        {
            throw new NotImplementedException();
        }
    }
}
