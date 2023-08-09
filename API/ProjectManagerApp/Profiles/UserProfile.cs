using AutoMapper;

namespace ProjectManagerApp.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Entities.User, Models.UserWithoutPasswordDto>();
            CreateMap<Models.UserForRegisterDto, Entities.User>();
            CreateMap<Models.UserForRegisterDto, Models.DeveloperInfoDto>();
            CreateMap<Models.UserForRegisterDto, Models.ManagerInfoDto>();
            CreateMap<Models.UserForRegisterDto, Entities.User>();
            CreateMap<Entities.Developer, Models.DeveloperDto>();
            CreateMap<Entities.Developer, Models.DeveloperInfoDto>();
            CreateMap<Entities.Manager, Models.ManagerDto>();
            CreateMap<Entities.Manager, Models.ManagerInfoDto>();
            CreateMap<Entities.User, Entities.Manager>().ForMember(source => source.Id, opt => opt.Ignore()); 
            CreateMap<Entities.User, Entities.Developer>().ForMember(source => source.Id, opt => opt.Ignore());
            CreateMap<Entities.User, Models.ManagerInfoDto>();
            CreateMap<Entities.User, Models.DeveloperInfoDto>();

        }


        
    }
}
