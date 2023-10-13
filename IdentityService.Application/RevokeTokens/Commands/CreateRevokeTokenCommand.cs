namespace IdentityService.Application.RevokeTokens.Commands
{

	public class CreateRevokeTokenCommand : Mediator.IRequest<System.Guid>
	{
		public CreateRevokeTokenCommand() : base()
		{
		}

        public string Token { get; set; }


    }
}
