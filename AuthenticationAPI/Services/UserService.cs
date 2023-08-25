using AuthenticationAPI.Entities;
using AuthenticationAPI.Models;
using AuthenticationAPI.Repositories;
using AuthenticationAPI.test.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationAPI.Services
{
    public class UserService : IUserService
    {
        private IUserRepository repository;
        private string Table = "users";

        private readonly AppSettings _appSettings;
        public UserService(IUserRepository repository) => this.repository = repository;

        public async Task<AuthenticateResponse> AuthenticationAsync(AuthenticateRequest request)
        {
            var user = await GetUserByUserNameAndPassword(request.Username, request.Password);
            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public Task<User> GetUserByUserNameAndPassword(string username, string password) => repository.GetUserByUserNameAndPassword(username, password, Table);

        public Task<List<User>> GetUsersAsync() => repository.GetUsersAsync(Table);

        public Task<User> GetById(int userId)
        {
            throw new NotImplementedException();
        }
    }
}