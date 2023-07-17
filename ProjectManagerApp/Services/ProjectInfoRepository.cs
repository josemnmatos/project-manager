using Microsoft.EntityFrameworkCore;
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


        public async Task<IEnumerable<Entities.Project>> GetProjectsAsync()
        {
            return await _context.Projects.OrderBy(p => p.Name).ToListAsync();
        }

        public async Task<Entities.Project?> GetProjectAsync(int projectId)
        {
            return await _context.Projects.Where(p => p.Id == projectId).FirstOrDefaultAsync();
        }


        public async Task<bool> ProjectExistsAsync(int projectId)
        {
            return await _context.Projects.Where(p =>p.Id == projectId).AnyAsync();
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
            return await _context.Tasks.Where(t=> t.ProjectId == projectId).ToListAsync();
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
            if(project != null) 
            {
                project.Tasks.Add(task);
            }

        }

        public void DeleteTask(Entities.Task task)
        {
            _context.Tasks .Remove(task);
        }

        //Other methods implementation
        //_____________________________________________________________________
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
    }
}
