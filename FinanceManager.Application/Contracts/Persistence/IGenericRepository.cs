using FinanceManager.Domain;
using System.Linq.Expressions;

namespace FinanceManager.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : BaseEntity
{
	Task<IEnumerable<T>> GetAllAsync();
	Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate);
	Task<T?> GetByIdAsync(int id);
	Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
	Task CreateAsync(T entity);
	Task CreateRangeAsync(params T[] entities);
	Task UpdateAsync(T entity);
	Task UpdateRangeAsync(params T[] entities);
	Task DeleteAsync(T entity);
	Task DeleteRangeAsync(params T[] entities);
}
