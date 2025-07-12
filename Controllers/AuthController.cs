using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Services;
using ProductApi.Models.Auth;


namespace ProductApi.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        if (registerRequest.Password != registerRequest.ConfirmPassword)
        {
            return BadRequest();
        }
        
        
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var tokenResponse = await _authService.Authenticate(model);
        if (tokenResponse == null)
            return Unauthorized();

        return Ok(tokenResponse);
    }

    [HttpGet("test")]
    [Authorize]
    public IActionResult TestAuth()
    {
        return Ok(new { Message = "Authenticated!" });
    }
}