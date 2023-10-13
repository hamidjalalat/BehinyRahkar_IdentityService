using System.Linq;
using IdentityService.Domain.Models;
using IdentityService.Persistence.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Persistence.RevokeTokens.Repositories
{
	public class RevokeTokenQueryRepository :
        IdentityService.Persistence.Base.QueryRepository<RevokeToken>, IRevokeTokenQueryRepository
	{
		public RevokeTokenQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
		{
		}

        public async Task<Domain.Models.RevokeToken> GetByTokenAsync(String Token)
        {
			var result =
			await
			DbSet.Where(C => C.Token == Token)
            .FirstOrDefaultAsync();

            return result;
        }
    }
}
