using System;
using System.Security.Cryptography;
using System.Text;

namespace Blog.Common
{
    public class HashOperation
    {
        public static string GetHashValue(string value)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            string hashedValue = Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(value)));
            return hashedValue;
        }
    }
}
