using AuthenticationAPI.Entities;

namespace AuthenticationAPI.Models
{
    public class AuthenticateResponse
    {
        public string Username { get; }
        public User User { get; }
        public string Token { get; }

        public AuthenticateResponse(string username) => this.Username = username;

        public AuthenticateResponse(User user, string token)
        {
            this.User = user;
            this.Username = user.Username;
            Token = token;
        }

    }
}