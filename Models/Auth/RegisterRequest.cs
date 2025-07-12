using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models.Auth;

public class RegisterRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string ConfirmPassword { get; set; }
    
}