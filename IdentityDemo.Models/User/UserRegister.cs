using System.ComponentModel.DataAnnotations;

namespace IdentityDemo.Models.User;

public class UserRegister
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(10, ErrorMessage = "Must be between 4 and 10 characters", MinimumLength = 3)]
    public string Name { get; set; }

    [Required(ErrorMessage = "Username is required")]
    [StringLength(10, ErrorMessage = "Must be between 4 and 10 characters", MinimumLength = 3)]
    public string UserName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required(ErrorMessage = "Confirm password is required")]
    [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}