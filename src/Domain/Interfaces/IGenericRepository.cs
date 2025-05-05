using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetValueByIdAsync(int id, CancellationToken cancellationToken);
        Task AddValueAsync(T value);
        Task RemoveValueAsync(int id);
        Task UpdateValueAsync(T value);
        Task<T?> GetByConditionAsync(Expression<Func<T, bool>> predicate);
    }
}
