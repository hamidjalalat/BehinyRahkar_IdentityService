using IdentityService.Persistence.ViewModels;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace IdentityService.Application.Users.CommandHandlers
{
	public class GetByUserNameQueryHandler : 
		Mediator.IRequestHandler<Queries.GetByUserNameQuery,GetUsersQueryResponseViewModel>
	{
		public GetByUserNameQueryHandler
            (

            AutoMapper.IMapper mapper,
            IdentityService.Persistence.IQueryUnitOfWork unitOfWork) : base()
		{
		
			Mapper = mapper;
			UnitOfWork = unitOfWork;
		}

		protected AutoMapper.IMapper Mapper { get; }

		protected IdentityService.Persistence.IQueryUnitOfWork UnitOfWork { get; }

		

		public async Task
			<FluentResults.Result<GetUsersQueryResponseViewModel>>
			Handle(Queries.GetByUserNameQuery request, System.Threading.CancellationToken cancellationToken)
		{
			var result =
				new FluentResults.Result
				<GetUsersQueryResponseViewModel>();

			try
			{

				var User =
					await
					UnitOfWork.Users
					.GetByUserNameAsync(username:request.UserName.ToLower());

				if (User==null)
				{
                    result.WithError(" نا معتبر می باشد");
				}

                if (string.Compare(User.Password, request.Password, ignoreCase: false) != 0)
                {
                    result.WithError(" نام کاربری یا پسورد اشتباه می باشد");
                }
				string token = Infrastructure.JwtUtility.GenerateJwtToken(User, 120);

                GetUsersQueryResponseViewModel userViewModel = Mapper.Map<GetUsersQueryResponseViewModel>(User);

                //موقت تا زمانی که بانک اطلاعاتی راه بندازم
				userViewModel.Token = token;
				userViewModel.Services = new string[2];

                userViewModel.Services[0] ="ProductService";
                userViewModel.Services[1] = "Logservice";

                userViewModel.Role = "admin";

                result.WithValue(value: userViewModel);
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
