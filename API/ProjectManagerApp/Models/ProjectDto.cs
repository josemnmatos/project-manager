using ProjectManagerApp.Entities;

namespace ProjectManagerApp.Models
{
    public class ProjectDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Budget { get; set; }

        public virtual ManagerInfoDto ManagerAssignedTo { get; set; } = null!;

        public virtual ICollection<TaskWithoutDeveloperDto> Tasks { get; set; } = new List<TaskWithoutDeveloperDto>();


    }
}
