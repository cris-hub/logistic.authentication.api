namespace AuthenticationAPI.Models
{
    public class UserCreateRequest
    {
        public UserCreateRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; }
        public string Password { get; }
    }
}