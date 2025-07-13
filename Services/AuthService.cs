using Microsoft.EntityFrameworkCore;
using ProductApi.Data;


namespace ProductApi.Services;

public class AuthService
{
    private readonly AppDbContext _context;
    private readonly JwtHelper _jwtHelper;

    public AuthService(AppDbContext context, JwtHelper jwtHelper)
    {
        _context = context;
        _jwtHelper = jwtHelper;
    }

    public async Task<TokenResponse?> Authenticate(LoginModel model)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == model.Username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            return null;

        return new TokenResponse
        {
            Token = _jwtHelper.GenerateToken(user),
            // Expires = DateTime.Now.AddMinutes(_jwtHelper.GetTokenExpiryMinutes())
        };
    }
}