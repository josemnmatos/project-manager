﻿
namespace ProjectManagerApp.Services
{
    public interface IProjectInfoRepository
    {

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



        //User methods implementation
        //_____________________________________________________________________
        Task<IEnumerable<Entities.User>> GetUsersAsync();

        //Manager methods implementation
        //_____________________________________________________________________
        Task<bool> ManagerExistsAsync(int managerId);


        //Developer methods implementation
        //_____________________________________________________________________
        Task<bool> DeveloperExistsAsync(int developerId);

        Task<IEnumerable<Entities.Developer>> GetDevelopersAsync();

        Task<Entities.Developer> GetDeveloperAsync(int developerId);

        

        //Other repository methods 
        //_______________________________________________________________
        Task<bool> SaveChangesAsync();





    }
}
