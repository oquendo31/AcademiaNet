using AcademiaNet.Shared.DTOs;
using AcademiaNet.Shared.Entites;
using Microsoft.AspNetCore.Identity;

namespace AcademiaNet.Backend.UnitsOfWork.Interfaces;

public interface IUsersUnitOfWork
{
    /// <summary>
    ///
    /// </summary>
    /// <param name="user"></param>
    /// <param name="currentPassword"></param>
    /// <param name="newPassword"></param>
    /// <returns></returns>
    Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);

    /// <summary>
    ///
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>

    Task<IdentityResult> UpdateUserAsync(User user);

    Task<User> GetUserAsync(Guid userId);

    Task<string> GenerateEmailConfirmationTokenAsync(User user);

    Task<IdentityResult> ConfirmEmailAsync(User user, string token);

    Task<SignInResult> LoginAsync(LoginDTO model);

    Task LogoutAsync();

    Task<User> GetUserAsync(string email);

    Task<IdentityResult> AddUserAsync(User user, string password);

    Task CheckRoleAsync(string roleName);

    Task AddUserToRoleAsync(User user, string roleName);

    Task<bool> IsUserInRoleAsync(User user, string roleName);
}