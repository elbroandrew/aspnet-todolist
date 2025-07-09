using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
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