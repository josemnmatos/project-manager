using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApp.Entities;
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
        public async Task<ActionResult<IEnumerable<Entities.Task>>> GetTasks(int projectId,
            [FromQuery] int? developerId)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            if (developerId != null)
            {
                if (!await _projectInfoRepository.DeveloperExistsAsync((int)developerId))
                {
                    return NotFound();
                }
            }

            var taskEntities = await _projectInfoRepository.GetTasksForProjectAsync(projectId, developerId);
            return Ok(_mapper.Map<IEnumerable<TaskDto>>(taskEntities));
        }

        [HttpGet("{taskid}", Name = "GetTask")]
        public async Task<ActionResult<IEnumerable<Entities.Task>>> GetTask(int projectId, int taskId)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var taskEntity = await _projectInfoRepository.GetTaskForProjectAsync(projectId, taskId);

            if (taskEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<TaskDto>(taskEntity));
        }


        [HttpPost]
        public async Task<ActionResult<TaskDto>> CreateTask(
            int projectId,
            [FromBody] TaskForCreationDto task)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var newTask = _mapper.Map<Entities.Task>(task);

            await _projectInfoRepository.AddTaskAsync(projectId, newTask);

            await _projectInfoRepository.SaveChangesAsync();

            var createdTask = _mapper.Map<Models.TaskDto>(newTask);

            return CreatedAtRoute(
                "GetTask",
                new
                {
                    projectId = projectId,
                    taskId = createdTask.Id
                },
                createdTask
                );
        }

        [HttpPost("{taskid}/state")]
        public async Task<ActionResult> SetTaskState (int projectId, int taskId, [FromBody] CurrentState newState)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var taskEntity = await _projectInfoRepository.GetTaskForProjectAsync(projectId, taskId);

            if (taskEntity == null)
            {
                return NotFound();
            }

            await _projectInfoRepository.SetTaskStateAsync(projectId, taskId, newState);

            await _projectInfoRepository.SaveChangesAsync();

            return NoContent();
        }   


        [HttpDelete("{taskid}")]
        public async Task<ActionResult> DeleteTask(int projectId, int taskId)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var taskToDelete = await _projectInfoRepository.GetTaskForProjectAsync(projectId, taskId);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            _projectInfoRepository.DeleteTask(taskToDelete);

            await _projectInfoRepository.SaveChangesAsync();

            return NoContent();

        }


        [HttpPut("{taskid}")]
        public async Task<ActionResult> UpdateTask(int projectId, int taskId,
            [FromBody] TaskForUpdateDto task)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var taskToUpdate = await _projectInfoRepository.GetTaskForProjectAsync(projectId, taskId);

            if (taskToUpdate == null)
            {
                return NotFound();
            }

            _mapper.Map(task, taskToUpdate);

            await _projectInfoRepository.SaveChangesAsync();

            return NoContent();

        }



        [HttpPatch("{taskid}")]
        public async Task<ActionResult> PartiallyUpdateTask(int projectId, int taskId,
            JsonPatchDocument<TaskForUpdateDto> patchDocument)
        {
            if (!await _projectInfoRepository.ProjectExistsAsync(projectId))
            {
                return NotFound();
            }

            var taskEntity = await _projectInfoRepository.GetTaskForProjectAsync(projectId, taskId);

            if (taskEntity == null)
            {
                return NotFound();
            }

            var taskToPatch = _mapper.Map<TaskForUpdateDto>(taskEntity);

            patchDocument.ApplyTo(taskToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(taskToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(taskToPatch, taskEntity);

            await _projectInfoRepository.SaveChangesAsync();

            return NoContent();

        }

    }
}
