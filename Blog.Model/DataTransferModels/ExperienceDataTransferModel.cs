using System;

namespace Blog.Model.DataTransferModels
{
    public class ExperienceDataTransferModel:IDataTransferModel
    {
        public CompanyDataTransferModule Company { get; set; }
        public DateTime Begin { get; set; }
        public DateTime? End { get; set; }
        public string Position { get; set; }
        public string Detail { get; set; }
    }
}
