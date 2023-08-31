using AuthenticationAPI.Entities;
using AuthenticationAPI.Models;
using AuthenticationAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignUpController : ControllerBase
    {
        private IUserService @object;

        public SignUpController(IUserService @object)
        {
            this.@object = @object;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserCreateRequest u)
        {
            UserCreateResponse response = await @object.CreateUser(u);
            if (response == null)
                return BadRequest("User not register");
            return Ok(response);
        }
    }
}