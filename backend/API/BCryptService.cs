using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
{
    public static class BCryptService
    {
        public static bool CheckPassword(string textPassword, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(textPassword, hashPassword);
        }

        public static string HashPassword(string textPassword)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(12);
            var result = BCrypt.Net.BCrypt.HashPassword(textPassword, salt);
            return result;
        }
    }
}
