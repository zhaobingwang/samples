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
            var subkey = KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                );
            string hashed = Convert.ToBase64String(subkey);
            Console.WriteLine($"Hashed: {hashed}");
        }

        public static void MockUserLogin()
        {
            Console.WriteLine("输入一个密码");
            string password = Console.ReadLine();
            using (var rng = RandomNumberGenerator.Create())
            {
                var hashed = HashPassword(password, rng, KeyDerivationPrf.HMACSHA256, 10000, 128 / 8, 256 / 8);
                Console.WriteLine(Convert.ToBase64String(hashed));
                Console.WriteLine("*".PadRight(50, '*'));
                var isCorrect = VerifyHashedPassword(hashed, "12345", out int iterCount);
                Console.WriteLine($"IsCorrect：{isCorrect},IterCount:{iterCount}");
            }
        }

        public static byte[] HashPassword(string password, RandomNumberGenerator rng, KeyDerivationPrf prf, int iterCount, int saltSize, int numBytesRequested)
        {
            byte[] salt = new byte[saltSize];
            rng.GetBytes(salt);
            byte[] subKey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

            var outputBytes = new byte[13 + salt.Length + subKey.Length];
            outputBytes[0] = 0x01;
            WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
            WriteNetworkByteOrder(outputBytes, 5, (uint)iterCount);
            WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subKey, 0, outputBytes, 13 + saltSize, subKey.Length);
            return outputBytes;
        }

        public static bool VerifyHashedPassword(byte[] hashedPassword, string password, out int iterCount)
        {
            iterCount = default;
            try
            {
                // 读取头信息
                KeyDerivationPrf prf = (KeyDerivationPrf)ReadNetworkByteOrder(hashedPassword, 1);
                iterCount = (int)ReadNetworkByteOrder(hashedPassword, 5);
                int saltLength = (int)ReadNetworkByteOrder(hashedPassword, 9);

                // 读取盐: 必须>=128 bits
                if (saltLength < 128 / 8)
                {
                    return false;
                }
                byte[] salt = new byte[saltLength];
                Buffer.BlockCopy(hashedPassword, 13, salt, 0, salt.Length);

                // 读取subkey，必须>=128 bits
                int subkeyLength = hashedPassword.Length - 13 - salt.Length;
                if (subkeyLength < 128 / 8)
                {
                    return false;
                }
                byte[] expectedSubkey = new byte[subkeyLength];
                Buffer.BlockCopy(hashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

                // 对输入的密码进行hash并验证
                byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, subkeyLength);
                return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);
                //#if NETSTANDARD2_0
                //                return ByteArraysEqual(actualSubkey, expectedSubkey);
                //#elif NETCOREAPP
                //                return CryptographicOperations.FixedTimeEquals(actualSubkey, expectedSubkey);
                //#else
                //#error Update target frameworks
                //#endif
            }
            catch
            {
                return false;
            }
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }
    }
}
