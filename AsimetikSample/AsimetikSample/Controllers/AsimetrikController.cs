using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;

namespace AsimetikSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsimetrikController : ControllerBase
    {
        

        [HttpPost(nameof(EncryptPassword))]
        public IActionResult EncryptPassword(string password)
        {
            byte[] convertedP = Encoding.UTF8.GetBytes(password);
           var bytePassword = EncryptData(convertedP);
            var base64Password = Convert.ToBase64String(bytePassword);
            return Ok(base64Password);
        }

        [HttpPost(nameof(DecryptPassword))]
        public IActionResult DecryptPassword(string base64Password)
        {
            var bytePassword = Convert.FromBase64String(base64Password);
            string password = DecryptData(bytePassword);
            return Ok(password);
        }
        public byte[] EncryptData(byte[] password)
        {
            using (RSA rsa = RSA.Create())
            {
                RSAParameters publicKey = rsa.ExportParameters(false);
                return rsa.Encrypt(password, RSAEncryptionPadding.Pkcs1);
            }
        }
        public string DecryptData(byte[] password)
        {
            using (RSA rsa = RSA.Create())
            {
                RSAParameters privateKey = rsa.ExportParameters(true);
                byte[] decryptedPassword = rsa.Decrypt(password, RSAEncryptionPadding.Pkcs1);
                return Encoding.UTF8.GetString(decryptedPassword);
            }
        }
    }
}
