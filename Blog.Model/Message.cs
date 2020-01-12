namespace Blog.Model
{
    public class Message:Entity
    {
        public virtual string Name { get; set; }
        public virtual string Email { get; set; }
        public virtual string Topic { get; set; }
        public virtual string Content { get; set; }
    }
}
