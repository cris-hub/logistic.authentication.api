using AuthenticationAPI.Entities;
using AuthenticationAPI.Models;

namespace AuthenticationAPI.Services
{
    public interface IUserService
    {
        Task<AuthenticateResponse> AuthenticationAsync(AuthenticateRequest request);
        Task<UserCreateResponse> CreateUser(UserCreateRequest u);
        Task<User> GetById(int userId);
        Task<User> GetUserByUserNameAndPassword(string username, string password);
        Task<List<User>> GetUsersAsync();
    }
}