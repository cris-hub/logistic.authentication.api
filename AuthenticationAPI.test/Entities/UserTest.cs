using AuthenticationAPI.Entities;

namespace AuthenticationAPI.test.Entities
{

    public class UserTest
    {
        [Fact]
        public void Instantiation()
        {
            User user = new("test", "test");

            Assert.Equal("test", user.Username);

            Assert.Equal("test", user.Password);
        }

    }
}
