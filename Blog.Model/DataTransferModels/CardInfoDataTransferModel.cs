using System.Collections.Generic;

namespace Blog.Model.DataTransferModels
{
    public class CardInfoDataTransferModel:IDataTransferModel
    {
        public string Key { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<SocialPlatformDataTransferModel> SocialLinks { get; set; }
    }
}
