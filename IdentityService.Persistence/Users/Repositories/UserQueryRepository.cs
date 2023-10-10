using System.Linq;
using IdentityService.Domain.Models;
using IdentityService.Persistence.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Persistence.Users.Repositories
{
	public class UserQueryRepository :
        IdentityService.Persistence.Base.QueryRepository<User>, IUserQueryRepository
	{
		public UserQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
		{
		}

		public
			async
			Task
			<IList<GetUsersQueryResponseViewModel>>
			GetSomeAsync(int count)
		{

			var result =
				await
				DbSet
			
				.Select(current => new ViewModels.GetUsersQueryResponseViewModel()
				{
					Id = current.Id,
					UserName=current.UserName,
					FirstName=current.FirstName,
					LastName=current.LastName,
					EmailAddress=current.EmailAddress,
					Password=current.Password,
				})
				.ToListAsync()
				;


			return result;
		}

		//موقت تا زمانی که بانک اطلاعاتی راه بندازم
        public override Task<User> GetByIdAsync(Guid id)
        {
			GetUsersQueryResponseViewModel result = new GetUsersQueryResponseViewModel()
			{
				Id = id,
				UserName="Hjalalat",
				FirstName="Hamid",
				LastName="Jalalat",
				EmailAddress="hjalalat@yahoo.com",
			};

            return base.GetByIdAsync(id);
        }

        //موقت تا زمانی که بانک اطلاعاتی راه بندازم
        public async Task<Domain.Models.User> GetByUserNameAsync(String username)
        {
			//GetUsersQueryResponseViewModel result = new GetUsersQueryResponseViewModel()
			//{
			//    Id = new Guid(),
			//    UserName = username,
			//    FirstName = "Hamid",
			//    LastName = "Jalalat",
			//    EmailAddress = "hjalalat@yahoo.com",
			//};

			var result =
			await
			DbSet.Where(C => C.UserName == username)
            .FirstOrDefaultAsync();

            return result;
        }
    }
}
