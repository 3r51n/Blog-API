using System;
using System.ComponentModel.DataAnnotations;

namespace Blog.Model
{
    public interface IEntity
    {
        [Key]
        Guid Key { get; set; }
        DateTime CreateDate { get; set; }
        DateTime LastUpdateDate { get; set; }
    }
}
