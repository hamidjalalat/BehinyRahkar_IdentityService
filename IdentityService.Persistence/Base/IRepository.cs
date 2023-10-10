
using IdentityService.Domain.Models.Base;

namespace IdentityService.Persistence.Base
{
	public interface IRepository<T> : IQueryRepository<T> where T :IEntity
	{
		Task InsertAsync(T entity);

		Task UpdateAsync(T entity);

		Task DeleteAsync(T entity);

		Task<bool> DeleteByIdAsync(System.Guid id);
	}
}
