using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace CodeSnippets.Security
{
    public static class CryptographySample
    {
        public static void Pbkdf2()
        {
            Console.WriteLine("输入一个密码");
            string password = Console.ReadLine();

            // generate a 128-bit salt using a secure PRNG(pseudo-random number generator)
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            var hashBytes = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                );
            string hashed = Convert.ToBase64String(hashBytes);
            Console.WriteLine($"Hashed: {hashed}");
        }
    }
}
