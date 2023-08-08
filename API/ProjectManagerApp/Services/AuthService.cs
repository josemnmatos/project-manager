using Microsoft.IdentityModel.Tokens;
using ProjectManagerApp.DbContexts;
using ProjectManagerApp.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace ProjectManagerApp.Services
{
    public class AuthService
    {

        private readonly ProjectManagerContext _context;
        private readonly IConfiguration _configuration;
        public AuthService(ProjectManagerContext context, IConfiguration configuration)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public bool IsAuthenticated(string email, string password)
        {
            var user = this.GetByEmail(email);
            return this.DoesUserExists(email) && BC.Verify(password, user.Password);
        }

        public bool DoesUserExists(string email)
        {
            var user = this._context.Users.FirstOrDefault(x => x.Email == email);
            return user != null;
        }

        public User GetById(int id)
        {
            return this._context.Users.FirstOrDefault(c => c.Id == id);
        }

        public User GetByEmail(string email)
        {
            return this._context.Users.FirstOrDefault(c => c.Email == email);
        }

        public string GenerateJwtToken(string email, string role)
        {
            var issuer = this._configuration["Jwt:Issuer"];
            var audience = this._configuration["Jwt:Audience"];
            var key = Encoding.ASCII.GetBytes(this._configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                        {
                    new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub, email),
                        new Claim(JwtRegisteredClaimNames.Email, email),
                        new Claim(ClaimTypes.Role, role),
                        new Claim(JwtRegisteredClaimNames.Jti,
                            Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
