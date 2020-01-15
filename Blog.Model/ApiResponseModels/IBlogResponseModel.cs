using System.Net;
using Blog.Model.Enums;

namespace Blog.Model.ApiResponseModels
{
    public interface IBlogResponseModel
    {
        string LanguageCode { get; set; }
        HttpStatusCode HttpStatusCode { get; set; }
        ResultTypes ResultType { get; set; }
        string RequestIdentifier { get; set; }
        string Message { get; set; }
        //IDataResponseModel Data { get; set; }
        //IExceptionResponseModel Exception { get; set; }
        //IValidationResponseModel Validation { get; set; }
    }
}
