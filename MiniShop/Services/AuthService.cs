using MiniShop.Data;
using MiniShop.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace MiniShop.Services
{
    public class AuthService
    {
        private readonly AppDbContext _context;

        public User? CurrentUser { get; private set; }

        public event Action? OnChange;
        private readonly ProtectedSessionStorage _sessionStorage;

        public AuthService(AppDbContext context, ProtectedSessionStorage sessionStorage)
        {
            _context = context;
            _sessionStorage = sessionStorage;
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        /*
         * Registers a new user after validating email uniqueness
         * and stores the password as a hashed value.
         */
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

        /*
         * Validates user credentials, initializes the session if successful,
         * and returns true; otherwise returns false.
         */
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
                await _sessionStorage.SetAsync("userId", user.Id);
                NotifyStateChanged();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /*
         * Clears the current user session, removes it from storage, and notifies state changes.
         */
        public async Task LogoutAsync()
        {
            CurrentUser = null;
            await _sessionStorage.DeleteAsync("userId");
            NotifyStateChanged();
        }

        /*
         * Hashes the provided password using SHA256 and returns a Base64-encoded string.
         */
        private string HashPassword(string password)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(bytes);
        }

        /*
         * Restores the user session from storage and updates authentication state if found.
         */
        public async Task InitializeAsync()
        {
            try
            {
                var result = await _sessionStorage.GetAsync<int>("userId");

                if (result.Success)
                {
                    CurrentUser = await _context.Users.FindAsync(result.Value);
                    NotifyStateChanged();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[InitializeAsync] Error: {ex.Message}");
            }
        }
    }
}
