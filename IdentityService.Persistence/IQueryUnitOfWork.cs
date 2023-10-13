namespace IdentityService.Persistence
{
    public interface IQueryUnitOfWork : IdentityService.Persistence.Base.IQueryUnitOfWork
    {
        public Users.Repositories.IUserQueryRepository Users { get; }
        public RevokeTokens.Repositories.IRevokeTokenQueryRepository RevokeTokens { get; }
    }
}
