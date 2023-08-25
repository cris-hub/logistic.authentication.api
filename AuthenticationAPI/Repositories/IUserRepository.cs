using AuthenticationAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByUserNameAndPassword(string username, string password, string contextName);
        Task<List<User>> GetUsersAsync(string contextName);
    }
}