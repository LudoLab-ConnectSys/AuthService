using AuthService.Models;
using AuthService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] LoginRequest loginModel)
        {
            var result = await _authService.Login(loginModel);

            if (result == null)
            {
                return Unauthorized();
            }

            return Ok(result);
        }


        [HttpPost("HashPassword")]
        //[Authorize(Policy = "AdminPolicy")]
        public async Task<ActionResult<string>> HashPassword([FromBody] HashPasswordRequest request)
        {
            var hashedPassword = await _authService.HashPassword(request.Password);
            return Ok(new { HashedPassword = hashedPassword });
        }
    }
}