using Blog.Model.DataTransferModels;

namespace Blog.Service.Abstract
{
    public interface IAboutService:IService
    {
        IDataTransferModel GetCardInfoDataByAuthor(string username);
    }
}
