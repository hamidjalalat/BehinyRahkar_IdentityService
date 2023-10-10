using IdentityService.Persistence.ViewModels;

namespace IdentityService.Application.Users.CommandHandlers
{
	public class GetUsersQueryHandler : Mediator.IRequestHandler
		<Queries.GetUsersQuery, System.Collections.Generic.IEnumerable<GetUsersQueryResponseViewModel>>
	{
		public GetUsersQueryHandler
			(
			AutoMapper.IMapper mapper,
            IdentityService.Persistence.IQueryUnitOfWork unitOfWork) : base()
		{
		
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected IdentityService.Persistence.IQueryUnitOfWork UnitOfWork { get; }

		

		public
			async
		Task
			<FluentResults.Result
				<IEnumerable
				<GetUsersQueryResponseViewModel>>>
			Handle(Queries.GetUsersQuery request, System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result
				<System.Collections.Generic.IEnumerable
				<GetUsersQueryResponseViewModel>>();

			try
			{
			
				var Users =
					await
					UnitOfWork.Users
					.GetSomeAsync(count: request.Count.Value)
					;
			

				result.WithValue(value: Users);
			
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
