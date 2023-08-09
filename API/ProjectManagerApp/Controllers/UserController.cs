using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectManagerApp.Models;
using ProjectManagerApp.Services;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagerApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        //dependency injection for repository and model mapper
        private readonly IProjectInfoRepository _projectInfoRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserController(IProjectInfoRepository projectInfoRepository, IMapper mapper, IConfiguration configuration)
        {
            _projectInfoRepository = projectInfoRepository ?? throw new ArgumentNullException(nameof(projectInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }


        //Authentication Endpoints
        //_____________________________________________________________________________________
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<ActionResult> Authenticate([FromBody] UserForAuthenticationDto userObject )
        {
            if (userObject == null)
            {
                return BadRequest();
            }

            if (! await _projectInfoRepository.UserExistsAsync(userObject.Email))
            {
                return NotFound(new {Message = "User not found."});
            }

            var user = await _projectInfoRepository.AuthenticateUserAsync(userObject.Email, userObject.Password);

            if (user == null)
            {
                return BadRequest();
            }

            var token = GenerateToken(user);

            return Ok(
                new 
                {
                    Token = token
                }
                );

        }

        private string GenerateToken(Entities.User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
                
        
        private Entities.User? GetCurrentUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
        
            if(identity != null)
            {
                var userClaims = identity.Claims;

                var FirstName = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName)?.Value;
                var LastName = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Surname)?.Value;
                var Email = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Email)?.Value;
                var Role = userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Role)?.Value;

                return new Entities.User(FirstName, LastName, Email, Role);
               
            }
            return null;

        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] UserForRegisterDto userObject)
        {
            if (userObject == null)
            {
                return BadRequest();
            }

            var newUser = _mapper.Map<Entities.User>(userObject);

            await _projectInfoRepository.AddUserAsync(newUser);

            await _projectInfoRepository.SaveChangesAsync();

            
            //change to created at route or some ohter thing that makes sense
            return Ok(new
            {
                Message ="User registered."
            });
        }



        //Developer Endpoints
        //_____________________________________________________________________________________
        [HttpGet("developers")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Entities.Developer>>> GetDevelopers()
        {

            var devEntities = await _projectInfoRepository.GetDevelopersAsync();
            return Ok(_mapper.Map<IEnumerable<DeveloperInfoDto>>(devEntities));
        }

        [HttpGet("developers/{developerid}")]
        [Authorize]
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
