using IdentityService.Domain.Models;
using IdentityService.Persistence.ViewModels;

namespace IdentityService.Persistence.RevokeTokens.Repositories
{
	public interface IRevokeTokenQueryRepository : IdentityService.Persistence.Base.IQueryRepository<RevokeToken>
	{
		

		Task<Domain.Models.RevokeToken> GetByTokenAsync(String Token);
     
    }
}
