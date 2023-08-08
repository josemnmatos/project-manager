using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApp.Models;
using ProjectManagerApp.Services;

namespace ProjectManagerApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //dependency injection for repository and model mapper
        private readonly IProjectInfoRepository _projectInfoRepository;
        private readonly IMapper _mapper;

        public UserController(IProjectInfoRepository projectInfoRepository, IMapper mapper)
        {
            _projectInfoRepository = projectInfoRepository ?? throw new ArgumentNullException(nameof(projectInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("developers")]
        public async Task<ActionResult<IEnumerable<Entities.Developer>>> GetDevelopers()
        {

            var devEntities = await _projectInfoRepository.GetDevelopersAsync();
            return Ok(_mapper.Map<IEnumerable<DeveloperInfoDto>>(devEntities));
        }

        [HttpGet("developers/{developerid}")]
        public async Task<ActionResult<Entities.Developer>> GetDeveloper(int developerId)
        {
            if (!await _projectInfoRepository.DeveloperExistsAsync(developerId))
            {
                return NotFound();
            }

            var devEntity = await _projectInfoRepository.GetDeveloperAsync(developerId);
            return Ok(_mapper.Map<DeveloperDto>(devEntity));
        }

    }
}
