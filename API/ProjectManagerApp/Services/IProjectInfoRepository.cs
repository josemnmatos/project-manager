
namespace ProjectManagerApp.Services
{
    public interface IProjectInfoRepository
    {


        //Authentication repository methods
        //_______________________________________________________________
        Task<bool> UserExistsAsync(string email);

        Task<bool> UserExistsAsync(int userId);

        Task<Entities.User> AuthenticateUserAsync(string email, string password);

        Task AddUserAsync(Entities.User user);


        //Project repository methods 
        //_______________________________________________________________
        Task<IEnumerable<Entities.Project>> GetProjectsAsync();

        Task<IEnumerable<Entities.Project>> GetProjectsAsync(int? managerId);

        Task<Entities.Project?> GetProjectAsync(int projectId);

        Task<bool> ProjectExistsAsync(int projectId);

        Task AddProjectAsync(Entities.Project project);

        void DeleteProject(Entities.Project project);


        //Task repository methods 
        //_______________________________________________________________
        Task<IEnumerable<Entities.Task>> GetTasksForProjectAsync(int projectId);

        Task<IEnumerable<Entities.Task>> GetTasksForProjectAsync(int projectId, int? developerId);

        Task<Entities.Task?> GetTaskForProjectAsync(int projectId, int taskId);

        Task AddTaskAsync(int projectId, Entities.Task task);

        void DeleteTask(Entities.Task task);

        Task SetTaskStateAsync(int projectId, int taskId, Entities.CurrentState newState);


        //User methods implementation
        //_____________________________________________________________________

        Task<Entities.User?> GetUserByIdAsync(int userId);
        

        //Manager methods implementation
        //_____________________________________________________________________
        Task<bool> ManagerExistsAsync(int managerId);

        Task AddManagerAsync(Entities.Manager manager);

        Task<Entities.Manager?> GetManagerByIdAsync(int userId);

        Task<IEnumerable<Entities.User>> GetUsersAsync();




        //Developer methods implementation
        //_____________________________________________________________________
        Task<bool> DeveloperExistsAsync(int developerId);

        Task<IEnumerable<Entities.Developer>> GetDevelopersAsync();

        Task<Entities.Developer> GetDeveloperAsync(int developerId);

        Task AddDeveloperAsync(Entities.Developer developer);

        Task<Entities.Developer?> GetDeveloperByIdAsync(int userId);



        //Other repository methods 
        //_______________________________________________________________
        Task<bool> SaveChangesAsync();
        void DeleteUser(int userId);
        Task ChangePasswordAsync(int userId, string newPassword);

    }
}
