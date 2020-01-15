using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Model.Enums;

namespace Blog.Model
{
    public class Post:Entity
    {
        public byte GaleryIndex { get; set; } = 0;
        public string PrimaryImage { get; set; }
        public int ViewCounter { get; set; }
        public DateTime Publish { get; set; }
        public string Title { get; set; }
        public virtual string ShortDescription { get; set; }

        public virtual string Content { get; set; }
        public virtual PostStates State { get; set; }

        public virtual string Taxonomies { get; set; } // ;vocabulary;vocabulary;
        public virtual ICollection<Comment> Comments { get; set; }

        [ForeignKey("Category")]
        public virtual Guid CategoryKey { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Author")]
        public virtual Guid AuthorKey { get; set; }
        public virtual Author Author { get; set; }
    }
}
