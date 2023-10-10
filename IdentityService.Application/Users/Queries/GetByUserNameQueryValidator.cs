using FluentValidation;

namespace IdentityService.Application.Users.Queries
{
	public class GetByUserNameQueryValidator :
		FluentValidation.AbstractValidator<GetByUserNameQuery>
	{
		public GetByUserNameQueryValidator() : base()
		{
			RuleFor(current => current.UserName)
				.NotEmpty()
				.WithMessage(errorMessage: "UserName is required!")
				;

            RuleFor(current => current.Password)
                .NotEmpty()
                .WithMessage(errorMessage: "Password is required!")
                ;
        }
	}
}
