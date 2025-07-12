using ProductApi.Models;

namespace ProductApi.Repositories;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);
    
    Task<User> GetByUsernameAsync(string username);
    
    Task CreateAsync(User user);
}