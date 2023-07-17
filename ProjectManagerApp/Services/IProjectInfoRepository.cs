
namespace ProjectManagerApp.Services
{
    public interface IProjectInfoRepository
    {
        Task<IEnumerable<Entities.Project>> GetProjectsAsync();

        Task<Entities.Project?> GetProjectAsync(int projectId);
    }
}
