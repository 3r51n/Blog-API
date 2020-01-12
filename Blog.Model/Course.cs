using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Blog.Model
{
    public class Course:Entity
    {
        [ForeignKey("Author")]
        public virtual Guid AuthorKey { get; set; }
        public virtual Author Author { get; set; }

        public virtual string Name { get; set; }
        public virtual string Topic { get; set; }
        public virtual string Owner { get; set; }
        public virtual string Date { get; set; }
        public virtual string Place { get; set; }
        public virtual string CertificateUrl { get; set; }
        public virtual string Detail { get; set; }
    }
}
