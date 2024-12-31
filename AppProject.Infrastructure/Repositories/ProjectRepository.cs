using AppProject.Infrastructure.Entities;
using AppProject.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AppProject.Infrastructure.Repositories.Implements
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _dbSet
                .Include(c => c.Client)
                .ToListAsync().ConfigureAwait(false);
        }
    }
}