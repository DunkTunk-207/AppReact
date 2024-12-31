using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppProject.Infrastructure.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null, 
            Expression<Func<T, bool>>? includePredicate = null);

        Task<T?> GetOneAsync(
            Expression<Func<T, bool>>? predicate = null, 
            Expression<Func<T, object>>? includePredicate = null);

        Task<T> CreateAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(T entity);

        Task<int> SaveChangesAsync();
    }
}