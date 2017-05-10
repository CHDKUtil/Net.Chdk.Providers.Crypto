using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Net.Chdk.Providers.Crypto
{
    sealed class HashProvider : IHashProvider
    {
        public string GetHashString(string filePath, string hashName)
        {
            using (var stream = File.OpenRead(filePath))
            {
                return GetHashString(stream, hashName);
            }
        }

        public string GetHashString(Stream stream, string hashName)
        {
            var hash = ComputeHash(stream, hashName);
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
    }
}
