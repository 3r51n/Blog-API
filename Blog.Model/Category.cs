using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Model
{
    public class Category:Entity
    {
        [ForeignKey("ParentCategory")]
        public virtual Guid? ParentKey { get; set; }
        public virtual string Name { get; set; }

        public virtual Category ParentCategory { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
