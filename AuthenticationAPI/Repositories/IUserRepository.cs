using AuthenticationAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUserAsync(User user, string contextName);
        Task<User> GetUserByUserNameAndPasswordAsync(string username, string password, string contextName);
        Task<List<User>> GetUsersAsync(string contextName);
    }
}