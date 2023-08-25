using AuthenticationAPI.Entities;

namespace AuthenticationAPI.test
{
    public class TestDataHelper
    {
        public static List<User> GetFakeUserList()
        {
            return new List<User>()
                {
                    new User("test","test"),
                    new User("username","password")
                };
        }
    }
}
