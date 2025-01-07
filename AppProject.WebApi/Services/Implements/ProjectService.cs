using AppProject.Core.Models.Project;
using AppProject.Infrastructure.Entities;
using AppProject.Infrastructure.Repositories.Interfaces;
using AppProject.WebApi.Services.Interfaces;

namespace AppProject.WebApi.Services.Implements
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IClientRepository _clientRepository;

        public ProjectService(IProjectRepository projectRepository, IClientRepository clientRepository)
        {
            _projectRepository = projectRepository;
            _clientRepository = clientRepository;
        }

        public async Task<CreateProjectResponse> CreateAsync(CreateProjectRequest request)
        {
            var client = await _clientRepository.GetClientByIdAsync(request.ClientId);
            if (client == null)
                throw new KeyNotFoundException($"Client with ID {request.ClientId} not found");

            if (!DateTime.TryParse(request.StartDate.ToString(), out DateTime startDate))
                throw new ArgumentException("Invalid start date format");

            if (!DateTime.TryParse(request.EndDate.ToString(), out DateTime endDate))
                throw new ArgumentException("Invalid end date format");

            var newProject = new Project(
                name: request.Name,
                manager: request.Manager,
                director: request.Director,
                startDate: startDate,
                endDate: endDate,
                duration: (endDate - startDate).Days,
                currency: request.Currency,
                clientId: request.ClientId
            );

            await _projectRepository.CreateAsync(newProject).ConfigureAwait(false);
            await _projectRepository.SaveChangesAsync().ConfigureAwait(false);

            return new CreateProjectResponse
            {
                Id = newProject.Id,
                Name = newProject.Name
            };
        }

        public Task<bool> DeleteProjectAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Project>> GetAllProjectAsync()
        {
            var data = await _projectRepository.GetAllProjectsAsync().ConfigureAwait(false);
            return data;
        }

        public Task<OneProjectResponse> GetOneProjectAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
