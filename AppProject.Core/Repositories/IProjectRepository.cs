using AppProject.Infrastructure.Entities;
using System.Threading.Tasks;

namespace AppProject.Infrastructure.Repositories.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Project>
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
    }
}