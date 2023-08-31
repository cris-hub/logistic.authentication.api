using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AuthenticationAPI.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        [Required]
        public string Username { get; set; }

        [JsonIgnore]
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
        public string DocumentId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        public User()
        {
            
        }


        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}