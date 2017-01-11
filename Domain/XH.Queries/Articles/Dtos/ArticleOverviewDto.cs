using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XH.Queries.Articles.Dtos
{
    public class ArticleOverviewDto
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string From { get; set; }

        public string SourceUrl { get; set; }

        public string Image { get; set; }

        public bool IsPublished { get; set; }

        public DateTime? UtcPublishDate { get; set; }
    }
}
