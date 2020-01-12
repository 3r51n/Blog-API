namespace Blog.Model
{
    public class Message:Entity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
    }
}
