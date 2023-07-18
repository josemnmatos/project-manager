using ProjectManagerApp.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApp.Models
{
    public class TaskForUpdateDto
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public CurrentState State { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        public int DeveloperId { get; set; }



    }
}
