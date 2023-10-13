using IdentityService.Domain.Models;
using IdentityService.Persistence.RevokeTokens.Repositories;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Persistence.RevokeTokens.Repositories
{
	public class RevokeTokenRepository :
        IdentityService.Persistence.Base.Repository<RevokeToken>, IRevokeTokenRepository
    {
		protected internal RevokeTokenRepository
            (DbContext databaseContext) : base(databaseContext: databaseContext)
		{
		}
	}
}
