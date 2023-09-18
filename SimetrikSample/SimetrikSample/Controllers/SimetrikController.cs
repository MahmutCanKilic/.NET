using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace SimetrikSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimetrikController : ControllerBase
    {
        public string encryptedString;
        [HttpPost(nameof(Sifrele))]
        public IActionResult Sifrele(string veri)
        {
            encryptedString = EncryptString(GenerateRandomKey(), veri);
            //encryptedString = EncryptString("b14ca5898a4e4133bbce2ea2315a2916", veri);
            return Ok(encryptedString);
        }

        [HttpGet(nameof(DeSifrele))]
        public IActionResult DeSifrele()
        {
            return Ok(DecryptString(GenerateRandomKey(), encryptedString));
        }
        public static string GenerateRandomKey()
        {
            //using RandomNumberGenerator rng = RandomNumberGenerator.Create();

            //byte[] data = new byte[32];
            //rng.GetBytes(data);

            //var str = Encoding.UTF8.GetString(data);
            //return str;

            string guid = Guid.NewGuid().ToString("N");
            return guid;
        }
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
