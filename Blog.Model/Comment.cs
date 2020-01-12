using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Blog.Model.Enums;

namespace Blog.Model
{
    public class Comment:Entity
    {
        public virtual string EmailAddress { get; set; }
        public virtual string Author { get; set; }
        public virtual string Content { get; set; }
        public virtual CommentStates State { get; set; }

        [ForeignKey("Post")]
        public virtual Guid PostKey { get; set; }

        public virtual Post Post { get; set; }
    }
}
