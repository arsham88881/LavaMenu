using LavaMenu.Application.Common.constConfigure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Common.AES
{
    //AES (advance encryption standard encryption and decryption algorithem
    public static class EncryptionDecryption
    {

        //generate key and iv with secret key string for start working with AES algorithem
        private static (byte[] key, byte[] iv) Generate(string secretKey)
        {
           
            // Generate a key using SHA256 hash function 
            byte[] CryptKey = new byte[16];
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(secretKey));
                Array.Copy(hash, CryptKey, 16);
            }

            // Generate a IV using SHA256 hash function
            byte[] CryptIv = new byte[16];
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hash = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(secretKey));
                Array.Copy(hash, CryptIv, 16);
                 
            }
            return (CryptKey, CryptIv);
        }
        public static string EncryptStringAES(this string plainText,string secretkey)
        {
           var KeyAndIv = Generate(secretkey);

            byte[] encrypted;

            // Create an Aes object with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.Key = KeyAndIv.key;
                aes.IV = KeyAndIv.iv;

                // Create a new MemoryStream object to contain the encrypted bytes.
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Create a CryptoStream object to perform the encryption.
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        // Encrypt the plaintext.
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        encrypted = memoryStream.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(encrypted); //convert byte[] to string for sansor complexity
        }

        public static string DecryptStringAES(this string cipherText , string secretkey)
        {

            var KeyAndIv = Generate(secretkey);

            var cipher = Encoding.UTF8.GetBytes(cipherText); //convert to byte[] for start process

            string decrypted;

            // Create an Aes object with the specified key and IV.
            using (Aes aes = Aes.Create())
            {
                aes.Key = KeyAndIv.key ;
                aes.IV = KeyAndIv.iv;

                // Create a new MemoryStream object to contain the decrypted bytes.
                using (MemoryStream memoryStream = new MemoryStream(cipher))
                {
                    // Create a CryptoStream object to perform the decryption.
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        // Decrypt the ciphertext.
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            decrypted = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return decrypted;
        }

        
    }
}