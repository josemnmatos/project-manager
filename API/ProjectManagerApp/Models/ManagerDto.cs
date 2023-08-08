namespace ProjectManagerApp.Models
{
    public class ManagerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<ProjectDto> Projects { get; set; } = new List<ProjectDto>();
    }
}
