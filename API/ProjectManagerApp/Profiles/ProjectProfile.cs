﻿using AutoMapper;

namespace ProjectManagerApp.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile() 
        {
            CreateMap<Entities.Project, Models.ProjectDto>();
            CreateMap<Entities.Project, Models.ProjectWithoutTasksDto>();
            CreateMap<Entities.Project, Models.ProjectWithoutManagerDto>();
            CreateMap<Models.ProjectForCreationDto, Entities.Project>();
            CreateMap<Models.ProjectForUpdateDto, Entities.Project>();

        }

    }
}
