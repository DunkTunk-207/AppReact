using AppProject.Infrastructure.Entities;
using AppProject.WebApi.Models.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppProject.WebApi.Services.Interfaces
{
    public interface IClientService
    {
        Task<CreateClientResponse> CreateAsync(CreateClientRequest request);
        Task<IEnumerable<Client>> GetAllClientAsync();
    }
}