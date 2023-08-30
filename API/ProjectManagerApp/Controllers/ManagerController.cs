using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApp.Models;
using ProjectManagerApp.Services;
using System.Data;

namespace ProjectManagerApp.Controllers
{
    [Route("api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        //dependency injection for repository and model mapper
        private readonly IProjectInfoRepository _projectInfoRepository;
        private readonly IMapper _mapper;
        

        public ManagerController(IProjectInfoRepository projectInfoRepository, IMapper mapper, IConfiguration configuration)
        {
            _projectInfoRepository = projectInfoRepository ?? throw new ArgumentNullException(nameof(projectInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            
        }


        [HttpGet("dashboard/{userid}")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<Entities.Manager>> GetManagerDashboardInfo(int userId)
        {
            // check if current userId is same as the one in the token
            if (userId != int.Parse(User.FindFirst("id").Value))
                return Unauthorized();

            var managerData = await _projectInfoRepository.GetManagerByIdAsync(userId);

            if (managerData == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ManagerDto>(managerData));
        }



        [HttpGet("dashboard/staff")]
        //[Authorize(Roles = "manager")]
        public async Task<ActionResult<Entities.User>> GetStaffDashboardInfo()
        {
            var users = await _projectInfoRepository.GetUsersAsync();

            return Ok(_mapper.Map<IEnumerable<UserWithoutPasswordDto>>(users));

        }





    }
}
