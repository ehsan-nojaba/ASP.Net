using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FrameWork.Services;
using Microsoft.Extensions.Options;

namespace FrameWork
{
    public class PasswordHasher:IPasswordHasher
    {
        private HashingOptions options;
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit

        public PasswordHasher(IOptions<HashingOptions> options)
        {
            this.options = options.Value;
        }

        public string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, SaltSize, options.Iterations, HashAlgorithmName.SHA256))
            {
                var key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                var salt = Convert.ToBase64String(algorithm.Salt);

                return $"{options.Iterations}.{salt}.{key}";
            }
        }

        public (bool Verified, bool NeedsUpgrade) Check(string hash, string password)
        {
            var parts = hash.Split('.', 3);
            if (parts.Length != 3)
            {
                return (false, false);
            }
            var iterations = Convert.ToInt32(parts[0]);
            var salt = Convert.FromBase64String(parts[1]);
            var key = Convert.FromBase64String(parts[2]);
            var needsUpgrade = iterations != options.Iterations;
            using (var algorithm = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256))
            {
                var keyToCheck = algorithm.GetBytes(KeySize);

                var verified = keyToCheck.SequenceEqual(key);

                return (verified, needsUpgrade);
            }
        }
    }
}