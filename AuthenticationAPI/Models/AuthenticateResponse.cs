using AuthenticationAPI.Entities;

namespace AuthenticationAPI.Models
{
    public class AuthenticateResponse
    {
        private readonly string username;
        private readonly User user;

        public AuthenticateResponse(string username) => this.username = username;

        public AuthenticateResponse(User user, string token)
        {
            this.user = user;
            Token = token;
        }

        public string Token { get; set; }
    }
}