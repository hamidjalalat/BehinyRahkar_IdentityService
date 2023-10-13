using FluentValidation;

namespace IdentityService.Application.RevokeTokens.Commands
{
	public class CreateRevokeTokenCommandValidator :
		FluentValidation.AbstractValidator<Commands.CreateRevokeTokenCommand>
	{
		public CreateRevokeTokenCommandValidator() : base()
		{
			RuleFor(current => current.Token)
				.NotEmpty()
				.WithMessage(errorMessage: "وارد کردن توکن اجباری می باشد")
                .Must(current => current.Length > 200 )
                .WithMessage(errorMessage:"توکن نباید کمتر 200 کارکتر باشد"); 
        }
	}
}
