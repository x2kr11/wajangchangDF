using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace eHR.Framework.Cryptography
{
    /// <summary>
    /// 단방향 암호화 알고리즘 입니다.
    /// </summary>
    public class OneWayHash
    {
        public enum HashType : int
        {
            MD5 = 1,
            SHA1 = 2,
            SHA256 = 3,
            SHA384 = 4,
            SHA512 = 5
        }

        public static string GetHash(string planText, HashType hshType)
        {
            string strRet = string.Empty;
            switch (hshType)
            {
                case HashType.MD5:
                    strRet = GetMD5(planText);
                    break;
                case HashType.SHA1:
                    strRet = GetSHA1(planText);
                    break;
                case HashType.SHA256:
                    strRet = GetSHA256(planText);
                    break;
                case HashType.SHA384:
                    strRet = GetSHA384(planText);
                    break;
                case HashType.SHA512:
                    strRet = GetSHA512(planText);
                    break;
                default:
                    strRet = "No HashType";
                    break;
            }
            return strRet;
        }

        public static bool CheckHash(string origianl, string hash, HashType hshType)
        {
            string strOrigHash = GetHash(origianl, hshType);
            return (strOrigHash == hash);
        }

        private static string GetSHA512(string planText)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(planText);
            SHA512Managed SHhash = new SHA512Managed();
            string strHex = string.Empty;

            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }

        private static string GetSHA384(string planText)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(planText);
            SHA384Managed SHhash = new SHA384Managed();
            string strHex = string.Empty;


            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }

        private static string GetSHA256(string planText)
        {
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = UE.GetBytes(planText);
            SHA256Managed SHhash = new SHA256Managed();
            string strHex = string.Empty;


            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }

        private static string GetSHA1(string planText)
        {
            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = ue.GetBytes(planText);
            SHA1Managed SHhash = new SHA1Managed();
            string strHex = string.Empty;


            HashValue = SHhash.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += String.Format("{0:x2}", b);
            }
            return strHex;
        }

        private static string GetMD5(string planText)
        {
            UnicodeEncoding ue = new UnicodeEncoding();
            byte[] HashValue, MessageBytes = ue.GetBytes(planText);
            MD5 md5 = new MD5CryptoServiceProvider();
            string strHex = string.Empty;

            HashValue = md5.ComputeHash(MessageBytes);
            foreach (byte b in HashValue)
            {
                strHex += string.Format("{0:x2}", b);
            }
            return strHex;
        }
    }   
}
