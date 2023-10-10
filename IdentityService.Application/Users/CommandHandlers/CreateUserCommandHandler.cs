

using System.Resources;

namespace IdentityService.Application.Users.CommandHandlers
{
	public class CreateUserCommandHandler :Mediator.IRequestHandler
		<Commands.CreateUserCommand, System.Guid>
	{
		public CreateUserCommandHandler
			(
			AutoMapper.IMapper mapper,
			Persistence.IUnitOfWork unitOfWork) : base()
		{
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected Persistence.IUnitOfWork UnitOfWork { get; }

		

		public async Task<FluentResults.Result<System.Guid>>
			Handle(Commands.CreateUserCommand request,
			System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result<System.Guid>();

			try
			{
                var user = Mapper.Map<Domain.Models.User>(source: request);

                await UnitOfWork.Users.InsertAsync(entity: user);

                await UnitOfWork.SaveAsync();

                result.WithValue(value: user.Id);
                string successInsert =
                    string.Format("عملیات درج با موفقیت انجام شد");

                result.WithSuccess
                    (successMessage: successInsert);
            }
			catch (System.Exception ex)
			{
				

				result.WithError
					(errorMessage: ex.Message);
			}

			return result;
		}
	}
}
