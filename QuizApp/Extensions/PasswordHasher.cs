using System;
using System.Security.Cryptography;
using System.Text;

namespace QuizApp.Extensions
{
    public class PasswordHasher
    {
        public static string Get(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
