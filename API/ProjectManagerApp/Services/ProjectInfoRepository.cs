using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjectManagerApp.DbContexts;

namespace ProjectManagerApp.Services
{
    public class ProjectInfoRepository : IProjectInfoRepository
    {

        private readonly ProjectManagerContext _context;
        public ProjectInfoRepository(ProjectManagerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<IEnumerable<Entities.User>> GetUsersAsync()
        {
            return await _context.Users.OrderBy(p => p.Id).ToListAsync();
        }


        public async Task<IEnumerable<Entities.Project>> GetProjectsAsync()
        {
            var a = await _context.Projects.Include( p => p.Tasks).OrderBy(p => p.Name).ToListAsync();

            Console.Write(a.ToString());

            return a;
        }

        public async Task<IEnumerable<Entities.Project>> GetProjectsAsync(int? managerId)
        {   
            if (managerId == null || managerId <= 0)
            {
                return await GetProjectsAsync();
            }

            var collection = _context.Projects.Where(p => p.ManagerId == managerId);

            return await collection.OrderBy(p=> p.Name ).ToListAsync();

        }

        public async Task<Entities.Project?> GetProjectAsync(int projectId)
        {
            return await _context.Projects.Where(p => p.Id == projectId).FirstOrDefaultAsync();
        }


        public async Task<bool> ProjectExistsAsync(int projectId)
        {
            return await _context.Projects.Where(p => p.Id == projectId).AnyAsync();
        }


        public async Task AddProjectAsync(Entities.Project project)
        {
            _context.Projects.Add(project);
        }

        public void DeleteProject(Entities.Project project)
        {
            _context.Projects.Remove(project);
        }

        //Task methods implementation
        //_____________________________________________________________________
        public async Task<IEnumerable<Entities.Task>> GetTasksForProjectAsync(int projectId)
        {
            return await _context.Tasks.Where(t => t.ProjectId == projectId).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Task>> GetTasksForProjectAsync(int projectId, int? developerId)
        {
            if(developerId == null || developerId <=0 )
            {
                return await GetTasksForProjectAsync(projectId);            
            }

            var collection = _context.Tasks.Where(p=>p.ProjectId == projectId);

            collection = collection.Where(t => t.DeveloperId == developerId);

            return await collection.OrderBy(t => t.Deadline).ToListAsync();


        }

        public async Task<Entities.Task?> GetTaskForProjectAsync(int projectId, int taskId)
        {
            return await _context.Tasks
                .Where(t1 => t1.ProjectId == projectId && t1.Id == taskId)
                .FirstOrDefaultAsync();
        }

        public async Task AddTaskAsync(int projectId, Entities.Task task)
        {
            var project = await GetProjectAsync(projectId);
            if (project != null)
            {
                project.Tasks.Add(task);
            }

        }

        public void DeleteTask(Entities.Task task)
        {
            _context.Tasks.Remove(task);
        }


        //Manager methods implementation
        //_____________________________________________________________________
        public async Task<bool> ManagerExistsAsync(int managerId)
        {
            return await _context.Managers.Where(m => m.Id == managerId).AnyAsync();
        }



        //Developer methods implementation
        //_____________________________________________________________________
        public async Task<bool> DeveloperExistsAsync(int developerId)
        {
            return await _context.Developers.Where(d => d.Id == developerId).AnyAsync();
        }




        //Other methods implementation
        //_____________________________________________________________________
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        public async Task<IEnumerable<Entities.Project>> GetProjectsByManagerAsync(int managerId)
        {
            return await _context.Projects.Where(p => p.ManagerId == managerId).OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Task>> GetTasksByDeveloperAsync(int developerId)
        {
            return await _context.Tasks.Where(t => t.DeveloperId == developerId).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Task>> GetTasksForProjectByDeveloperAsync(int projectId, int developerId)
        {
            return await _context.Tasks.Where(t => t.ProjectId == projectId && t.DeveloperId == developerId).ToListAsync();
        }

    }
}
