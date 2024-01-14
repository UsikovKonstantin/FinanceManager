using FinanceManager.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FinanceManager.Persistence;

public static class PersistenceServiceRegistration
{
	public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<FinanceManagerDatabaseContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("FinanceManagerDatabaseConnectionString"));
		});

		//services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
		//services.AddScoped<ICategoryRepository, CategoryRepository>();
		//services.AddScoped<IProductRepository, ProductRepository>();

		return services;
	}
}
