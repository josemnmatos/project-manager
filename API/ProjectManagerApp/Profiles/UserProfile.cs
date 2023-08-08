using AutoMapper;

namespace ProjectManagerApp.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Entities.User, Models.UserWithoutPasswordDto>();
            CreateMap<Models.UserForRegisterDto, Entities.User>();
            CreateMap<Entities.Developer, Models.DeveloperDto>();
            CreateMap<Entities.Developer, Models.DeveloperInfoDto>();
            CreateMap<Entities.Manager, Models.ManagerDto>();
            CreateMap<Entities.Manager, Models.ManagerInfoDto>();

        }


        
    }
}
