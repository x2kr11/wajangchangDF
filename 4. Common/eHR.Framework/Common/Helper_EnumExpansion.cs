using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.IO;
using System.Configuration;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace eHR.Framework.Common
{
    public  static partial class HelperExpansion
    {
        /// <summary>
        /// ENUM의 Discription을 호출 한다.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToDescription(this System.Enum value)
        {
            System.Reflection.FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
    }
}
