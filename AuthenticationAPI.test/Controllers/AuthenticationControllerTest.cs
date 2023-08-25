using AuthenticationAPI.Controllers;
using AuthenticationAPI.Entities;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AuthenticationAPI.test.Controllers
{
    public class AuthenticationControllerTest
    {
        private const string username = "username";
        private const string password = "password";

        [Fact]
        public async void GetUsers()
        {
            Mock<IUserService> service = new();

            AuthenticationController controller = new(service.Object);

            OkObjectResult result = (OkObjectResult)await controller.GetUsers();

            result.StatusCode.Should().Be(200, "there is a error when we try to get the users");
        }

        [Fact]
        public async void AuthenticateOK()
        {
            Mock<IUserService> service = new();
            AuthenticationController controller = new(service.Object);
            AuthenticateRequest request = new(username, password);
            User user = new(username, password);
            AuthenticateResponse response = new(username);
            service.Setup(c => c.GetUserByUserNameAndPassword(username, password)).ReturnsAsync(user);
            service.Setup(c => c.AuthenticationAsync(request)).ReturnsAsync(response);


            OkObjectResult result = (OkObjectResult)await controller.Authenticate(request);
            AuthenticateResponse? actual = result.Value as AuthenticateResponse;

            string token = actual.Token;
            token.Should().NotBeEmpty();
            result.StatusCode.Should().Be(200, "thre is a error when we try to get the users");
        }   
        [Fact]
        public async void AuthenticateUnAuthorize()
        {
            Mock<IUserService> service = new();
            AuthenticationController controller = new(service.Object);
            AuthenticateRequest request = new(username, password);
            User user = new(username, password);
            AuthenticateResponse? response = null;
            service.Setup(c => c.GetUserByUserNameAndPassword(username, password)).ReturnsAsync(user);
            service.Setup(c => c.AuthenticationAsync(request)).ReturnsAsync(response);


            UnauthorizedObjectResult result = await controller.Authenticate(request) as UnauthorizedObjectResult;

            result.StatusCode.Should().Be(401, "there is a error when we try to get the users,user not found");
        }
    }
}
