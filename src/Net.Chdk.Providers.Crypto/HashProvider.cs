using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Net.Chdk.Providers.Crypto
{
    sealed class HashProvider : IHashProvider
    {
        public string GetHashString(Stream stream, string hashName)
        {
            var hash = ComputeHash(stream, hashName);
            return GetHashString(hash);
        }

        public string GetHashString(byte[] buffer, string hashName)
        {
            var hash = ComputeHash(buffer, hashName);
            return GetHashString(hash);
        }

        private static string GetHashString(byte[] hash)
        {
            var sb = new StringBuilder(hash.Length * 2);
            for (int i = 0; i < hash.Length; i++)
                sb.Append(hash[i].ToString("x2"));
            return sb.ToString();
        }

        private static byte[] ComputeHash(Stream stream, string hashName)
        {
            return HashAlgorithm.Create(hashName)
                .ComputeHash(stream);
        }

        private static byte[] ComputeHash(byte[] buffer, string hashName)
        {
            return HashAlgorithm.Create(hashName)
                .ComputeHash(buffer);
        }
    }
}
