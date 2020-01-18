using System;
using System.ComponentModel.DataAnnotations.Schema;
using Blog.Model.Enums;

namespace Blog.Model
{
    public class Success:Entity
    {
        [ForeignKey("Author")]
        public virtual Guid  AuthorKey { get; set; }
        public virtual Author  Author { get; set; }
        public virtual SuccessTypes SuccessType { get; set; }
        public virtual string Name { get; set; }
        public virtual string Detail { get; set; }
        public virtual DateTime Date { get; set; }
    }
}
