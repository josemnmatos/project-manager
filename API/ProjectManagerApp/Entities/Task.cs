using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManagerApp.Entities
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required]
        public CurrentState State { get; set; }

        [ForeignKey("DeveloperId")]
        public Developer? DeveloperAssignedTo { get; set; }

        public int DeveloperId { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [ForeignKey("ProjectId")]
        public Project ProjectAssociatedTo { get; set; } = null!;

        public int ProjectId { get; set; }


        public Task(string name)
        {
            Name = name;
         
        }

    }
}
