using AppProject.Infrastructure.Entities;
using System.Threading.Tasks;

namespace AppProject.Infrastructure.Repositories.Interfaces
{
    public interface IClientRepository : IBaseRepository<Client>
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client?> GetClientByIdAsync(Guid id);
    }
}