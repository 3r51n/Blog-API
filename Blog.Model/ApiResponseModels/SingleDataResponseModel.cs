using System.Net;
using Blog.Model.DataTransferModels;
using Blog.Model.Enums;

namespace Blog.Model.ApiResponseModels
{
    public class SingleDataResponseModel<TEntity>:IBlogResponseModel where TEntity: class, IDataTransferModel, new()
    {
        public string LanguageCode { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
        public ResultTypes ResultType { get; set; }
        public string RequestIdentifier { get; set; }
        public string Message { get; set; }
        public TEntity Data { get; set; }
        public IExceptionResponseModel Exception { get; set; }
        public IValidationResponseModel Validation { get; set; }
    }
}
