using System.Linq;
using Blog.DataManager;
using Blog.Model;
using Blog.Model.DataTransferModels;
using Blog.Service.Abstract;

namespace Blog.Service.Concrete
{
    public class AboutService:IAboutService
    {
        private readonly IEntityManager _entityManager;
        public AboutService(IEntityManager entityManager)
        {
            _entityManager = entityManager;
        }
        public IDataTransferModel GetCardInfoDataByAuthor(string username)
        {
            // get author by name
            var authorsTask = _entityManager.GetAllItemListAsync<Author>();
            authorsTask.Wait();
            var selectedAuthor = authorsTask.Result.Single(x => x.Username == username);

            var socialLinksTask = _entityManager.GetAllItemListAsync<SocialPlatform>();
            socialLinksTask.Wait();
            var selectedLinks = socialLinksTask.Result.Where(x => x.AuthorKey == selectedAuthor.Key).Select(x =>
            {
                return new SocialPlatformDataTransferModel
                {
                    Key = x.Key.ToString(),
                    Name = x.Name,
                    Logo = x.Logo,
                    AccountUrl = x.AccountUrl

                };
            });

            // create dto model
            var obj = new CardInfoDataTransferModel
            {
                Key = selectedAuthor.Key.ToString(),
                Email = selectedAuthor.EmailAddress,
                Firstname = selectedAuthor.FirstName,
                Lastname = selectedAuthor.LastName,
                //ImageUrl = selectedAuthor.,
                Location = selectedAuthor.City,
                Title = selectedAuthor.Job,
                SocialLinks = selectedLinks
            };

            return obj;

        }
    }
}
