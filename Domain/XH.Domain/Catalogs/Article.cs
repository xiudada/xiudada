using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XH.Infrastructure.Domain.Models;

namespace XH.Domain.Model.Catalogs
{
    public class Article : FullAuditableEntity
    {
        public virtual string Title { get; set; }

        public virtual string SubTitle { get; set; }

        /// <summary>
        /// SEO
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// SEO
        /// </summary>
        public virtual ICollection<string> Keywords { get; set; }

        /// <summary>
        /// 标签
        /// </summary>
        public virtual ICollection<string> Tags { get; set; }

        /// <summary>
        /// 文章可能会属于多个类目
        /// </summary>
        public virtual ICollection<string> Categories { get; set; }

        /// <summary>
        /// 用于排序
        /// </summary>
        public virtual int DisplayOrder { get; set; }

        /// <summary>
        /// 文章作者
        /// </summary>
        public virtual string Author { get; set; }

        /// <summary>
        /// 来源网站
        /// </summary>
        public virtual string From { get; set; }

        /// <summary>
        /// 来源url
        /// </summary>
        public virtual string ReferenceUrl { get; set; }
    }
}
