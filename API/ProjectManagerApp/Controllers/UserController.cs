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
        private readonly EncryptionService _encryptionService;

        public UserController(IProjectInfoRepository projectInfoRepository, IMapper mapper, IConfiguration configuration, EncryptionService encryptionService)
        {
            _projectInfoRepository = projectInfoRepository ?? throw new ArgumentNullException(nameof(projectInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _encryptionService = new EncryptionService(_configuration);
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
                new Claim("id", user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Role),
            };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(300),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

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



        
        [HttpGet("list")]
        [Authorize(Roles = "manager")]
        public async Task<ActionResult<IEnumerable<Entities.User>>> GetAllUsers()
        {
            var users = await _projectInfoRepository.GetUsersAsync();
            return Ok(_mapper.Map<IEnumerable<UserWithoutPasswordDto>>(users));
        }



        [HttpGet("{userid}")]
        [Authorize]
        public async Task<ActionResult<Entities.User>> GetUser(int userId)
        {
            //if user is not manager or the user is not the user they are trying to get
            if (!User.IsInRole("manager") && User.FindFirst("id").Value != userId.ToString())
            {
                return Unauthorized();
            }
            
            if (!await _projectInfoRepository.UserExistsAsync(userId))
            {
                return NotFound();
            }

            var user = await _projectInfoRepository.GetUserByIdAsync(userId);
            return Ok(_mapper.Map<UserWithoutPasswordDto>(user));
        }


        [HttpPut("{userid}")]
        [Authorize]
        public async Task<ActionResult> UpdateUser(int userId, [FromBody] UserForUpdateDto userObject)
        {
            if (userObject == null)
            {
                return BadRequest();
            }

            if (!await _projectInfoRepository.UserExistsAsync(userId))
            {
                return NotFound();
            }

            var user = await _projectInfoRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            //if user is not manager or the user is not the user they are trying to update
            if (!User.IsInRole("manager") && User.FindFirst("id").Value != userId.ToString())
            {
                return Unauthorized();
            }

            _mapper.Map(userObject, user);

            await _projectInfoRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{userid}/password")]
        [Authorize]
        public async Task<ActionResult> UpdatePassword(int userId, [FromBody] PasswordForChangeDto passwordObject)
        {
            if (passwordObject == null)
            {
                return BadRequest();
            }

            if (!await _projectInfoRepository.UserExistsAsync(userId))
            {
                return NotFound();
            }

            var user = await _projectInfoRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            //if user is not manager or the user is not the user they are trying to update
            if (!User.IsInRole("manager") && User.FindFirst("id").Value != userId.ToString())
            {
                return Unauthorized();
            }

            //check if old password is correct
            if (await _projectInfoRepository.AuthenticateUserAsync(user.Email, passwordObject.OldPassword) == null)
            {
                return BadRequest(new {Message = "Old password is incorrect."});
            }

            //change password
            await _projectInfoRepository.ChangePasswordAsync(user.Id, passwordObject.NewPassword);

            await _projectInfoRepository.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete("{userid}")]
        [Authorize]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            if (!await _projectInfoRepository.UserExistsAsync(userId))
            {
                return NotFound();
            }

            var user = await _projectInfoRepository.GetUserByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            //if user is not manager or the user is not the user they are trying to delete
            if (!User.IsInRole("manager") && User.FindFirst("id").Value != userId.ToString())
            {
                return Unauthorized();
            }

           _projectInfoRepository.DeleteUser(user.Id);

            await _projectInfoRepository.SaveChangesAsync();

            return NoContent();
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
