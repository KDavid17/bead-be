using BeadBE.Application.Common.Interfaces.Services;
using System.Security.Cryptography;

namespace BeadBE.Infrastructure.Services
{
    public class HashService : IHashService
    {
        public void CreateHash(string password, out byte[] hash, out byte[] salt)
        {
            using HMACSHA512 hmac = new();

            salt = hmac.Key;
            hash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        public bool VerifyCredentials(string password, byte[] hash, byte[] salt)
        {
            using HMACSHA512 hmac = new(salt);

            byte[] computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            return hash.SequenceEqual(computedHash);
        }
    }
}
