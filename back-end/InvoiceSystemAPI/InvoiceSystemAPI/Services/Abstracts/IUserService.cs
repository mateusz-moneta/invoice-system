using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Requests;

namespace InvoiceSystemAPI.Services.Abstracts
{
    public interface IUserService
    {
        Task CreateUserAsync(CreateUserRequest createUserRequest);
        Task CreateUserAsync(User user);
        Task<bool> ExistsUserAsync(string login);
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserAsync(int id);
        Task<User> GetUserAsync(string login);
        Task AddUserImageAsync(int userId, IFormFile imageFile);
        Task DeleteUserImageAsync(int userId);
        Task RegisterUserAsync(RegisterUserRequest user);
    }
}
