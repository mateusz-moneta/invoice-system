using InvoiceSystemAPI.Requests;
using InvoiceSystemAPI.Services.Abstracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystemAPI.Controllers
{
    [ApiController]
    [Route("/api/users")]
    [Authorize]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) 
        { 
            _userService = userService;
        }
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="createUserRequest">The details of the user to be created.</param>
        /// <returns>An asynchronous task that represents the operation, with the created user.</returns>
        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            await _userService.CreateUserAsync(createUserRequest);
            return Ok();
        }
    }
}