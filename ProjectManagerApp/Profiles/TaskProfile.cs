using AutoMapper;

namespace ProjectManagerApp.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile() 
        {
            CreateMap<Entities.Task, Models.TaskDto>();
        }


        
    }
}
