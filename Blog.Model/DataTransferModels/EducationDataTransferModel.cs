using System;

namespace Blog.Model.DataTransferModels
{
    public class EducationDataTransferModel:IDataTransferModel
    {
        public UniversityDataTransferModel University { get; set; }

        public string Department { get; set; }
        public string Branch { get; set; }
        public string Detail { get; set; }
        public DateTime Begin { get; set; }
        public DateTime? End { get; set; }
        public float? Score { get; set; }
    }
}
