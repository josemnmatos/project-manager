using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApp.Models
{
    public class ProjectForCreationDto
    {
        [Required(ErrorMessage ="You must provide a name.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "You must provide a budget.")]
        public double Budget { get; set; }

        [Required(ErrorMessage = "You must associate the project to a manager.")]
        public int ManagerId { get; set; }

    }
}
