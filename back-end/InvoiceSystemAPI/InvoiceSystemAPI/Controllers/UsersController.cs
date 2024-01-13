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

        [HttpPost]
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
        }
    }
}