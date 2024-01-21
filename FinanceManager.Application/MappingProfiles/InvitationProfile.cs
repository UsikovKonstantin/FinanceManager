using AutoMapper;
using FinanceManager.Application.Features.Invitations.Queries;
using FinanceManager.Domain;

namespace FinanceManager.Application.MappingProfiles;

public class InvitationProfile : Profile
{
    public InvitationProfile()
    {
		CreateMap<Invitation, InvitationResponse>();
	}
}
