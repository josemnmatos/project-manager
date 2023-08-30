using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApp.Models
{
    public class UserForRegisterDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmedPassword { get; set; }

        [Required]
        public string Role { get; set; }


    }
}
