namespace IdentityService.Persistence
{
	public class QueryUnitOfWork :
        IdentityService.Persistence.Base.QueryUnitOfWork<QueryDatabaseContext>, IQueryUnitOfWork
	{
		public QueryUnitOfWork
			(IdentityService.Persistence.Base.Options options) : base(options: options)
		{
		}

		private Users.Repositories.IUserQueryRepository _users;

		public Users.Repositories.IUserQueryRepository Users
		{
			get
			{
				if (_users == null)
				{
                    _users =
						new Users.Repositories.UserQueryRepository(databaseContext: DatabaseContext);
				}

				return _users;
			}
		}
	}
}
