using Microsoft.AspNetCore.Identity;
namespace ExpenseAppAPI.Helpers
{
    public static class PasswordHelper
    {
        private static PasswordHasher<string> _passwordHasher = new PasswordHasher<string>();

        // Method to Convert Normal to encoded format password
        public static string HashPassword(string password)
        {
            return _passwordHasher.HashPassword(null, password);
        }

        // Method to verify password by giving hashed password and provided password
        public static bool VerifyPassword(string hashedPassword, string providedPassword)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, providedPassword);
            return result == PasswordVerificationResult.Success;
        }
    }
}
