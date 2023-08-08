using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApp.Models;
using ProjectManagerApp.Services;

namespace ProjectManagerApp.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        //dependency injection for repository and model mapper
        private readonly IProjectInfoRepository _projectInfoRepository;
        private readonly IMapper _mapper;

        public AuthenticationController(IProjectInfoRepository projectInfoRepository, IMapper mapper)
        {
            _projectInfoRepository = projectInfoRepository ?? throw new ArgumentNullException(nameof(projectInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        [HttpGet("users")]
        public async Task<ActionResult<IEnumerable<Entities.User>>> GetUsers()
        {
            var userEntities = await _projectInfoRepository.GetUsersAsync();
            return Ok(_mapper.Map<IEnumerable<UserWithoutPasswordDto>>(userEntities));
        }



    }
}
