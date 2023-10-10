using IdentityService.Persistence.ViewModels;

namespace IdentityService.Application.Users.Queries
{
	public class GetByUserNameQuery : object,
		Mediator.IRequest
		<GetUsersQueryResponseViewModel>
	{
		public GetByUserNameQuery() : base()
		{
		}

		public string UserName { get; set; }
		public string Password { get; set; }
	}
}
