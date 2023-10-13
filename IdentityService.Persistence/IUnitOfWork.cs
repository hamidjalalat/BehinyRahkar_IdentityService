namespace IdentityService.Persistence
{
    public interface IUnitOfWork : IdentityService.Persistence.Base.IUnitOfWork
    {
        public Users.Repositories.IUserRepository Users { get; }
        public RevokeTokens.Repositories.IRevokeTokenRepository RevokeTokens { get; }
    }
}
