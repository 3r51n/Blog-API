using System.Collections.Generic;
using Blog.Model.DataTransferModels;

namespace Blog.Service.Abstract
{
    public interface IAboutService:IService
    {
        IDataTransferModel GetCardInfoDataByAuthor(string username);
        IEnumerable<IDataTransferModel> GetExperiencesByAuthor(string username);
        IEnumerable<IDataTransferModel> GetEducationsByAuthor(string username);
        IEnumerable<IDataTransferModel> GetAbilityAndInterestsByAuthor(string username);
        IEnumerable<IDataTransferModel> GetSuccessesByAuthor(string username);
        IEnumerable<IDataTransferModel> GetReferencesByAuthor(string username);
    }
}
