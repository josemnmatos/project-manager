using Microsoft.EntityFrameworkCore;
using ProjectManagerApp.DbContexts;
using ProjectManagerApp.Entities;

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
    }
}
