namespace IdentityService.Persistence.Base
{
	public interface IUnitOfWork : IQueryUnitOfWork
	{
		Task SaveAsync();
	}
}
