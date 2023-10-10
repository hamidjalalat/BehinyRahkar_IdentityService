using IdentityService.Domain.Models;
using IdentityService.Persistence.ViewModels;

namespace IdentityService.Persistence.Users.Repositories
{
	public interface IUserQueryRepository : IdentityService.Persistence.Base.IQueryRepository<User>
	{
		Task
			<IList<GetUsersQueryResponseViewModel>>
			GetSomeAsync(int count);

		Task<Domain.Models.User> GetByUserNameAsync(String username);
     
    }
}
