namespace Blog.Model.DataTransferModels
{
    public class SocialPlatformDataTransferModel:IDataTransferModel
    {
        public string Key { get; set; }
        public string AccountUrl { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
    }
}
