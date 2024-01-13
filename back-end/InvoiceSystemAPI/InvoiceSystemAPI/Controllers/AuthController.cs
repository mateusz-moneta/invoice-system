using InvoiceSystemAPI.DTO;
using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Requests;
using InvoiceSystemAPI.Services;
using InvoiceSystemAPI.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.SecurityTokenService;

namespace InvoiceSystemAPI.Controllers
{
    /// <summary>
    /// Controller responsible for handling authentication-related operations.
    /// </summary>
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="authService">The authentication service.</param>
        /// <param name="userService">The user service.</param>
        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }
        /// <summary>
        /// Authenticate a user.
        /// </summary>
        /// <remarks>
        /// This endpoint is used to authenticate a user based on provided credentials.
        /// </remarks>
        /// <param name="loginRequest">The user's login credentials.</param>
        /// <returns>An asynchronous task that represents the operation, with the generated authentication token.</returns>
        /// <response code="200">Returns the authentication token upon successful login.</response>
        /// <response code="400">Returns a BadRequestException if the user login or password is incorrect.</response>
        [HttpPost]
        [ProducesResponseType(typeof(LoginDTO), 200)]
        [ProducesResponseType(400)]
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
