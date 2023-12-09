using InvoiceSystemAPI.DTO;
using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Requests;
using InvoiceSystemAPI.Services;
using InvoiceSystemAPI.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.SecurityTokenService;

namespace InvoiceSystemAPI.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AurhController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public AurhController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<LoginDTO>> Login([FromBody] LoginRequest loginRequest)
        {
            User user = await _userService.GetUserAsync(loginRequest.UserName);
            if (user is null)
            {
                throw new BadRequestException("Bad user login or password");
            }

            string token = await _authService.GenerateTokenAsync(user, loginRequest.Password);
            return new LoginDTO
            {
                Token = token
            };

        }
    }
}
