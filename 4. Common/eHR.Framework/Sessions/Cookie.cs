using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using eHR.Framework.Common;

namespace eHR.Framework.Sessions
{
    public class Cookie
    {
        private const string COOKIE_NAME = "MOSTI_COOKIE";
        private const int EXPIRE_MINUTE = 20;                 //20분
        private const bool ENCRYPT_YN = true;
        public static bool ONE_TIME_COOKIE = false;
        /// <summary>
        /// 쿠키를 설정하기 위한 유틸 메소드입니다.
        /// </summary>
        /// <param name="cookieName">쿠키 네임.</param>
        /// <param name="key">키</param>
        /// <param name="value">값</param>
        /// <param name="encrypt">값의 암호화여부</param>
        /// <param name="expireMinute">만료 시간(분)</param>
        /// <remarks>
        /// 쿠키에는 복수개의 (키,값)쌍이 저장될 수 있습니다. 
        /// 이 메소드는  하나의 (키, 값)쌍을 저장하는데 사용하는 단순한 버전입니다.
        /// </remarks>
        public static void Set(string cookieName, string key, string value, bool encrypt, int expireMinute)
        {
            try
            {
                // string val = String.Empty;
                System.Web.HttpCookie httpCookie = null;

                //1. encrypt 값이 true이면 데이타 암호화
                if (encrypt)
                {
                    //value = Mosti.Fundamentals.Cryptography.TripleDESEncryptor.Encrypt(value);
                    value = eHR.Framework.Cryptography.EnDe.Encrypt(value);
                }

                //2. 쿠키 객체 준비
                if (System.Web.HttpContext.Current.Request.Cookies[cookieName] != null)
                {
                    //쿠키가 이미 존재하면 삭제
                    httpCookie = System.Web.HttpContext.Current.Request.Cookies[cookieName];
                }
                else
                {
                    //쿠키 객체 생성
                    httpCookie = new System.Web.HttpCookie(cookieName);
                }

                //Domain 속성 결정
                string strImsi = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_HOST"];
                string strDomain = Helper.CurrentDomain();//most ConfigurationUtil.GetAppServerConfigValue("GTCookie", "Domain", PropType.Value);

                System.Net.IPAddress ipAddress;
                bool isIP = System.Net.IPAddress.TryParse(strImsi, out ipAddress);
                if (isIP || strImsi.ToUpper().IndexOf("LOCALHOST") > -1)
                {
                    //로컬인경우에는 도메인을 셋팅하지 않는다.                                       
                }
                else
                {
                    string domain = strDomain;
                    if (!String.IsNullOrEmpty(domain))
                    {
                        httpCookie.Domain = domain;
                    }
                }
                // 쿠키 Path 설정
                httpCookie.Path = "/";

                // 만료 시간 설정
                // 만료 시간 설정이 0이면 in-memory cookie  (One time Cookie) -> 브라우저가 닫히면 쿠키도 사라진다.
                //string expire = ConfigurationUtil.GetClientConfigValue("GTCookie", "ExpireMinute", PropType.Value);

                if (expireMinute <= 0)
                {
                    ONE_TIME_COOKIE = true;
                    httpCookie.Expires = DateTime.MaxValue; // the cookie never expires
                    //httpCookie.Expires = System.DateTime.Now.AddMinutes(Convert.ToDouble(expireMinute));
                }

                //3. 쿠키에 정보 추가 
                httpCookie.Values.Add(key, value);

                //Response 객체에 쿠키 추가
                System.Web.HttpContext.Current.Response.Cookies.Add(httpCookie);
            }
            catch (Exception ex)
            {
                throw new Exception("사용자 identity 정보를 캐싱하는 과정에서 에러가 발생했습니다.", ex);
            }
        }

        public static void Set(string key, string value)
        {
            Cookie.Set(COOKIE_NAME, key, value, ENCRYPT_YN, EXPIRE_MINUTE);
        }

        public static void Set(string key, string value, int expireMinute)
        {
            Cookie.Set(COOKIE_NAME, key, value, ENCRYPT_YN, expireMinute);
        }

        /// <summary>
        /// 쿠키 값을 조회하기 위한 메소드입니다.
        /// </summary>
        /// <param name="cookieName">쿠키명</param>
        /// <param name="key">키</param>
        /// <param name="decript">값의 복호화여부</param>
        /// <returns></returns>
        public static string Get(string cookieName, string key, bool decript)
        {
            string strCookieValue = string.Empty;

            if (!string.IsNullOrEmpty(key))
            {
                if (HttpContext.Current.Request.Cookies[cookieName] != null)
                {
                    strCookieValue = HttpContext.Current.Request.Cookies[cookieName][key];

                    if (!String.IsNullOrEmpty(strCookieValue))
                    {
                        if (decript)
                        {
                            strCookieValue = eHR.Framework.Cryptography.EnDe.Decrypt(strCookieValue);
                        }
                    }
                }
            }
            return strCookieValue;
        }

        public static string Get(string key)
        {
            return Cookie.Get(COOKIE_NAME, key, ENCRYPT_YN);
        }

        /// <summary>
        /// 설정된 모든 쿠키를 삭제합니다.
        /// </summary>
        /// <param name="cookieName">쿠키명</param>
        public static void Clear()
        {
            if (System.Web.HttpContext.Current.Request.Cookies.Count > 0)
            {
                foreach (HttpCookie cookie in System.Web.HttpContext.Current.Response.Cookies)
                {
                    cookie.Expires = DateTime.Now.AddYears(-30);
                }
            }
        }

        /// <summary>
        /// 쿠키를 제거 합니다.
        /// </summary>
        /// <param name="cookieName"></param>
        public static void Remove(string cookieName)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[cookieName] != null)
            {
                System.Web.HttpContext.Current.Response.Cookies[cookieName].Expires = DateTime.Now.AddYears(-30);
            }
        }

        public static void ReSet(string key)
        {
            if (System.Web.HttpContext.Current.Request.Cookies[COOKIE_NAME] != null)
            {
                System.Web.HttpContext.Current.Response.Cookies[COOKIE_NAME][key] = "";
            }
        }
    }
}
