using AuthenticationAPI.Entities;

namespace AuthenticationAPI.test.Controllers
{
    public class AuthenticateResponse
    {
        private string username;
        private User user;

        public AuthenticateResponse(string username) => this.username = username;

        public AuthenticateResponse(User user, string token)
        {
            this.user = user;
            Token = token;
        }

        public string Token { get; set; }
    }
}