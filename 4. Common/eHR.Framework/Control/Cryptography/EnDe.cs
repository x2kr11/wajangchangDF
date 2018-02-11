using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace eHR.Framework.Cryptography
{
    public class EnDe
    {
        private const string EN_DE_KEY = "ESSENCORE_EHR";

        public static string Encrypt(string plainText)
        {
            return Encrypt(plainText, EN_DE_KEY);
        }

        public static string Encrypt(string plainText, string key)
        {
            //빈값일경우 암호화 하지않음

            if (plainText.Equals("")) return "";

            string password = key;    // SkccFxConfigManager.GetString("EncryptKey");
            RijndaelManaged managed = new RijndaelManaged();
            byte[] buffer = Encoding.Unicode.GetBytes(plainText);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(password.Length.ToString());
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(password, rgbSalt);
            ICryptoTransform transform = managed.CreateEncryptor(bytes.GetBytes(0x20), bytes.GetBytes(0x10));
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            byte[] inArray = stream.ToArray();
            stream.Close();
            stream2.Close();
            return Convert.ToBase64String(inArray);
        }

        public static string Decrypt(string encryptedText)
        {
            return Decrypt(encryptedText, EN_DE_KEY);
        }

        public static string Decrypt(string encryptedText, string key)
        {
            if (encryptedText.Length == 0) return "";
            //빈값일경우 암호화 하지않음
            if (encryptedText.Equals("")) return "";

            string password = key;    //SkccFxConfigManager.GetString("EncryptKey");
            RijndaelManaged managed = new RijndaelManaged();
            byte[] buffer = Convert.FromBase64String(encryptedText);
            byte[] rgbSalt = Encoding.ASCII.GetBytes(password.Length.ToString());
            PasswordDeriveBytes bytes = new PasswordDeriveBytes(password, rgbSalt);
            ICryptoTransform transform = managed.CreateDecryptor(bytes.GetBytes(0x20), bytes.GetBytes(0x10));
            MemoryStream stream = new MemoryStream(buffer);
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            byte[] buffer3 = new byte[buffer.Length];
            int count = stream2.Read(buffer3, 0, buffer3.Length);
            stream.Close();
            stream2.Close();
            return Encoding.Unicode.GetString(buffer3, 0, count);
        }
    }
}
