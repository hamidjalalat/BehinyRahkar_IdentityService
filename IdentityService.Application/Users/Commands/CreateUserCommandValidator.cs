using FluentValidation;

namespace IdentityService.Application.Users.Commands
{
	public class CreateUserCommandValidator :
		FluentValidation.AbstractValidator<Commands.CreateUserCommand>
	{
		public CreateUserCommandValidator() : base()
		{
			RuleFor(current => current.UserName)
				.NotEmpty()
				.WithMessage(errorMessage: "Requred");
		
		}
	}
}
