using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using eHR.Framework.Base;

namespace eHR.Framework.Cryptography
{
    public class ShCrypt
    {

        public static string Encrypt(string enValue)
        {
            string strEn = enValue;
            return strEn;
        }

        public static string Decrypt(string deValue)
        {

            string strDe = deValue;
            return strDe;
        }

        public static Hashtable ParseShParm(List<ShParam> lstSh)
        {
            Hashtable ht = new Hashtable();

            foreach (ShParam param in lstSh)
            {
                if (param.EncYN)
                {

                    ht.Add(param.Name, ShCrypt.Encrypt(param.Value.ToString()));
                }
                else
                {
                    ht.Add(param.Name, param.Value);
                }
            }
            return ht;
        }


    }
}
