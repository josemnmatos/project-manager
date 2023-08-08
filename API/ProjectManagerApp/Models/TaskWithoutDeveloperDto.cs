using ProjectManagerApp.Entities;

namespace ProjectManagerApp.Models
{
    public class TaskWithoutDeveloperDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public CurrentState State { get; set; }

        public DateTime Deadline { get; set; }



    }
}
