using AutoMapper;
using FinanceManager.Application.Features.Categories.Queries.Shared;
using FinanceManager.Domain;

namespace FinanceManager.Application.MappingProfiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
		CreateMap<Category, CategoryResponse>();
	}
}
