using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApp.Models;
using ProjectManagerApp.Services;

namespace ProjectManagerApp.Controllers
{
    [Route("api/projects/{projectid}/tasks")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        //dependency injection for repository and model mapper
        private readonly IProjectInfoRepository _projectInfoRepository;
        private readonly IMapper _mapper;

        public TasksController(IProjectInfoRepository projectInfoRepository, IMapper mapper)
        {
            _projectInfoRepository = projectInfoRepository ?? throw new ArgumentNullException(nameof(projectInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entities.Task>>> GetTasks(int projectId)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var taskEntities = await _projectInfoRepository.GetTasksForProjectAsync(projectId);
            return Ok(_mapper.Map<IEnumerable<TaskDto>>(taskEntities));
        }

        [HttpGet("{taskid}")]
        public async Task<ActionResult<IEnumerable<Entities.Task>>> GetTask(int projectId, int taskId)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var taskEntity = await _projectInfoRepository.GetTaskForProjectAsync(projectId,taskId);

            if(taskEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TaskDto>(taskEntity));
        }




    }
}
