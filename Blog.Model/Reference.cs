using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model
{
    public class Reference:Entity
    {
        [ForeignKey("Author")]
        public virtual Guid AuthorKey { get; set; }
        public virtual Author Author { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Position { get; set; }
        public virtual string ImageUrl { get; set; }
        public virtual string AccountUrl { get; set; }
    }
}
