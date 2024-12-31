using AppProject.Core.Models.Project;
using AppProject.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppProject.WebApi.Services.Interfaces
{
    public interface IProjectService
    {
        Task<CreateProjectResponse> CreateAsync(CreateProjectRequest request);
        Task<IEnumerable<Project>> GetAllProjectAsync();
        Task<OneProjectResponse> GetOneProjectAsync(Guid id);
        Task<bool> DeleteProjectAsync(Guid id);
    }
}