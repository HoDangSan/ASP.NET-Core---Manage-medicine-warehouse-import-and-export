using System;
using System.Security.Cryptography;
using System.Text;

namespace MWIE.Encryption
{
    public class EncyptionMd5 : IEncyptionMd5
    {
        public string Encrypt(string toEncrypt, string password)
        {
            bool useHashing = true;
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);
 
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(password));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(password);
 
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;
 
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
 
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}