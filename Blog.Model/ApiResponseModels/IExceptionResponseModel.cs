namespace Blog.Model.ApiResponseModels
{
    public interface IExceptionResponseModel
    {
        string TypeName { get; set; }
        string MessageCode { get; set; }
        string Message { get; set; }
    }
}
