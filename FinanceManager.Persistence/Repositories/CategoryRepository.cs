using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;

namespace FinanceManager.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
	public CategoryRepository(FinanceManagerDatabaseContext context) : base(context)
	{

	}
}
