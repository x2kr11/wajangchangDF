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
using System.Text.RegularExpressions;

namespace eHR.Framework.Common
{
    public static partial class Helper
    {
        /// <summary>
        /// 마지막 글자를 제거 합니다.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="delimeter"></param>
        /// <returns></returns>
        private static string RemoveLastDelimeter(string source, string delimeter)
        {
            if (source.Length > 0)
            {
                if (source.Substring(source.Length - 1, 1).Equals(delimeter))
                {
                    source = source.Remove(source.Length - 1, 1);
                }
            }
            return source;
        }

        /// <summary>
        /// WebConfig 에 있는 값을 가져온다
        /// </summary>
        /// <param name="configaname"></param>
        /// <returns></returns>
        public static string GetAppConfig(string configaname)
        {
            string strReturn = string.Empty;
            strReturn = ConfigurationManager.AppSettings[configaname] == null ? string.Empty : ConfigurationManager.AppSettings[configaname].ToString();
            return strReturn;
        }

        /// <summary>
        /// null 이 아니면 ToString()을 반환 한다.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string GetStringEmpty(object obj)
        {
            string strReturn = string.Empty;

            strReturn = obj == null ? string.Empty : obj.ToString();

            return strReturn;
        }

        /// <summary>
        /// strDest 문자열의 길이가 nMaxLength 바이트를 초과할 경우 '...' 문자열을 삽입하여 반환합니다. 
        /// </summary>
        /// <param name="strDest">변환할 대상 문자열</param>
        /// <param name="nMaxLength">최대 바이트 수</param>
        public static string ConvertEllipsisString(string strDest, int nMaxLength)
        {
            string strConvert;
            int nLength, n2ByteCharCount;
            byte[] arrayByte = System.Text.Encoding.Default.GetBytes(strDest);
            nLength = System.Text.Encoding.Default.GetByteCount(strDest);
            if (nLength > nMaxLength)    // 글 제목이 너무 길 경우... 
            {
                n2ByteCharCount = 0;
                for (int i = 0; i < nMaxLength; i++)
                {
                    if (arrayByte[i] >= 128)    // 2바이트 문자 판별 
                        n2ByteCharCount++;
                }
                strConvert = strDest.Substring(0, nMaxLength - (n2ByteCharCount / 2)) + "...";
            }
            else
            {
                strConvert = strDest;
            }
            return strConvert;
        }


        /// <summary>
        /// 영문체크
        /// </summary>
        /// <param name="letter">문자
        /// <returns></returns>
        public static bool CheckEnglish(string letter)
        {

            bool IsCheck = true;

            Regex engRegex = new Regex(@"[a-zA-Z]");

            Boolean ismatch = engRegex.IsMatch(letter);

            if (!ismatch)
            {
                IsCheck = false;
            }

            return IsCheck;
        }

        /// <summary>
        /// 작성자 : 강신호
        /// 작성일 : 2012-10-07
        /// yyyyMMdd => yyyy-MM-dd 로 변경
        /// yyyyMM => yyyy-MM 로 변경
        /// </summary>
        /// <param name="strDate"></param>
        /// <returns></returns>
        public static string ConvertStringToDatestring(string paraDate)
        {
            int iLength = paraDate.Length;
            string rtnDatestring = "";
            switch (iLength)
            { 
                case 8:
                    rtnDatestring = paraDate.Substring(0, 4) + "-" + paraDate.Substring(4, 2) + "-" + paraDate.Substring(6, 2);
                    break;
                case 6:
                    rtnDatestring = paraDate.Substring(0, 4) + "-" + paraDate.Substring(4, 2);
                    break;
            }

            return rtnDatestring;
        }

        /// <summary>
        /// 문자열이 숫자 형식인지를 확인하는 함수
        /// 작성자 : 이윤호
        /// 작성일 : 2013-01-31
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        public static bool IsNumber(string strValue)
        {
            if (strValue == null || strValue.Length < 1)
                return false;

            //요기서 정규식 사용
            Regex reg = new Regex(@"^(\d)+$");

            return reg.IsMatch(strValue);
        }
    }
}
