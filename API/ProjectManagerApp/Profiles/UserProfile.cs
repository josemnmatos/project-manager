using AutoMapper;

namespace ProjectManagerApp.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<Entities.User, Models.UserWithoutPasswordDto>();
            CreateMap<Models.UserForRegisterDto, Entities.User>();
        }


        
    }
}
