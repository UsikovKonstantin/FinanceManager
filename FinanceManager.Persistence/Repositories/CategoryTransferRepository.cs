using FinanceManager.Application.Contracts.Persistence;
using FinanceManager.Domain;
using FinanceManager.Persistence.DatabaseContext;

namespace FinanceManager.Persistence.Repositories;

public class CategoryTransferRepository : GenericRepository<CategoryTransfer>, ICategoryTransferRepository
{
	public CategoryTransferRepository(FinanceManagerDatabaseContext context) : base(context)
	{

	}
}
