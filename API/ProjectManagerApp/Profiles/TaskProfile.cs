using AutoMapper;

namespace ProjectManagerApp.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile() 
        {
            CreateMap<Entities.Task, Models.TaskDto>();
            CreateMap<Models.TaskForCreationDto, Entities.Task>();
            CreateMap<Models.TaskForUpdateDto, Entities.Task>();
            CreateMap<Entities.Task,Models.TaskForUpdateDto>();
            CreateMap<Entities.Task, Models.TaskWithoutDeveloperDto>();
        }


        
    }
}
