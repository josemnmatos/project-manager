
namespace ProjectManagerApp.Services
{
    public interface IProjectInfoRepository
    {

        //Project repository methods 
        //_______________________________________________________________
        Task<IEnumerable<Entities.Project>> GetProjectsAsync();

        Task<Entities.Project?> GetProjectAsync(int projectId);

        Task<bool> ProjectExistsAsync(int projectId);

        Task AddProjectAsync(Entities.Project project);

        void DeleteProject(Entities.Project project);

        //Task repository methods 
        //_______________________________________________________________
        Task<IEnumerable<Entities.Task>> GetTasksForProjectAsync(int projectId);

        Task<Entities.Task?> GetTaskForProjectAsync(int projectId, int taskId);

        Task AddTaskAsync(int projectId, Entities.Task task);

        void DeleteTask(Entities.Task task);

        //Developer repository methods 
        //_______________________________________________________________


        //Manager repository methods 
        //_______________________________________________________________

        //Other repository methods 
        //_______________________________________________________________
        Task<bool> SaveChangesAsync();



    }
}
