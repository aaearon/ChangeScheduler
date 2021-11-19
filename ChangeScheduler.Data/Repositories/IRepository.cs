using System.Linq.Expressions;

namespace ChangeScheduler.Data.Repositories
{
    public interface IRepository<T>
    {

        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int id);
        Task<T> GetAsync(int id);
        Task<IEnumerable<T>> AllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

    }
}
