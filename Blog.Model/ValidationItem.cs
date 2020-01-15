using System.Collections.Generic;

namespace Blog.Model
{
    public class ValidationItem
    {
        public ValidationItem()
        {
            this.Messages = new List<string>();
        }
        public string PropertyName { get; set; }
        public List<string> Messages { get; set; }
    }
}
