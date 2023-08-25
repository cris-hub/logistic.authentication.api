using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService UserService;

        public AuthenticationController(IUserService @object)
        {
            UserService = @object;
        }
        [HttpPost]
        public async Task<IActionResult> Authenticate(AuthenticateRequest request)
        {
            var response = await UserService.AuthenticationAsync(request);

            if (response == null)
                return Unauthorized("User not found");

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers() => Ok(await UserService.GetUsersAsync());
    }
}