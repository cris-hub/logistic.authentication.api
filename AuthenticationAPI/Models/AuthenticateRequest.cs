namespace AuthenticationAPI.Models
{
    public class AuthenticateRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AuthenticateRequest(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}