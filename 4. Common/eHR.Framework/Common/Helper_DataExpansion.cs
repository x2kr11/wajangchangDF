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
    public static partial class HelperExpansion
    {
        #region # Datatable

        /// <summary>
        /// DataTable의 Null Check
        /// </summary>
        /// <param name="dt">확인 할 DataTable</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this DataTable dt)
        {
            bool bRet = false;

            if (dt == null)
                bRet = true;
            else if (dt.Rows.Count <= 0)
                bRet = true;

            return bRet;
        }

        /// <summary>
        /// 첫번째 Data Row 리턴
        /// </summary>
        /// <param name="dt">확인 할 DataTable</param>
        /// <returns></returns>
        public static DataRow ToFirstRow(this DataTable dt)
        {
            DataRow row = null;

            if (!dt.IsNullOrEmpty())
                row = dt.Rows[0];

            return row;
        }

        #endregion

        #region # DataSet

        /// DataTable의 Null Check
        /// </summary>
        /// <param name="dt">확인 할 DataTable</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this DataSet ds)
        {
            bool bRet = false;

            if (ds == null)
                bRet = true;
            else if (ds.Tables == null || ds.Tables.Count <= 0)
                bRet = true;
            else if (ds.Tables[0].IsNullOrEmpty())
                bRet = true;
            //else if (ds.Tables[0] == null)
            //    bRet = true;

            return bRet;
        }

        /// <summary>
        /// 첫번째 Data Row 리턴
        /// </summary>
        /// <param name="dt">확인 할 DataTable</param>
        /// <returns></returns>
        public static DataRow ToFirstRow(this DataSet ds)
        {
            DataRow row = null;

            if (!ds.IsNullOrEmpty())
                row = ds.Tables[0].Rows[0];

            return row;
        }

        /// <summary>
        /// 첫번째 DataTable 리턴
        /// </summary>
        /// <param name="dt">확인 할 DataTable</param>
        /// <returns></returns>
        public static DataTable ToFirstTable(this DataSet ds)
        {
            DataTable dtRet = null;

            if (!ds.IsNullOrEmpty())
                dtRet = ds.Tables[0];

            return dtRet;
        }

        /// <summary>
        /// DataTable의 Column의 Max값을 호출
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="columnName">Column name</param>
        /// <returns></returns>
        public static Decimal ToColumnMax(this DataTable dt, string columnName)
        {
            try
            {
                Decimal iDataSourceMaxID = -1;
                if (dt.Columns.Contains(columnName))
                    iDataSourceMaxID = (Decimal)dt.Compute("MAX(ID)", string.Empty);

                return iDataSourceMaxID;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        #endregion

        #region # DataRow

        public static bool IsNullOrEmpty(this DataRow dr, string fieldName)
        {
            bool bRet = false;

            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                bRet = true; ;

            return bRet;
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static string ToString(this DataRow dr, string fieldName)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return null;

            return dr[fieldName].ToString();
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static string ToEmptyString(this DataRow dr, string fieldName)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return string.Empty;

            return dr[fieldName].ToString();
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼의 값을 리턴 합니다.
        /// 동시에 입력된 특수 문자를 html 코드로 변환 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <param name="applyBR">Html <br>을 적용 하는지 여부</param>
        /// <returns></returns>
        public static string ToHtmlString(this DataRow dr, string fieldName, bool applyBR)
        {
            return dr.ToEmptyString(fieldName).ToHtmlString(applyBR);
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼의 값을 리턴 합니다.
        /// 동시에 입력된 특수 문자를 html 코드로 변환 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static string ToHtmlString(this DataRow dr, string fieldName)
        {
            return dr.ToEmptyString(fieldName).ToHtmlString();
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(Int64)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static int ToColumnInt(this DataRow dr, string fieldName)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return 0;

            string ret = dr.ToString(fieldName);

            if (ret.IndexOf(".") > 0)
                ret = ret.Substring(0, ret.IndexOf('.'));


            return int.Parse(ret, System.Globalization.NumberStyles.Any);
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(double)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static double ToColumnDouble(this DataRow dr, string fieldName)
        {
            return ToColumnDouble(dr, fieldName, 0);
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(double)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <param name="Point">소숫점</param>
        /// <returns></returns>
        public static double ToColumnDouble(this DataRow dr, string fieldName, int Point)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return 0;

            string strValue = dr.ToString(fieldName);

            double ret = double.Parse(dr.ToString(fieldName), System.Globalization.NumberStyles.Any);

            return ret;
        }

        /// <summary>
        /// DataRow의 값이 Double형인지 판별 한다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static bool IsConvertDouble(this DataRow dr, string fieldName)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return false;

            try
            {
                double ret = double.Parse(dr.ToString(fieldName), System.Globalization.NumberStyles.Any);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(decimal)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static decimal ToColumnNumeric(this DataRow dr, string fieldName)
        {
            return ToColumnNumeric(dr, fieldName, 0);
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(decimal)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <param name="Point">소숫점</param>
        /// <returns></returns>
        public static decimal ToColumnNumeric(this DataRow dr, string fieldName, int Point)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return 0;

            decimal ret = decimal.Parse(dr.ToString(fieldName), System.Globalization.NumberStyles.Any);
            ret = Math.Round(ret, Point);

            return ret;
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(bit)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static bool ToColumnBit(this DataRow dr, string fieldName)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(dr[fieldName]);
            }
        }

        /// <summary>
        /// bit 타입을 "예" , "아니로" 로 표시를 한다.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string ToBitString(this DataRow dr, string fieldName)
        {
            string strRet = string.Empty;

            if (dr.IsNullOrEmpty(fieldName))
                return string.Empty;

            var dc = dr[fieldName];

            if (dc.GetType() == typeof(bool))
            {
                bool bYN = Boolean.Parse(dr[fieldName].ToString());
                strRet = bYN.ToBitString();
            }

            return strRet;
        }

        #endregion

        #region # DataRowView

        public static bool IsNullOrEmpty(this DataRowView dr, string fieldName)
        {
            bool bRet = false;

            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                bRet = true; ;

            return bRet;
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static string ToString(this DataRowView dr, string fieldName)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return null;

            return dr[fieldName].ToString();
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static string ToEmptyString(this DataRowView dr, string fieldName)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return string.Empty;

            return dr[fieldName].ToString();
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼의 값을 리턴 합니다.
        /// 동시에 입력된 특수 문자를 html 코드로 변환 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <param name="applyBR">Html <br>을 적용 하는지 여부</param>
        /// <returns></returns>
        public static string ToHtmlString(this DataRowView dr, string fieldName, bool applyBR)
        {
            return dr.ToEmptyString(fieldName).ToHtmlString(applyBR);
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼의 값을 리턴 합니다.
        /// 동시에 입력된 특수 문자를 html 코드로 변환 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static string ToHtmlString(this DataRowView dr, string fieldName)
        {
            return dr.ToEmptyString(fieldName).ToHtmlString();
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(Int64)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static int ToColumnInt(this DataRowView dr, string fieldName)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return 0;

            string ret = dr.ToString(fieldName);

            if (ret.IndexOf(".") > 0)
                ret = ret.Substring(0, ret.IndexOf('.'));


            return int.Parse(ret, System.Globalization.NumberStyles.Any);
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(double)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static double ToColumnDouble(this DataRowView dr, string fieldName)
        {
            return ToColumnDouble(dr, fieldName, 0);
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(double)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <param name="Point">소숫점</param>
        /// <returns></returns>
        public static double ToColumnDouble(this DataRowView dr, string fieldName, int Point)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return 0;

            string strValue = dr.ToString(fieldName);

            double ret = double.Parse(dr.ToString(fieldName), System.Globalization.NumberStyles.Any);

            return ret;
        }

        /// <summary>
        /// DataRow의 값이 Double형인지 판별 한다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static bool IsConvertDouble(this DataRowView dr, string fieldName)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return false;

            try
            {
                double ret = double.Parse(dr.ToString(fieldName), System.Globalization.NumberStyles.Any);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(decimal)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static decimal ToColumnNumeric(this DataRowView dr, string fieldName)
        {
            return ToColumnNumeric(dr, fieldName, 0);
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(decimal)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <param name="Point">소숫점</param>
        /// <returns></returns>
        public static decimal ToColumnNumeric(this DataRowView dr, string fieldName, int Point)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
                return 0;

            decimal ret = decimal.Parse(dr.ToString(fieldName), System.Globalization.NumberStyles.Any);
            ret = Math.Round(ret, Point);

            return ret;
        }

        /// <summary>
        /// DataRow의 정합성을 채크한 컬럼(bit)의 값을 리턴 합니다.
        /// </summary>
        /// <param name="dr">DataRow</param>
        /// <param name="fieldName">Column Name</param>
        /// <returns></returns>
        public static bool ToColumnBit(this DataRowView dr, string fieldName)
        {
            if (dr == null || string.IsNullOrEmpty(fieldName) || dr[fieldName] == null || dr[fieldName] == DBNull.Value)
            {
                return false;
            }
            else
            {
                return Convert.ToBoolean(dr[fieldName]);
            }
        }

        /// <summary>
        /// bit 타입을 "예" , "아니로" 로 표시를 한다.
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public static string ToBitString(this DataRowView dr, string fieldName)
        {
            string strRet = string.Empty;

            if (dr.IsNullOrEmpty(fieldName))
                return string.Empty;

            var dc = dr[fieldName];

            if (dc.GetType() == typeof(bool))
            {
                bool bYN = Boolean.Parse(dr[fieldName].ToString());
                strRet = bYN.ToBitString();
            }

            return strRet;
        }

        #endregion

        #region # string

        /// <summary>
        /// int 널값 허용 처리
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDbParaInt(this string value)
        {
            return ToDbParaInt(value, DBNull.Value);
        }

        /// <summary>
        /// int 널값 허용 처리
        /// </summary>
        /// <param name="value">int 값</param>
        /// <param name="defaultValue">값이 없을때 초기값</param>
        /// <returns></returns>
        public static object ToDbParaInt(string value, object defaultValue)
        {
            object objRet = defaultValue;

            if (!string.IsNullOrEmpty(value))
            {
                objRet = int.Parse(value.Replace(",", ""));
            }

            return objRet;
        }

        /// <summary>
        /// long 널값 허용 처리
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDbParaBigInt(this string value)
        {
            return ToDbParaBigInt(value, DBNull.Value);
        }

        /// <summary>
        /// long 널값 허용 처리
        /// </summary>
        /// <param name="value">long 값</param>
        /// <param name="defaultValue">값이 없을때 초기값</param>
        /// <returns></returns>
        public static object ToDbParaBigInt(string value, object defaultValue)
        {
            object objRet = defaultValue;

            if (!string.IsNullOrEmpty(value))
            {
                objRet = long.Parse(value.Replace(",", ""));
            }

            return objRet;
        }


        /// <summary>
        /// numeric 널값 허용 처리
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDbParaNumeric(this string value)
        {
            return ToDbParaNumeric(value, DBNull.Value);
        }

        /// <summary>
        /// numeric 널값 허용 처리
        /// </summary>
        /// <param name="value">numeric 값</param>
        /// <param name="defaultValue">값이 없을때 초기값</param>
        /// <returns></returns>
        public static object ToDbParaNumeric(string value, object defaultValue)
        {
            object objRet = defaultValue;

            if (!string.IsNullOrEmpty(value))
            {
                if (value.Length == 1 && value.Equals("."))
                {
                    objRet = defaultValue;   
                }
                else
                {
                    objRet = decimal.Parse(value.Replace(",", ""));
                }

            }

            return objRet;
        }

        /// <summary>
        /// double 널값 허용 처리
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDbParaDouble(this string value)
        {
            return ToDbParaDouble(value, DBNull.Value);
        }

        /// <summary>
        /// double 널값 허용 처리
        /// </summary>
        /// <param name="value">double 값</param>
        /// <param name="defaultValue">값이 없을때 초기값</param>
        /// <returns></returns>
        public static object ToDbParaDouble(string value, object defaultValue)
        {
            object objRet = defaultValue;

            if (!string.IsNullOrEmpty(value))
            {
                objRet = double.Parse(value.Replace(",", ""));
            }

            return objRet;
        }


        /// <summary>
        /// 달력이 널값일때 현재날짜 string 8자리 입력
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object ToDbNullCalendar(this string value)
        {
            return ToDbNullCalendar(value, DateTime.Now.ToString("yyyyMMdd"));
        }

        /// <summary>
        /// 달력이 널값일때 현재날짜 string 8자리 입력
        /// </summary>
        /// <param name="value">string 값</param>
        /// <param name="defaultValue">값이 없을때 초기값</param>
        /// <returns></returns>
        public static object ToDbNullCalendar(string value, object defaultValue)
        {
            object objRet = defaultValue;

            if (!string.IsNullOrEmpty(value))
            {
                objRet = DateTime.Parse(value).ToString("yyyyMMdd");
            }

            return objRet;
        }

        /// <summary>
        /// bit 타입을 "예" , "아니로" 로 표시를 한다.
        /// </summary>
        /// <param name="YN"></param>
        /// <returns></returns>
        public static string ToBitString(this bool YN)
        {
            string strRet = string.Empty;

            strRet = (YN) ? "예" : "아니오";

            return strRet;
        }

        /// <summary>
        /// 소수 3자리 , 제공
        /// </summary>
        /// <param name="amt"></param>
        /// <returns></returns>
        public static string ToCurrency(this string value)
        {
            string srtReturnValue = string.Empty;

            srtReturnValue = value.Replace(",", "");

            srtReturnValue = string.IsNullOrEmpty(srtReturnValue) ? "0" : String.Format("{0:#,##0}", decimal.Parse(srtReturnValue.ToString()));

            return srtReturnValue;
        }

        /// <summary>
        /// 소수 3자리 , 제공
        /// </summary>
        /// <param name="amt"></param>
        /// <returns></returns>
        public static string ToCurrencyPoint(this string value)
        {
            string srtReturnValue = string.Empty;

            srtReturnValue = value.Replace(",", "");

            srtReturnValue = string.IsNullOrEmpty(srtReturnValue) ? "0" : String.Format("{0:#,##0.00}", decimal.Parse(srtReturnValue.ToString()));

            return srtReturnValue;
        }

        #endregion



    }
}
