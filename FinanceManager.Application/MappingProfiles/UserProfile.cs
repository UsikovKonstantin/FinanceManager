using AutoMapper;
using FinanceManager.Application.Features.Auth.Commands.Register;
using FinanceManager.Domain;

namespace FinanceManager.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterCommand, User>();    
    }
}
