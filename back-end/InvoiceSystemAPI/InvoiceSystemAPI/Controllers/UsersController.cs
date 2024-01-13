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
        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="createUserRequest">The details of the user to be created.</param>
        /// <returns>An asynchronous task that represents the operation, with the created user.</returns>
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            await _userService.CreateUserAsync(createUserRequest);
            return Ok();
        }
        
        
        [HttpPost("{userId}/image")]
        public async Task<IActionResult> UploadUserImage(int userId, IFormFile imageFile)
        {
            try
            {
                await _userService.AddUserImageAsync(userId, imageFile);
                return Ok(new { message = "Image uploaded successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{userId}/image")]
        public async Task<IActionResult> DeleteUserImage(int userId)
        {
            try
            {
                await _userService.DeleteUserImageAsync(userId);
                return Ok(new { message = "Image deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserRequest registerUserRequest)
        {
            await _userService.RegisterUserAsync(registerUserRequest);
            return Ok();
        }
    }
}