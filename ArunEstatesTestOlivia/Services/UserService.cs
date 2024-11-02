using ArunEstatesTestOlivia.Data;
using ArunEstatesTestOlivia.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ArunEstatesTestOlivia.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> RegisterUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<User?> AuthenticateUser(string? username, string? password)
        {
            // For simplicity, we’re directly comparing passwords here. In production, use hashed passwords!
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }

        public async Task<User?> UpdateUser(int id, User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            user.FullName = updatedUser.FullName;
            user.Email = updatedUser.Email;
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
