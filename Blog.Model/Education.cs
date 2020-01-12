using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Model
{
    public class Education:Entity
    {
        [ForeignKey("Author")]
        public virtual Guid AuthorKey { get; set; }
        public virtual Author Author { get; set; }

        [ForeignKey("University")]
        public virtual Guid UniversityKey { get; set; }
        public virtual University University { get; set; }
        public virtual string Department { get; set; }
        public virtual string Branch { get; set; }
        public virtual string Detail { get; set; }
        public virtual DateTime Begin { get; set; }
        public virtual DateTime? End { get; set; }
        public virtual float? Score { get; set; }
    }
}
