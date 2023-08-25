using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AuthenticationAPI.Entities
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Username { get; set; }

        [JsonIgnore]
        [Required]
        public string Password { get; set; }


        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}