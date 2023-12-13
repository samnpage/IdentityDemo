using IdentityDemo.Models.User;

namespace IdentityDemo.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
    Task<bool> LoginAsync(UserLogin model);
    Task LogoutAsync();
}