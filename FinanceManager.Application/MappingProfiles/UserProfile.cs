using AutoMapper;
using FinanceManager.Application.Features.Users.Commands.RegisterUser;
using FinanceManager.Domain;

namespace FinanceManager.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterUserCommand, User>();    
    }
}
