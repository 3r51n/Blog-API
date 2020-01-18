using System;
using Blog.Model.Enums;

namespace Blog.Model.DataTransferModels
{
    public class SuccessDateTransferModel:IDataTransferModel
    {
        public string Key { get; set; }
        public SuccessTypes SuccessType { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public DateTime Date { get; set; }
    }
}
