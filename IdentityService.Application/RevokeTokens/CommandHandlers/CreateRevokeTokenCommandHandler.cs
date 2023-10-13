

using System.Resources;

namespace IdentityService.Application.RevokeTokens.CommandHandlers
{
	public class CreateRevokeTokenCommandHandler : Mediator.IRequestHandler
		<Commands.CreateRevokeTokenCommand, System.Guid>
	{
		public CreateRevokeTokenCommandHandler
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
			Handle(Commands.CreateRevokeTokenCommand request,
			System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result<System.Guid>();

			try
			{
                var RevokeToken = Mapper.Map<Domain.Models.RevokeToken>(source: request);

                await UnitOfWork.RevokeTokens.InsertAsync(entity: RevokeToken);

                await UnitOfWork.SaveAsync();

                result.WithValue(value: RevokeToken.Id);
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
