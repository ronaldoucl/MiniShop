using MiniShop.Data;
using MiniShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace MiniShop.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public User? CurrentUser { get; private set; }

        public event Action? OnChange;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        // ------------------------
        // User registration with email uniqueness check and password hashing
        // ------------------------
        public async Task<bool> RegisterAsync(string email, string password)
        {
            try
            {
                email = email.Trim().ToLower();

                if (await _context.Users.AnyAsync(u => u.Email.ToLower() == email))
                    return false;

                var user = new User
                {
                    Email = email,
                    PasswordHash = HashPassword(password)
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        // ------------------------
        // Login hashing and verification
        // ------------------------
        public async Task<bool> LoginAsync(string email, string password)
        {
            try
            {
                email = email.Trim().ToLower();
                var hash = HashPassword(password);

                var user = await _context.Users
                    .FirstOrDefaultAsync(u =>
                        u.Email.ToLower() == email &&
                        u.PasswordHash == hash);

                if (user == null)
                    return false;

                CurrentUser = user;
                NotifyStateChanged();
                return true;
            }
            catch
            {
                return false;
            }
        }

        // ------------------------
        // LOGOUT
        // ------------------------
        public void Logout()
        {
            CurrentUser = null;
            NotifyStateChanged();
        }

        // ------------------------
        // Password Handling using SHA256 
        // ------------------------
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }
    }
}
