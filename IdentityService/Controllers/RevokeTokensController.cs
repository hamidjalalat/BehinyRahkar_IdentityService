using IdentityService.Application.RevokeTokens.Commands;
using IdentityService.Application.Users.Commands;
using IdentityService.Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace IdentityService.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.ApiController]
    [Microsoft.AspNetCore.Mvc.Route
        (template: "[controller]")]
    public class RevokeTokensController : IdentityService.Infrastructure.ControllerBase
    {
        public RevokeTokensController(MediatR.IMediator mediator) : base(mediator: mediator)
        {
        }


        #region Post (Create RevokeToken)
        [Microsoft.AspNetCore.Mvc.HttpPost(template: "/revoke")]

        public async Task<IActionResult>
            CreateUser(CreateRevokeTokenCommand request)
        {
            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion /Post (Create RevokeToken)


    }
}
