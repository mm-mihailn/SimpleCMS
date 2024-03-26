using SimpleCMS.Data.Models;

namespace SimpleCMS.Business.Services.Interfaces;

public interface IUsersService
{
    Task<IEnumerable<User>> GetUsersAsync();
    Task DeleteAsync(User user);
    Task<User?> GetUserByIdAsync(string id);
    Task<User?> GetUserByEmail(string email);
    Task<User> AddUser(User user);
    Task<User> FindAsync(string id);
    void UpdateUser(User user);
    Task<IEnumerable<User>> GetYourData();
}