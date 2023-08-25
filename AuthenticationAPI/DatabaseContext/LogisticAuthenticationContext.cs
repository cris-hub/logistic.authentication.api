using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.DatabaseContext
{
    public class LogisticAuthenticationContext : BaseContext
    {
        public LogisticAuthenticationContext(DbContextOptions<LogisticAuthenticationContext> options) : base(options)
        {

        }
    }
}
