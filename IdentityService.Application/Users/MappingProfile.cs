using IdentityService.Application.RevokeTokens.Commands;
using IdentityService.Persistence.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Application.Users
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile() : base()
        {
            CreateMap<Commands.CreateUserCommand, Domain.Models.User>();
            CreateMap<Domain.Models.User, Commands.CreateUserCommand>();

            CreateMap<CreateRevokeTokenCommand, Domain.Models.RevokeToken>();
            CreateMap<Domain.Models.RevokeToken, CreateRevokeTokenCommand>();

            CreateMap<GetUsersQueryResponseViewModel, Domain.Models.User>();
            CreateMap<Domain.Models.User, GetUsersQueryResponseViewModel>();
        }
    }
}
