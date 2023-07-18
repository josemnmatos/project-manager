using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagerApp.Entities
{   


    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [ForeignKey("ManagerId")]
        public Manager ManagerInCharge { get; set; }

        public int ManagerId { get; set; }

        [Required]
        public double Budget { get; set; }

        public ICollection<Entities.Task> Tasks { get; set; } = new List<Task>();


        public Project(string name)
        {
            Name = name;
        }

    }
}
