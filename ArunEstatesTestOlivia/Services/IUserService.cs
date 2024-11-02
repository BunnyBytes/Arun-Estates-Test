using ArunEstatesTestOlivia.Models;

namespace ArunEstatesTestOlivia.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUser(User user);
        Task<User?> AuthenticateUser(string? username, string? password);
        Task<User?> UpdateUser(int id, User updatedUser);
    }
}
