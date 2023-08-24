using AuthenticationAPI.Entities;

namespace AuthenticationAPI.test.Entities
{

    public class UserTest
    {
        [Fact]
        public void Instantiation()
        {
            User user = new(username: "test", password: "test");

            Assert.NotNull(user.Username);
            Assert.Equal("test", user.Username);

            Assert.NotNull(user.Password);
            Assert.Equal("test", user.Password);
        }

    }
}
