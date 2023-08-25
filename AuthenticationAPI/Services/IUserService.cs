using AuthenticationAPI.Entities;
using AuthenticationAPI.Models;
using AuthenticationAPI.test.Controllers;
using Azure.Core;

namespace AuthenticationAPI.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> AuthenticationAsync(AuthenticateRequest request);
        Task<User> GetById(int userId);
        Task<User> GetUserByUserNameAndPassword(string username, string password);
        Task<List<User>> GetUsersAsync();
    }
}