using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApp.Models;
using ProjectManagerApp.Services;
using System.Data;

namespace ProjectManagerApp.Controllers
{
    [Route("api/developer")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {
        //dependency injection for repository and model mapper
        private readonly IProjectInfoRepository _projectInfoRepository;
        private readonly IMapper _mapper;


        public DeveloperController(IProjectInfoRepository projectInfoRepository, IMapper mapper, IConfiguration configuration)
        {
            _projectInfoRepository = projectInfoRepository ?? throw new ArgumentNullException(nameof(projectInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }


        [HttpGet("dashboard/{userid}")]
        [Authorize(Roles = "developer")]
        public async Task<ActionResult<Entities.Developer>> GetDeveloperDashboardInfo(int userId)
        {
            // check if current userId is same as the one in the token
            if (userId != int.Parse(User.FindFirst("id").Value))
                return Unauthorized();

            var developerData = await _projectInfoRepository.GetDeveloperByIdAsync(userId);

            if (developerData == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DeveloperDto>(developerData));
        }
    }
}
