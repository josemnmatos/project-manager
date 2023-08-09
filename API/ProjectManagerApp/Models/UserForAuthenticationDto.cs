using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApp.Models
{
    public class UserForAuthenticationDto
    {
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
