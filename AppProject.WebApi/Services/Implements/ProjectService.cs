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

            var newProject = new Project
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                ClientId = request.ClientId,
                StartDate = DateTime.Parse(request.StartDate.ToString()),
                EndDate = DateTime.Parse(request.EndDate.ToString()),
                Manager = request.Manager,
                Director = request.Director,
                Currency = request.Currency
            };

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
