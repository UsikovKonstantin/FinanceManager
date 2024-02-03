using AutoMapper;
using FinanceManager.Application.Features.CategoryTransfers.Queries.Shared;
using FinanceManager.Domain;

namespace FinanceManager.Application.MappingProfiles;

public class CategoryTransferProfile : Profile
{
    public CategoryTransferProfile()
    {
		CreateMap<CategoryTransfer, CategoryTransferResponse>();
	}
}
