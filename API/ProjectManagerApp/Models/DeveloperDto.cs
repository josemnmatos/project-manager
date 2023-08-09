namespace ProjectManagerApp.Models
{
    public class DeveloperDto
    {
      
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<TaskWithoutDeveloperDto> Tasks { get; set; } = new List<TaskWithoutDeveloperDto>();
    }
}
