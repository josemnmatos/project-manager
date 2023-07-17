using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApp.Models;
using ProjectManagerApp.Services;
using System.Data;

namespace ProjectManagerApp.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {   

        //dependency injection for repository and model mapper
        private readonly IProjectInfoRepository _projectInfoRepository;
        private readonly IMapper _mapper;

        public ProjectController(IProjectInfoRepository projectInfoRepository, IMapper mapper)
        {
            _projectInfoRepository = projectInfoRepository ?? throw new ArgumentNullException(nameof(projectInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Project>>> GetProjects()
        {
            var projectEntities = await _projectInfoRepository.GetProjectsAsync();
            return Ok(_mapper.Map<IEnumerable<ProjectWithoutTasksDto>>(projectEntities));
        }

        [HttpGet("{projectid}")]
        public async Task<ActionResult<IEnumerable<Entities.Project>>> GetProject(int projectId)
        {





            var projectEntities = await _projectInfoRepository.GetProjectsAsync();
            return Ok(_mapper.Map<IEnumerable<ProjectWithoutTasksDto>>(projectEntities));
        }





    }
}
