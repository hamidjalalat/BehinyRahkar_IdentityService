namespace IdentityService.Persistence
{
	public class UnitOfWork :
        IdentityService.Persistence.Base.UnitOfWork<DatabaseContext>, IUnitOfWork
	{
		public UnitOfWork
			(IdentityService.Persistence.Base.Options options) : base(options: options)
		{
		}

		private Users.Repositories.IUserRepository _users;

		public Users.Repositories.IUserRepository Users
		{
			get
			{
				if (_users == null)
				{
                    _users =
						new Users.Repositories.UserRepository(databaseContext: DatabaseContext);
				}

				return _users;
			}
		}
	}
}
