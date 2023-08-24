using AuthenticationAPI.DatabaseContext;
using AuthenticationAPI.Entities;

namespace AuthenticationAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext context;

        public UserRepository(UserContext context)
        {
            this.context = context;
        }

        public Task<User> GetUserByUserNameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<List<User>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}