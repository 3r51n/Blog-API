using System.Collections.Generic;

namespace Blog.Model.ApiResponseModels
{
    public interface IValidationResponseModel
    {
        List<ValidationItem> ValidationItems { get; set; }
    }
}
