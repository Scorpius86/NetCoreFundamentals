using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace NetCore.Fundametals.Security.Data
{
    public static class StringExtensions
    {
        public static string Sha256(this string input)
        {
            using (var sha = SHA256.Create())
            {
                Byte[] bytes = Encoding.UTF8.GetBytes(input);
                Byte[] hash = sha.ComputeHash(bytes);
                string stringEncrypt = Convert.ToBase64String(hash);

                return stringEncrypt;
            }
        }
    }
}
