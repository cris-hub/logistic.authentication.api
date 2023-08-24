using AuthenticationAPI.Entities;

namespace AuthenticationAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserNameAndPassword(string username, string password);
        Task<List<User>> GetUsers();
    }
}