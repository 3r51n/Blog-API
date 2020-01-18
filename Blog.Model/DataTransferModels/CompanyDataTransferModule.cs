namespace Blog.Model.DataTransferModels
{
    public class CompanyDataTransferModule:IDataTransferModel
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Logo { get; set; }
    }
}
