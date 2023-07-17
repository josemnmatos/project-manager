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
    public class ProjectsController : ControllerBase
    {   

        //dependency injection for repository and model mapper
        private readonly IProjectInfoRepository _projectInfoRepository;
        private readonly IMapper _mapper;

        public ProjectsController(IProjectInfoRepository projectInfoRepository, IMapper mapper)
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

        [HttpGet("{projectid}", Name ="GetProject")]
        public async Task<ActionResult<IEnumerable<Entities.Project>>> GetProject(int projectId)
        {
            if(!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var projectEntity = await _projectInfoRepository.GetProjectAsync(projectId);
            return Ok(_mapper.Map<ProjectWithoutTasksDto>(projectEntity));
        }


        [HttpPut("{projectid}")]
        public async Task<ActionResult> UpdateProject(int projectId,ProjectForUpdateDto projectForUpdate)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var projectEntity = await _projectInfoRepository.GetProjectAsync(projectId);

            _mapper.Map(projectForUpdate, projectEntity);

            await _projectInfoRepository.SaveChangesAsync();

            return NoContent();


        }


        [HttpPost]
        public async Task<ActionResult<ProjectDto>> CreateProject(
            [FromBody]ProjectForCreationDto project)
        {
            var newProject = _mapper.Map<Entities.Project>(project);

            await _projectInfoRepository.AddProjectAsync(newProject);

            await _projectInfoRepository.SaveChangesAsync();

            var createdProject = _mapper.Map<Models.ProjectDto>(newProject);

            return CreatedAtRoute("GetProject",
                new
                {
                    projectId = createdProject.Id,
                },
                createdProject);
        }


        [HttpDelete("{projectid}")]
        public async Task<ActionResult> DeleteProject(int projectId)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var projectToDelete = await _projectInfoRepository.GetProjectAsync(projectId);

            _projectInfoRepository.DeleteProject(projectToDelete);
            await _projectInfoRepository.SaveChangesAsync();

            return NoContent();

        }


    }
}
