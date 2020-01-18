using System.Collections.Generic;

namespace Blog.Model
{
    public class Author:Entity
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string Job { get; set; }
        public virtual string City { get; set; }

        public virtual ICollection<SocialPlatform> SocialPlatforms { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Success> Successes { get; set; }
        public virtual ICollection<Reference> References { get; set; }
        public virtual ICollection<AuthorInterestMapping> Interests { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
