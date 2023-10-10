using IdentityService.Base;
using IdentityService.Base.Enums;

namespace IdentityService.Persistence.Base
{
	public class Options : object
	{
		public Options() : base()
		{
		}

		public Provider Provider { get; set; }

		public string ConnectionString { get; set; }

		public string InMemoryDatabaseName { get; set; }
	}
}
