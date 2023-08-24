using System.Text.Json.Serialization;

namespace AuthenticationAPI.Entities
{
    public class User
    {
        public string Username { get; internal set; }

        [JsonIgnore]
        public string Password { get; internal set; }

        public User(string username, string password)
        {
            Username = username;
            Username = password;
        }
    }
}