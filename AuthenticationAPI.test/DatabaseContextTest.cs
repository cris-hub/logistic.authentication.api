using AuthenticationAPI.DatabaseContext;
using AuthenticationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.test
{
    public class DatabaseContextTest
    {
        public DbContext context = new UserContext();
        [Fact]
        public void GetUserById()
        {
            DbSet<User> users = ((UserContext)context).User;

            Assert.NotNull(users);
            Assert.NotNull(context);

        }
    }
}
