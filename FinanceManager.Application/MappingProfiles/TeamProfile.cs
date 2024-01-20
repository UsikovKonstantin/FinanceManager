using AutoMapper;
using FinanceManager.Application.Features.Teams.Queries;
using FinanceManager.Domain;

namespace FinanceManager.Application.MappingProfiles;

public class TeamProfile : Profile
{
    public TeamProfile()
    {
		CreateMap<Team, TeamResponse>();
	}
}
