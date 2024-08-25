using System.Security.Cryptography;

namespace Portfolio.Helpers
{
    public class CryptPass
    {
        public static string HashPassword(string password, byte[] salt)
        {
            const int iterations = 10000;
            const int hashSize = 32; // 256 bits

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(hashSize);
                byte[] hashBytes = new byte[hashSize + salt.Length];
                Array.Copy(salt, 0, hashBytes, 0, salt.Length);
                Array.Copy(hash, 0, hashBytes, salt.Length, hash.Length);

                return Convert.ToBase64String(hashBytes);
            }
        }

        public static byte[] GenerateSalt()
        {
            const int saltSize = 16; // 128 bits
            byte[] salt = new byte[saltSize];
            RandomNumberGenerator.Fill(salt);
            return salt;
        }

        public static bool VerifyHash(string inputPassword, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            const int saltSize = 16;
            byte[] salt = new byte[saltSize];
            Array.Copy(hashBytes, 0, salt, 0, saltSize);

            string newHash = HashPassword(inputPassword, salt);
            return newHash == storedHash;
        }
    }
}
