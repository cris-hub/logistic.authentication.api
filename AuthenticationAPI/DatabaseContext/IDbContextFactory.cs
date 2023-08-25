namespace AuthenticationAPI.DatabaseContext
{
    public interface IDbContextFactory
    {
        BaseContext GetContext(string contextName);
    }
}