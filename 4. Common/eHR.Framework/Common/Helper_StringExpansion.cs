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
    /// <summary>
    /// 내용 : String 관련된 공통 확장 메서드
    /// </summary>
    public static partial class HelperExpansion
    {
        /// <summary>
        /// 입력된 특수 문자를 html 코드로 변환 합니다.
        /// </summary>
        /// <param name="str">Html Code로 변경 할 String</param>
        /// <returns></returns>
        public static string ToHtmlString(this string str)
        {
            return ToHtmlString(str, true);
        }

        /// <summary>
        /// 입력된 특수 문자를 html 코드로 변환 합니다.
        /// </summary>
        /// <param name="str">변경 할 String</param>
        /// <param name="applyBR">Html <br>을 적용 하는지 여부</param>
        /// <returns></returns>
        public static string ToHtmlString(this string str, bool applyBR)
        {
            if (string.IsNullOrEmpty(str))
                return string.Empty;

            str = str.Replace(",", "&#44;");

            if (applyBR)
            {
                str = str.Replace("\r\n", "<br/>");
                str = str.Replace("\r", "<br/>");
            }

            str = str.Replace("\"", "&#34;");
            str = str.Replace("'", "&#39;");
            str = str.Replace("(", "&#40;");
            str = str.Replace(")", "&#41;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            return str;
        }


        /// <summary>
        /// 해당값을 전화 번호 타입으로 반환
        /// 01100001111 - > 011-0000-1111
        /// </summary>
        /// <param name="amt"></param>
        /// <returns></returns>
        public static string ToPhoneNumber(this string value)
        {
            string str = string.Empty;

            if (value.Length > 2)
            {
                if (value.Substring(0, 2) == "02")
                {
                    // 서울 지역 번호 일때 9 자리 번호

                    if (value.Length == 9)
                    {
                        str = value.Substring(0, 2) + "-" + value.Substring(2, 3) + "-" + value.Substring(5, 4);
                    }
                    else if (value.Length == 10)
                    {
                        str = value.Substring(0, 3) + "-" + value.Substring(3, 3) + "-" + value.Substring(6, 4);
                    }
                    else
                    {
                        str = value;
                    }
                }
                else
                {
                    // 핸드폰이나 10자리 이상 연락처
                    if (value.Length == 10)
                    {
                        str = value.Substring(0, 3) + "-" + value.Substring(3, 3) + "-" + value.Substring(6, 4);
                    }
                    else if (value.Length == 11)
                    {
                        str = value.Substring(0, 3) + "-" + value.Substring(4, 4) + "-" + value.Substring(7, 4);
                    }
                    else
                    {
                        str = value;
                    }
                }


            }

            return str;
        }

        /// <summary>
        /// 해당값을 사업자 번호로 반환
        /// 2208673547 - > 220-86-73547
        /// </summary>
        /// <param name="amt"></param>
        /// <returns></returns>
        public static string ToBizNumber(this string value)
        {
            string str = string.Empty;

            string changvalue = value.Replace("-", "");

            if (changvalue.Length == 10)
            {
                str = changvalue.Substring(0, 3) + "-" + changvalue.Substring(3, 2) + "-" + changvalue.Substring(5, 5);
            }
            else
            {
                str = value;
            }

            return str;
        }


        /// <summary>
        /// 소수점만 들어왔을때 해당값을 0으로 반환
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToChangePoint(this string value)
        {
            string str = string.Empty;

            if (value.Length == 1 && value.Equals("."))
            {
                str = "0";
            }
            else
            {
                str = value;
            }

            return str;
        }

    }
}
