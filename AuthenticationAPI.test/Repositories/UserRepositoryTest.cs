using AuthenticationAPI.DatabaseContext;
using AuthenticationAPI.Entities;
using AuthenticationAPI.Repositories;
using AuthenticationAPI.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace AuthenticationAPI.test.Repositories
{
    public class UserRepositoryTest
    {
        private const string table = "users";
        public required IUserService service;
        public required IUserRepository repository;
        public Mock<IDbContextFactory> factory = new Mock<IDbContextFactory>();
        public Mock<BaseContext> basecontext = new Mock<BaseContext>();


        [Fact]
        public async Task GetUsersAsync()
        {

            factory.Setup(c => c.GetContext(It.IsAny<string>())).Returns(basecontext.Object);
            basecontext.Setup<DbSet<User>>(x => x.Users).ReturnsDbSet(TestDataHelper.GetFakeUserList());

            repository = new UserRepository(factory.Object);


            IEnumerable<User> actual = (await repository.GetUsersAsync(table));
            

            Assert.NotNull(actual);
            Assert.True(actual.Any());


        }

        [Fact]
        public async Task GetUserByUserNameAndPasswordAsync()
        {
            string password = "password";
            string username = "username";
            User usersExpected = new(username, password);
            
            factory.Setup(c => c.GetContext(It.IsAny<string>())).Returns(basecontext.Object);
            basecontext.Setup<DbSet<User>>(x => x.Users).ReturnsDbSet(TestDataHelper.GetFakeUserList());

            repository = new UserRepository(factory.Object);

            User actual = await repository.GetUserByUserNameAndPasswordAsync(username, password, table);



            Assert.Equal(usersExpected.Password, actual.Password);
            Assert.Equal(usersExpected.Username, actual.Username);
        }
    }
}
