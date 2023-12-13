using IdentityDemo.Data;
using IdentityDemo.Data.Entities;
using IdentityDemo.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityDemo.Services.User;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;

    public UserService(ApplicationDbContext context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> LoginAsync(UserLogin model)
    {
        var user = await _userManager.FindByNameAsync(model.UserName);
        if (user is null)
            return false;

        var isValidPassword = await _userManager.CheckPasswordAsync(user, model.Password);
        if (isValidPassword == false)
            return false;

        await _signInManager.SignInAsync(user, true);
        return true;
    }

    public async Task LogoutAsync() => await _signInManager.SignOutAsync();

    public async Task<bool> RegisterUserAsync(UserRegister model)
    {
        if (await UserExistsAsync(model.Email, model.UserName))
            return false;

        UserEntity user = new()
        {
            UserName = model.UserName,
            Email = model.Email
        };

        var createResult = await _userManager.CreateAsync(user, model.Password);
        return createResult.Succeeded;
    }

    private async Task<bool> UserExistsAsync(string email, string userName)
    {
        var normalizedEmail = _userManager.NormalizeEmail(email);
        var normalizedUserName = _userManager.NormalizeName(userName);

        return await _context.Users.AnyAsync(u => 
            u.NormalizedEmail == normalizedEmail ||
            u.NormalizedUserName == normalizedUserName
        );
    }
}