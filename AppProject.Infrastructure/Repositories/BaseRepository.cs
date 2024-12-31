using System.Linq.Expressions;
using AppProject.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AppProject.Infrastructure.Repositories.Implements
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DbSet<T> _dbSet;
        private readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            return (await _dbSet.AddAsync(entity).ConfigureAwait(false)).Entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);

            return await Task.FromResult(true).ConfigureAwait(false);
        }

        public async Task<T?> GetOneAsync(
    Expression<Func<T, bool>>? predicate = null,
    Expression<Func<T, object>>? includePredicate = null)
        {
            var query = _dbSet.AsQueryable();

            if (includePredicate != null)
            {
                query = query.Include(includePredicate);
            }

            if (predicate != null)
            {
                return await query.FirstOrDefaultAsync(predicate).ConfigureAwait(false);
            }

            return await query.FirstOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAllAsync(
    Expression<Func<T, bool>>? predicate = null,
    Expression<Func<T, bool>>? includePredicate = null)
        {
            var query = _dbSet.AsQueryable();

            if (includePredicate != null)
            {
                query = query.Include(includePredicate);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query.ToListAsync().ConfigureAwait(false);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await Task.FromResult(_dbSet.Update(entity).Entity).ConfigureAwait(false);
        }
    }
}
