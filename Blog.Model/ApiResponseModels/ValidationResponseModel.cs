using System.Collections.Generic;

namespace Blog.Model.ApiResponseModels
{
    public class ValidationResponseModel:IValidationResponseModel
    {
        public ValidationResponseModel()
        {
            ValidationItems = new List<ValidationItem>();
        }
        public List<ValidationItem> ValidationItems { get; set; }
    }
}
