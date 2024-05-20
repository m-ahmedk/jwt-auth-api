using jwt_authentication.Helpers.Filters;
using jwt_authentication.Models;
using jwt_authentication.Models.RequestModel;
using jwt_authentication.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace jwt_authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService) {
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            user.UserId = 0; // create module identifier
            return Ok(await _userService.AddAndUpdateUser(user));
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] User userObj)
        {
            return Ok(await _userService.AddAndUpdateUser(userObj));
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateRequest authenticateRequest)
        {
            var response = await _userService.Authenticate(authenticateRequest);

            if (response == null)
                return NotFound(new { message = "Username or password is incorrect" });

            return Ok(response);
        }
    }
}
