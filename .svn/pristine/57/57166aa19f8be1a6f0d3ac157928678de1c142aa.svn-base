using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eHR.Framework.Cryptography
{
    public class UserEnDe
    {
        private static string EN_DE_KEY = "ESSENCORE_EHR_USER";

        public static string Encrypt(string plainText)
        {
            return EnDe.Encrypt(plainText, EN_DE_KEY);
        }

        public static string Decrypt(string encryptedText)
        {
            return EnDe.Decrypt(encryptedText, EN_DE_KEY);
        }

    }
}
