using AuthenticationAPI.DatabaseContext;
using AuthenticationAPI.Entities;
using AuthenticationAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AuthenticationAPI.test.Services
{
    public class UserServiceTest
    {
        public IUserService user = new UserService();
        public Mock<UserContext> dbContext = new();
        public required IUserRepository repository;

        public UserServiceTest()
        {
            repository = new UserRepository(dbContext.Object);
        }

        [Fact]
        public async Task GetUsersAsync()
        {
            List<User> usersExpected = new();

            dbContext.Setup(db => db.User.ToListAsync(It.IsAny<CancellationToken>())).ReturnsAsync(usersExpected);

            List<User> actual = await repository.GetUsers();


            Assert.Equal(usersExpected, actual);
            Assert.NotNull(user);
        }

        [Fact]
        public async Task GetUserByUserNameAndPasswordAsync()
        {
            string password = "password";
            string username = "username";

            User usersExpected = new(username, password);


            dbContext.Setup(db => db.User.FirstOrDefaultAsync(It.IsAny<CancellationToken>())).ReturnsAsync(usersExpected);

            User actual = await repository.GetUserByUserNameAndPassword(username, password);


            Assert.Equal(usersExpected, actual);
            Assert.NotNull(user);
        }
    }
}
