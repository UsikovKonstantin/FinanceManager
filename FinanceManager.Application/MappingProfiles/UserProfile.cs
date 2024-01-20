using AutoMapper;
using FinanceManager.Application.Features.Auth.Commands.Register;
using FinanceManager.Application.Features.Users.Queries.GetMe;
using FinanceManager.Application.Features.Users.Queries.GetUsersInMyTeam;
using FinanceManager.Domain;

namespace FinanceManager.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterCommand, User>();
		CreateMap<User, CurrentUserResponse>();
		CreateMap<User, UserInMyTeamResponse>();
	}
}
