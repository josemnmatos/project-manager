namespace ProjectManagerApp.Models
{
    public class ProjectWithoutTasksDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public double Budget { get; set; }

        public int ManagerId { get; set; }

    }
}
