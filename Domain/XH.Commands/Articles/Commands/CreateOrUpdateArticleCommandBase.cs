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

        public string Author { get; set; }

        public string From { get; set; }

        public string SourceUrl { get; set; }

        public string Image { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? UtcPublishDate { get; set; }

        public CreateOrUpdateCommandSEOMetaData Meta { get; set; }
    }
}
