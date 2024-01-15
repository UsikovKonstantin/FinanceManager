using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FinanceManager.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
	protected readonly FinanceManagerDatabaseContext _context;

	public GenericRepository(FinanceManagerDatabaseContext context)
	{
		_context = context;
	}


	public async Task<IEnumerable<T>> GetAllAsync()
	{
		return await _context.Set<T>().AsNoTracking().ToListAsync();
	}

	public async Task<IEnumerable<T>> GetWhereAsync(Expression<Func<T, bool>> predicate)
	{
		return await _context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
	}

	public async Task<T?> GetByIdAsync(int id)
	{
		return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
	}

	public async Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
	{
		return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
	}

	public async Task CreateAsync(T entity)
	{
		await _context.AddAsync(entity);
		await _context.SaveChangesAsync();
	}

	public async Task UpdateAsync(T entity)
	{
		_context.Entry(entity).State = EntityState.Modified;
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(T entity)
	{
		_context.Remove(entity);
		await _context.SaveChangesAsync();
	}
}
