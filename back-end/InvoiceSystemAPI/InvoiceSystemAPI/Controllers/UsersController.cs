using InvoiceSystemAPI.Requests;
using InvoiceSystemAPI.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystemAPI.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            await _userService.CreateUserAsync(createUserRequest);
            return Ok();
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserRequest registerUserRequest)
        {
            await _userService.RegisterUserAsync(registerUserRequest);
            return Ok();
        }
    }
}