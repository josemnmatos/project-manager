namespace ProjectManagerApp.Models
{
    public class ProjectWithoutManagerDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Budget { get; set; }

        public virtual ICollection<TaskDto> Tasks { get; set; } = new List<TaskDto>();
    }
}
