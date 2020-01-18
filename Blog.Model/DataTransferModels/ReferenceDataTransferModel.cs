namespace Blog.Model.DataTransferModels
{
    public class ReferenceDataTransferModel:IDataTransferModel
    {
        public string Key { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GSM { get; set; }
        public string Position { get; set; }
        public string ImageUrl { get; set; }
        public string AccountUrl { get; set; }
    }
}
