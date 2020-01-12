using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Model
{
    public class SocialPlatform:Entity
    {
        [ForeignKey("Author")]
        public virtual Guid AuthorKey { get; set; }
        public virtual Author Author { get; set; }

        public virtual string Name { get; set; }
        public virtual string Logo { get; set; }
        public virtual string AccountUrl { get; set; }

    }
}
