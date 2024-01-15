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
	Task UpdateAsync(T entity);
	Task DeleteAsync(T entity);
}
