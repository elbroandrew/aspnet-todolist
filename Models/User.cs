namespace ProductApi.Models;

public class User: BaseModel
{
    public int Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    
    // список задач пользователя
    public ICollection<TodoTask> Tasks { get; set; } = new List<TodoTask>();
}