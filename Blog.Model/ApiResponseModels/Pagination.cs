namespace Blog.Model.ApiResponseModels
{
    public class Pagination
    {
        public int TotalCount { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Returned { get; set; }
    }
}
