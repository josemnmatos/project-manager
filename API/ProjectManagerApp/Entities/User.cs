using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApp.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string ?Password { get; set; }

        [Required]
        public string Role { get; set; }

        public string ?Token { get; set; }

        public User(string firstName, string lastName, string email, string password, string role)
        {
            FirstName = firstName; 
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;

        }

        public User(string firstName, string lastName, string email, string role)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Role = role;
        }
    }
}