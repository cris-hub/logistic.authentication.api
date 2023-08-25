using AuthenticationAPI.DatabaseContext;
using AuthenticationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextFactory context;

        public UserRepository(DbContextFactory context)
        {
            this.context = context;
        }

        public Task<User> GetUserByUserNameAndPassword(string username, string password, string contextName)
        {
            BaseContext db = context.GetContext(contextName);
            return db.Users.FirstOrDefaultAsync(c => c.Username == username && c.Password == password);

        }

        public Task<List<User>> GetUsersAsync(string contextName)
        {
            BaseContext db = context.GetContext(contextName);
            return db.Users.ToListAsync();

        }
    }
}