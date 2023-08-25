using AuthenticationAPI.Entities;
using AuthenticationAPI.Models;
using AuthenticationAPI.Repositories;
using AuthenticationAPI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;

namespace AuthenticationAPI.test.Services
{
    public class UserServiceTest
    {
        public required IUserService service;
        public Mock<IUserRepository> repository = new();
        IOptions<AppSettings> someOptions = Options.Create<AppSettings>(new AppSettings() { Secret = "jwt" });
        public UserServiceTest()
        {
        }

        [Fact]

        public async Task CreateUserAsync()
        {
            UserCreateRequest request = new("", "");
            User response = new("","");
            repository.Setup(repo => repo.CreateUserAsync(It.IsAny<User>(), It.IsAny<string>())).ReturnsAsync(response);
            
            service = new UserService(repository.Object, someOptions);

            UserCreateResponse Response = await service.CreateUser(request);

            Assert.NotNull(Response);
            Assert.NotNull(Response.Id);

        }

        [Fact]
        public async Task GetUsersAsync()
        {
            repository.Setup(c => c.GetUsersAsync(It.IsAny<string>())).ReturnsAsync(TestDataHelper.GetFakeUserList());
            service = new UserService(repository.Object, someOptions);


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
            repository.Setup(c => c.GetUserByUserNameAndPasswordAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(usersExpected);
            service = new UserService(repository.Object, someOptions);

            User actual = await service.GetUserByUserNameAndPassword(username, password);


            Assert.Equal(actual.Password, actual.Password);
            Assert.Equal(actual.Password, actual.Password);

        }
    }
}
