using AutoMapper;
using Blog.Model;
using Blog.Model.DataTransferModels;

namespace Blog.Service.Mapping
{
    public class EntityToDTOProfile:Profile
    {
        public EntityToDTOProfile()
        {
            CreateMap<Author, CardInfoDataTransferModel>()
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Job))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.SocialLinks, opt => opt.MapFrom(src => src.SocialPlatforms));
            
            CreateMap<SocialPlatform, SocialPlatformDataTransferModel>();
            CreateMap<Experience, ExperienceDataTransferModel>();
            CreateMap<Company, CompanyDataTransferModule>();
            CreateMap<Education, EducationDataTransferModel>();
            CreateMap<University, UniversityDataTransferModel>();
            CreateMap<AuthorInterestMapping, InterestDataTransferModel>()
                .ForMember(dest=>dest.Key,opt=>opt.MapFrom(src=>src.InterestKey))
                .ForMember(dest=>dest.Name,opt=>opt.MapFrom(src=>src.Interest.Name));

            CreateMap<Success, SuccessDateTransferModel>();
            CreateMap<Reference, ReferenceDataTransferModel>();
        }
    }
}
