using IdentityService.Application.Users.Commands;
using IdentityService.Application.Users.Queries;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace IdentityService.Api.Controllers
{
    [Microsoft.AspNetCore.Mvc.ApiController]
    [Microsoft.AspNetCore.Mvc.Route
        (template: "[controller]")]
    public class UsersController : IdentityService.Infrastructure.ControllerBase
    {
        public UsersController(MediatR.IMediator mediator) : base(mediator: mediator)
        {
        }

        /// <summary>
        /// فعلا صرفا برای ایجاد کاربر تستی میباشد
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        #region Post (Create user)
        //[Microsoft.AspNetCore.Mvc.HttpPost(template: "/CreateUser")]

        //public async Task<Microsoft.AspNetCore.Mvc.IActionResult>
        //    CreateUser(CreateUserCommand request)
        //{
        //    var result =
        //        await Mediator.Send(request);

        //    return FluentResult(result: result);
        //}
        #endregion /Post (Create user)

        #region Post (Get GetCreateToken)
        [Microsoft.AspNetCore.Mvc.HttpPost(template: "/token")]
        public async Task<IActionResult> GetCreateToken(string username, string password)
        {
            var request =
                new GetByUserNameQuery
                {
                    UserName = username,
                    Password = password,

                };

            var result =
                await Mediator.Send(request);

            return FluentResult(result: result);
        }
        #endregion Post (Get GetCreateToken)
    }
}
