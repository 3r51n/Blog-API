using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model
{
    public class AuthorInterestMapping:Entity
    {
        [ForeignKey("Author")]
        public virtual Guid AuthorKey { get; set; }
        public virtual Author Author { get; set; }

        [ForeignKey("Interest")]
        public virtual Guid InterestKey { get; set; }
        public virtual Interest Interest { get; set; }
    }
}
