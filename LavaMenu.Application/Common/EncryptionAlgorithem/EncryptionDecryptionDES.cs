using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Common.EncryptionAlgorithem
{
    public static class EncryptionDecryptionDES
    {
        //this class use DES(Data Encryption Standard) for encrypt and decrypt data
        private static (byte[] key, byte[] iv) Generate(string secretKey)
        {

            // Generate a key using SHA256 hash function 
            byte[] CryptKey = new byte[8];
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(secretKey));
                //byte[] hash = System.Text.Encoding.UTF8.GetBytes(secretKey);
                Array.Copy(hash, CryptKey, 8);
            }

            // Generate a IV using SHA256 hash function
            byte[] CryptIv = new byte[8];
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(secretKey));
                //byte[] hash = System.Text.Encoding.UTF8.GetBytes(secretKey);

                Array.Copy(hash, CryptIv, 8);

            }
            return (CryptKey, CryptIv);
        }
        public static string EncryptStringDES(this string inputString, string secretKey)
        {
            byte[] encryptedData;
            var KeyAndIv = Generate(secretKey);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = KeyAndIv.key;
                des.IV = KeyAndIv.iv;

                ICryptoTransform encryptor = des.CreateEncryptor();

                byte[] inputBytes = Encoding.UTF8.GetBytes(inputString);
                encryptedData = encryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            }

            return Convert.ToBase64String(encryptedData);
        }

        public static string DecryptStringDES(this string inputString, string secretKey)
        {
            byte[] decryptedData;
            var KeyAndIv = Generate(secretKey);
            if (inputString.Contains(' '))
            {
               inputString = inputString.Replace(' ', '+');
            }

            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                des.Key = KeyAndIv.key;
                des.IV = KeyAndIv.iv;

                ICryptoTransform decryptor = des.CreateDecryptor();

                byte[] inputBytes = Convert.FromBase64String(inputString);
                decryptedData = decryptor.TransformFinalBlock(inputBytes, 0, inputBytes.Length);
            }

            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}
