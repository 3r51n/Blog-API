using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model
{
    public class Experience : Entity
    {
        [ForeignKey("Author")]
        public virtual Guid AuthorKey { get; set; }
        public virtual Author Author { get; set; }

        [ForeignKey("Company")]
        public virtual Guid CompanyKey { get; set; }
        public virtual Company Company { get; set; }
        public virtual DateTime Begin { get; set; }
        public virtual DateTime? End { get; set; }
        public virtual string Position { get; set; }
        public virtual string Detail { get; set; }
    }
}
