using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Blog.DataManager;
using Blog.Model;
using Blog.Model.DataTransferModels;
using Blog.Service.Abstract;

namespace Blog.Service.Concrete
{
    public class AboutService:IAboutService
    {
        private readonly IEntityManager _entityManager;
        private readonly IMapper _mapper;

        public AboutService(IEntityManager entityManager, IMapper mapper)
        {
            _entityManager = entityManager;
            _mapper = mapper;
        }

        public IDataTransferModel GetCardInfoDataByAuthor(string username)
        {
            // get author by name
            var author = GetAuthorByUsername(_entityManager, username);
            return _mapper.Map<CardInfoDataTransferModel>(author);
        }

        public IEnumerable<IDataTransferModel> GetExperiencesByAuthor(string username)
        {
            // get author by name 
            var author = GetAuthorByUsername(_entityManager, username);
            return _mapper.Map<IEnumerable<ExperienceDataTransferModel>>(author.Experiences);
        }

        public IEnumerable<IDataTransferModel> GetEducationsByAuthor(string username)
        {
            // get author by name 
            var author = GetAuthorByUsername(_entityManager, username);
            return _mapper.Map<IEnumerable<EducationDataTransferModel>>(author.Educations);
        }

        public IEnumerable<IDataTransferModel> GetAbilityAndInterestsByAuthor(string username)
        {
            // get author by name 
            var author = GetAuthorByUsername(_entityManager, username);
            return _mapper.Map<IEnumerable<InterestDataTransferModel>>(author.Interests);
        }

        public IEnumerable<IDataTransferModel> GetSuccessesByAuthor(string username)
        {
            // get author by name 
            var author = GetAuthorByUsername(_entityManager, username);
            return _mapper.Map<IEnumerable<SuccessDateTransferModel>>(author.Successes);

        }

        public IEnumerable<IDataTransferModel> GetReferencesByAuthor(string username)
        {
            // get author by name 
            var author = GetAuthorByUsername(_entityManager, username);
            return _mapper.Map<IEnumerable<ReferenceDataTransferModel>>(author.References);
            
        }

        private Author GetAuthorByUsername(IEntityManager em, string username)
        {
            var author = em.GetAllItemList<Author>().SingleOrDefault(x=>x.Username == username);
            return author;
        }
    }
}
