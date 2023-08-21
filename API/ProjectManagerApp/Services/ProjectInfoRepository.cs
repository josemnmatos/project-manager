using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ProjectManagerApp.DbContexts;
using System.ComponentModel;

namespace ProjectManagerApp.Services
{
    public class ProjectInfoRepository : IProjectInfoRepository
    {

        private readonly ProjectManagerContext _context;
        public ProjectInfoRepository(ProjectManagerContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> UserExistsAsync(string email)
        {
            return await _context.Users.Where(u=>u.Email==email).AnyAsync();
        }

        public async Task<bool> UserExistsAsync(int userId)
        {
            return await _context.Users.Where(u => u.Id == userId).AnyAsync();
        }



        public async Task<Entities.User> AuthenticateUserAsync(string email, string password)
        {
            return await _context.Users.Where(u => u.Email==email && u.Password==password).FirstAsync();
        }

        public async Task AddUserAsync(Entities.User user)
        {
             using (var ctxt = new ProjectManagerContext())
            {
                using(var dbCtxtTransaction = ctxt.Database.BeginTransaction())
                {
                    try
                    {
                        //add user to db
                        ctxt.Users.Add(user);

                        ctxt.SaveChanges();

                        //get id from user added
                        int userId = user.Id;

                        //check role
                        if (user.Role == "developer")
                        {
                            var dev = new Entities.Developer(user.Email, user.FirstName, user.LastName)
                            {
                                UserId = userId
                            };

                            ctxt.Developers.Add(dev);

                        }
                        else
                        {
                            var man = new Entities.Manager(user.Email, user.FirstName, user.LastName)
                            {
                                UserId = userId
                            };

                            ctxt.Managers.Add(man);

                        }

                        ctxt.SaveChanges();

                        dbCtxtTransaction.Commit();

                    }
                    catch (Exception ex)
                    {
                        return;
                    }
                }
                ctxt.SaveChangesAsync();
            }
        }


        public async Task<IEnumerable<Entities.User>> GetUsersAsync()
        {
            return await _context.Users.OrderBy(p => p.FirstName).ThenBy(p=>p.LastName).ToListAsync();
        }

        public async Task<Entities.User?> GetUserByIdAsync(int userId)
        {
            return await _context.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
        }


        public async Task<IEnumerable<Entities.Project>> GetProjectsAsync()
        {
            var a = await _context.Projects.Include(p => p.Tasks).Include(p => p.ManagerAssignedTo).OrderBy(p => p.Name).ToListAsync();
   
            return a;
        }

        public async Task<IEnumerable<Entities.Project>> GetProjectsAsync(int? managerId)
        {   
            if (managerId == null || managerId <= 0)
            {
                return await GetProjectsAsync();
            }

            var collection = _context.Projects.Where(p => p.ManagerId == managerId);

            return await collection.Include(p => p.Tasks).Include(p => p.ManagerAssignedTo).OrderBy(p=> p.Name ).ToListAsync();

        }

        public async Task<Entities.Project?> GetProjectAsync(int projectId)
        {
            return await _context.Projects.Where(p => p.Id == projectId).Include(p => p.Tasks).ThenInclude(t=>t.DeveloperAssignedTo).Include(p => p.ManagerAssignedTo).FirstOrDefaultAsync();
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
            return await _context.Tasks.Where(t => t.ProjectId == projectId).Include(t => t.DeveloperAssignedTo).Include(t => t.ProjectAssociatedTo).ToListAsync();
        }

        public async Task<IEnumerable<Entities.Task>> GetTasksForProjectAsync(int projectId, int? developerId)
        {
            if(developerId == null || developerId <=0 )
            {
                return await GetTasksForProjectAsync(projectId);            
            }

            var collection = _context.Tasks.Where(p=>p.ProjectId == projectId);

            collection = collection.Where(t => t.DeveloperId == developerId);

            return await collection.OrderBy(t => t.Deadline).Include(t => t.DeveloperAssignedTo).Include(t => t.ProjectAssociatedTo).ToListAsync();


        }

        public async Task<Entities.Task?> GetTaskForProjectAsync(int projectId, int taskId)
        {
            var a = await _context.Tasks
                .Where(t1 => t1.ProjectId == projectId && t1.Id == taskId)
                .Include(t => t.DeveloperAssignedTo)
                .Include(t => t.ProjectAssociatedTo)
                .FirstOrDefaultAsync();


            return a;
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

        public async Task<Entities.Manager?> GetManagerByIdAsync(int userId)
        {
            return await _context.Managers.Where(m => m.UserId == userId).Include(m=>m.Projects).ThenInclude(p=>p.Tasks).ThenInclude(t=>t.DeveloperAssignedTo).FirstOrDefaultAsync();
        }


        //Developer methods implementation
        //_____________________________________________________________________
        public async Task<bool> DeveloperExistsAsync(int developerId)
        {
            return await _context.Developers.Where(d => d.Id == developerId).AnyAsync();
        }

        public async Task<IEnumerable<Entities.Developer>> GetDevelopersAsync()
        {
            var a = await _context.Developers.ToListAsync();
            return a;
        }

        public async Task<Entities.Developer> GetDeveloperAsync(int developerId)
        {
            var a = await _context.Developers.Where(d => d.Id == developerId).Include(d => d.Tasks).FirstOrDefaultAsync();

            return a;
        }




        //Other methods implementation
        //_____________________________________________________________________
        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

        public async Task AddManagerAsync(Entities.Manager manager)
        {   
            await _context.AddAsync(manager);
        }

        public async Task AddDeveloperAsync(Entities.Developer developer)
        {
            await _context.AddAsync(developer);
        }
    }
}
