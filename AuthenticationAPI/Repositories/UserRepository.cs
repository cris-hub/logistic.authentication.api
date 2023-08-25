using AuthenticationAPI.DatabaseContext;
using AuthenticationAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContextFactory context;

        public UserRepository(IDbContextFactory context)
        {
            this.context = context;
        }


        public async Task<User> CreateUserAsync(User user, string contextName)
        {
            BaseContext db = context.GetContext(contextName);
            var userCreate = await db.AddAsync<User>(user);
            await db.SaveChangesAsync();
            return userCreate.Entity;
        }

        public Task<User> GetUserByUserNameAndPasswordAsync(string username, string password, string contextName)
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