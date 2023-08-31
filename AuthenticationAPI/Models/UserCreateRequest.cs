namespace AuthenticationAPI.Models
{
    public class UserCreateRequest
    {


        public UserCreateRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }
        public UserCreateRequest()
        {
            
        }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public string Name { get; set; }
        public string DocumentId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Username { get; set; }
    }
}