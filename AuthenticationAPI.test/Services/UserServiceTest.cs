using AuthenticationAPI.DatabaseContext;
using AuthenticationAPI.Entities;
using AuthenticationAPI.Repositories;
using AuthenticationAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace AuthenticationAPI.test.Services
{
    public class UserServiceTest
    {
        public required IUserService service;
        public Mock<IUserRepository> repository = new();


        [Fact]
        public async Task GetUsersAsync()
        {
            repository.Setup(c => c.GetUsersAsync(It.IsAny<string>())).ReturnsAsync(TestDataHelper.GetFakeUserList());
            service = new UserService(repository.Object);


            IEnumerable<User> actual = (await service.GetUsersAsync());
            

            Assert.NotNull(actual);
            Assert.True(actual.Any());

        }

        [Fact]
        public async Task GetUserByUserNameAndPasswordAsync()
        {
            string password = "password";
            string username = "username";
            User usersExpected = new(username, password);
            repository.Setup(c => c.GetUserByUserNameAndPassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(usersExpected);
            service = new UserService(repository.Object);

            User actual = await service.GetUserByUserNameAndPassword(username, password);


            Assert.Equal(actual.Password, actual.Password);
            Assert.Equal(actual.Password, actual.Password);

        }
    }
}
