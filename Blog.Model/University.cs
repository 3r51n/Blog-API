namespace Blog.Model
{
    public class University:Entity
    {
        public virtual string Name { get; set; }
        public virtual string LogoUrl { get; set; }
        public virtual string Location { get; set; }
    }
}
