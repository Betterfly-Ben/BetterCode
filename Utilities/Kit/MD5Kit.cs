using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Betterfly.BetterCode
{
    public static class MD5Kit
    {
        public static string GetFileMD5(string filePath)
        {
            byte[] data;
            using (FileStream fs = new FileStream(filePath, FileMode.Open))
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    data = md5.ComputeHash(fs);
                }
            }

            return ByteArrToHex(data);
        }
        
        public static string GetMD5(string value)
        {
            string result = string.Empty;
            using (var md5 = new MD5CryptoServiceProvider())
            {
                result = GetMD5Hash(md5, value);
            }
            return result;
        }

        private static string ByteArrToHex(byte[] data)
        {
            var sBuilder = new StringBuilder();
            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }
            return sBuilder.ToString();
        }

        public static string GetMD5Hash(MD5 md5Hash, byte[] input)
        {
            byte[] data = md5Hash.ComputeHash(input);
            return ByteArrToHex(data);
        }

        public static string GetMD5Hash(MD5 md5Hash, string input)
        {
            return GetMD5Hash(md5Hash, Encoding.UTF8.GetBytes(input));
        }

        public static bool VerifyMD5(string input, string hash)
        {
            bool result = false;
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var hashOfInput = GetMD5Hash(md5, input);
                var comparer = StringComparer.OrdinalIgnoreCase;
                result = 0 == comparer.Compare(hashOfInput, hash);
            }

            return result;
        }
        
        public static bool VerifyMD5Hash(MD5 md5Hash, string input, string hash)
        {
            var hashOfInput = GetMD5Hash(md5Hash, input);
            var comparer = StringComparer.OrdinalIgnoreCase;
            return 0 == comparer.Compare(hashOfInput, hash);
        }
    }
}