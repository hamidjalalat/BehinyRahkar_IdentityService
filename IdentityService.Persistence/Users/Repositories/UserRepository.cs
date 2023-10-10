using IdentityService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Persistence.Users.Repositories
{
	public class UserRepository :
        IdentityService.Persistence.Base.Repository<User>, IUserRepository
	{
		protected internal UserRepository
			(DbContext databaseContext) : base(databaseContext: databaseContext)
		{
		}
	}
}
