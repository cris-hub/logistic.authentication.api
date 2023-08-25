using AuthenticationAPI.Controllers;
using AuthenticationAPI.Entities;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using Autofac.Core;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AuthenticationAPI.test.Controllers
{
    public class SignUpControllerTest
    {
        private const string username = "uno";
        private const string password = "uno";
        Mock<IUserService> service = new();
        OkObjectResult result;
        public SignUpController controller;
        public SignUpControllerTest()
        {
            controller = new SignUpController(service.Object);
        }

        [Fact]
        public async Task SignUpNewUserAsync()
        {
            UserCreateRequest request = new(username, password);
            UserCreateResponse response = new UserCreateResponse() { 
            Id = "sda"
            };

            service.Setup(c => c.CreateUser(It.IsAny<UserCreateRequest>())).ReturnsAsync(response);

            result = (OkObjectResult)await controller.SignUp(request);
            UserCreateResponse actual = result.Value as UserCreateResponse;
            
            ((OkObjectResult)result).StatusCode.Should().Be(200);

;        }
    }
}
