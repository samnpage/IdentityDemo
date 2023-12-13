using IdentityDemo.Models.User;
using Microsoft.AspNetCore.Identity;

namespace IdentityDemo.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
    Task<bool> LoginAsync(UserLogin model);
    Task LogoutAsync();
}