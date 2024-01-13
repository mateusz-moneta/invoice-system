using InvoiceSystemAPI.Configuration;
using InvoiceSystemAPI.Models;
using InvoiceSystemAPI.Requests;
using InvoiceSystemAPI.Services.Abstracts;
using InvoiceSystemAPI.Tools.Abstracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace InvoiceSystemAPI.Services
{
    public class UserService: IUserService
    {
        private readonly AuthenticationConfiguration _authenticationConfiguration;
        private readonly DataContext _applicationDbContext;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IPasswordHasher passwordHasher, DataContext dataContext, 
            AuthenticationConfiguration authConfiguraion)
        {
            _applicationDbContext = dataContext;
            _passwordHasher = passwordHasher;
            _authenticationConfiguration = authConfiguraion;
        }

        public async Task CreateUserAsync(CreateUserRequest createUserRequest)
        {
            using (IDbContextTransaction transaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {
                    byte[] salt = _passwordHasher.RandomSalt(_authenticationConfiguration.SaltSize);
                    string hash = _passwordHasher.Hash(createUserRequest.Password, salt);

                    User user = new User
                    {
                        Email = createUserRequest.Email,
                        UserName = createUserRequest.UserName,
                        Password = hash,
                        Salt = salt,
                        Name = createUserRequest.Name,
                        Surname = createUserRequest.Surname,
                    };
                    _applicationDbContext.Users.Add(user);
                    await _applicationDbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("User create error");
                }
            }
        }

        public async Task CreateUserAsync(User user)
        {
            using (IDbContextTransaction transaction = _applicationDbContext.Database.BeginTransaction())
            {
                try
                {
                    user.Salt = _passwordHasher.RandomSalt(_authenticationConfiguration.SaltSize);
                    user.Password = _passwordHasher.Hash(user.Password, user.Salt);

                    _applicationDbContext.Users.Add(user);
                    await _applicationDbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw ex;
                    //throw new Exception("User create error");
                }
            }
        }

        public async Task RegisterUserAsync(RegisterUserRequest registerUserRequest)
        {
            using (IDbContextTransaction transaction = _applicationDbContext.Database.BeginTransaction())
            {
                if (await ExistsUserAsync(registerUserRequest.UserName))
                {
                    throw new Exception("Użytkownik o podanej nazwie już istnieje");
                }

                try
                {
                    byte[] salt = _passwordHasher.RandomSalt(_authenticationConfiguration.SaltSize);
                    string hash = _passwordHasher.Hash(registerUserRequest.Password, salt);

                    User user = new User
                    {
                        Email = registerUserRequest.Email,
                        UserName = registerUserRequest.UserName,
                        Name = registerUserRequest.UserName,
                        Surname = registerUserRequest.Surname,
                        Password = hash,
                        Salt = salt,
                    };

                    _applicationDbContext.Users.Add(user);
                    await _applicationDbContext.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception("Błąd podczas rejestracji użytkownika");
                }
            }
        }

        public async Task<bool> ExistsUserAsync(string userName)
        {
            User user = await GetUserAsync(userName);
            return user is not null;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _applicationDbContext.Users.ToListAsync();
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _applicationDbContext.Users
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserAsync(string userName)
        {
            return await _applicationDbContext.Users
                .FirstOrDefaultAsync(x => x.UserName == userName);
        }
        
        public async Task AddUserImageAsync(int userId, IFormFile imageFile)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var userDirectory = Path.Combine("media/images", user.Id.ToString());
            if (!Directory.Exists(userDirectory))
            {
                Directory.CreateDirectory(userDirectory);
            }

            var fileName = Path.GetFileName(imageFile.FileName);
            var uploadPath = Path.Combine(userDirectory, fileName);

            using (var fileStream = new FileStream(uploadPath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }

            user.ImagePath = Path.Combine("media/images", user.Id.ToString(), fileName);

            _applicationDbContext.Users.Update(user);
            await _applicationDbContext.SaveChangesAsync();
        }
        
        public async Task DeleteUserImageAsync(int userId)
        {
            var user = await _applicationDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            if (!string.IsNullOrEmpty(user.ImagePath) && File.Exists(user.ImagePath))
            {
                File.Delete(user.ImagePath);
                user.ImagePath = null;
                _applicationDbContext.Users.Update(user);
                await _applicationDbContext.SaveChangesAsync();
            }
        }
        
    }
    
    
}
