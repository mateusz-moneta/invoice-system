using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Seeds.Abstracts;
using InvoiceSystemAPI.Services.Abstracts;

namespace InvoiceSystemAPI.Seeds
{
    public class UserDataGenerator : IDataGenerator
    {
        private static readonly User[] _usersData =
        {
            new User
            {
                UserName = "admin",
                Password = "admin",
                Email = "admin@admin.com",
                Name = "Administrator",
                Surname = "Administrator",
            },
            new User
            {
                UserName = "joe",
                Password = "joedoe123",
                Email = "joedoe@email.com",
                Name = "Joe",
                Surname = "Doe",
            },
        };

        private readonly IUserService _userService;

        public UserDataGenerator(IUserService usersService)
        {
            _userService = usersService;
        }

        public async Task SeedAsync()
        {
            foreach (User user in _usersData)
            {
                bool exists = await _userService.ExistsUserAsync(user.UserName);
                if (!exists)
                {
                    await _userService.CreateUserAsync(user);
                }
            }
        }
    }
}
