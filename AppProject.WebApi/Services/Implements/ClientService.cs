using AppProject.Core.Models.Project;
using AppProject.Infrastructure.Entities;
using AppProject.Infrastructure.Repositories.Interfaces;
using AppProject.WebApi.Models.Client;
using AppProject.WebApi.Services.Interfaces;

namespace AppProject.WebApi.Services.Implements
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<CreateClientResponse> CreateAsync(CreateClientRequest request)
        {
            var newClient = new Client
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Contact = request.Contact,
            };

            await _clientRepository.CreateAsync(newClient).ConfigureAwait(false);
            await _clientRepository.SaveChangesAsync().ConfigureAwait(false);

            return new CreateClientResponse
            {
                Id = newClient.Id,
                Name = newClient.Name
            };
        }

        public async Task<IEnumerable<Client>> GetAllClientAsync()
        {
            return await _clientRepository.GetAllAsync().ConfigureAwait(false);
        }
    }
}
