using Microsoft.EntityFrameworkCore;
using MultiPage_ELearning_Platform1.Data;
using MultiPage_ELearning_Platform1.DTOs.UserDTOs;
using MultiPage_ELearning_Platform1.Models;
using MultiPage_ELearning_Platform1.Services.Interfaces;
using BCrypt.Net;

namespace MultiPage_ELearning_Platform1.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        // =========================
        // REGISTER USER (HASH PASSWORD)
        // =========================
        public async Task<UserResponseDto> RegisterAsync(RegisterUserDto dto)
        {
            // 🔐 HASH PASSWORD
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = hashedPassword, // ✅ hashed
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new UserResponseDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        // =========================
        // VERIFY PASSWORD (LOGIN USE)
        // =========================
        public bool VerifyPassword(string inputPassword, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(inputPassword, storedHash);
        }

        // =========================
        // GET USER BY ID
        // =========================
        public async Task<UserResponseDto?> GetByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return new UserResponseDto
            {
                UserId = user.UserId,
                FullName = user.FullName,
                Email = user.Email,
                CreatedAt = user.CreatedAt
            };
        }

        // =========================
        // UPDATE USER
        // =========================
        public async Task<bool> UpdateAsync(int id, UpdateUserDto dto)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            user.FullName = dto.FullName;
            user.Email = dto.Email;

            await _context.SaveChangesAsync();
            return true;
        }

        // =========================
        // DELETE USER
        // =========================
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        // =========================
        // GET ALL USERS
        // =========================
        public async Task<List<UserResponseDto>> GetAllAsync()
        {
            return await _context.Users
                .AsNoTracking() // ✅ performance improvement
                .Select(u => new UserResponseDto
                {
                    UserId = u.UserId,
                    FullName = u.FullName,
                    Email = u.Email,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();
        }
    }
}