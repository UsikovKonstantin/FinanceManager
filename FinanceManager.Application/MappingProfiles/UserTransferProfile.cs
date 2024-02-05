using AutoMapper;
using FinanceManager.Application.Features.UserTransfers.Queries.Shared;
using FinanceManager.Domain;

namespace FinanceManager.Application.MappingProfiles;

public class UserTransferProfile : Profile
{
    public UserTransferProfile()
    {
		CreateMap<UserTransfer, UserTransferResponse>();
	}
}
