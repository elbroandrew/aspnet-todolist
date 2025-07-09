using System.ComponentModel.DataAnnotations;

public class LoginModel
{
    [Required] public required string Username { get; set; }
    [Required] public required string Password { get; set; }
}
