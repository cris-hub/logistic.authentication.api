using AuthenticationAPI.DatabaseContext;
using AuthenticationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.test
{
    public class DatabaseContextTest
    {
        public DbContext context = new BaseContext();
        [Fact]
        public void GetUserById()
        {
            DbSet<User> users = ((BaseContext)context).Users;

            Assert.NotNull(users);
            Assert.NotNull(context);

        }
    }
}
