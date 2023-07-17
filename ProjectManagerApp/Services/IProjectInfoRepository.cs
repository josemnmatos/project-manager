
namespace ProjectManagerApp.Services
{
    public interface IProjectInfoRepository
    {

        //Project repository methods 
        //_______________________________________________________________
        Task<IEnumerable<Entities.Project>> GetProjectsAsync();

        Task<Entities.Project?> GetProjectAsync(int projectId);

        Task<bool> ProjectExistsAsync(int projectId);

        //Task repository methods 
        //_______________________________________________________________
        Task<IEnumerable<Entities.Task>> GetTasksForProjectAsync(int projectId);
        Task<Entities.Task?> GetTaskForProjectAsync(int projectId, int taskId);


    }
}
