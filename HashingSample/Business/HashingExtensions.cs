using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class HashingExtensions
    {
        public static string GetMd5(this string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string md5Password = Convert.ToBase64String(md5.ComputeHash(Encoding.UTF8.GetBytes(text)));
            return md5Password;
        }
    }
}
