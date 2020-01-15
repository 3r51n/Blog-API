using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Model.ApiResponseModels
{
    public class ExceptionResponseModel:IExceptionResponseModel
    {
        public string TypeName { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }

    }
}
