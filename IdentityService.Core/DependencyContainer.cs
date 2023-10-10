using MediatR;
using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace IdentityService.Core
{
	public static class DependencyContainer : object
	{
		static DependencyContainer()
		{
		}

		public static void ConfigureServices
			(Microsoft.Extensions.Configuration.IConfiguration configuration,
			Microsoft.Extensions.DependencyInjection.IServiceCollection services)
		{
			services.AddTransient
				<Microsoft.AspNetCore.Http.IHttpContextAccessor,
				Microsoft.AspNetCore.Http.HttpContextAccessor>();

		

			// AddMediatR -> Extension Method -> using MediatR;
			// GetTypeInfo -> Extension Method -> using System.Reflection;
			services.AddMediatR
				(typeof(IdentityService.Application.Users.MappingProfile).GetTypeInfo().Assembly);

			// AddValidatorsFromAssembly -> Extension Method -> using FluentValidation;
			services.AddValidatorsFromAssembly
				(assembly: typeof(IdentityService.Application.Users.Commands.CreateUserCommandValidator).Assembly);

			services.AddTransient
				(typeof(MediatR.IPipelineBehavior<,>), typeof(Mediator.ValidationBehavior<,>));

			// using Microsoft.Extensions.DependencyInjection;
			services.AddAutoMapper
				(profileAssemblyMarkerTypes: typeof(IdentityService.Application.Users.MappingProfile));

			services.AddTransient<IdentityService.Persistence.IUnitOfWork, IdentityService.Persistence.UnitOfWork>(current =>
			{
				string databaseConnectionString =
					configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "CommandsConnectionString")
					.Value;

				string databaseProviderString =
					configuration
					.GetSection(key: "CommandsDatabaseProvider")
					.Value;

                IdentityService.Base.Enums.Provider databaseProvider =
					(IdentityService.Base.Enums.Provider)
					System.Convert.ToInt32(databaseProviderString);

                IdentityService.Persistence.Base.Options options =
					new IdentityService.Persistence.Base.Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new IdentityService.Persistence.UnitOfWork(options: options);
			});

			services.AddTransient<IdentityService.Persistence.IQueryUnitOfWork, IdentityService.Persistence.QueryUnitOfWork>(current =>
			{
				string databaseConnectionString =
					configuration
					.GetSection(key: "ConnectionStrings")
					.GetSection(key: "QueriesConnectionString")
					.Value;

				string databaseProviderString =
					configuration
					.GetSection(key: "QueriesDatabaseProvider")
					.Value;

                IdentityService.Base.Enums.Provider databaseProvider =
					(IdentityService.Base.Enums.Provider)
					System.Convert.ToInt32(databaseProviderString);

                IdentityService.Persistence.Base.Options options =
					new IdentityService.Persistence.Base.Options
					{
						Provider = databaseProvider,
						ConnectionString = databaseConnectionString,
					};

				return new IdentityService.Persistence.QueryUnitOfWork(options: options);
			});
		}
	}
}
