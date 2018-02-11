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
using System.Web.Security;

namespace eHR.Framework.Common
{
    public partial class Helper
    {
        /// <summary>
        /// 현재 웹사이트의 도메인 정보를 반환 합니다. (Port 포함)
        /// </summary>
        /// <returns></returns>
        public static string CurrentDomain()
        {
            HttpRequest request = System.Web.HttpContext.Current.Request;
            return request.Url.Scheme + System.Uri.SchemeDelimiter + request.Url.Host + (request.Url.Port != 80 ? ":" + request.Url.Port : "");
        }

        /// <summary>
        /// 작성자 : 성정오
        /// 작성일 : 2012.10.05
        /// 내  용 : 폼인증과 Session을 모두 제거 합니다.
        /// </summary>
        /// <param name="cookieName"></param>
        public static void SetClearFormsAuthenticationAndSession()
        {
            FormsAuthentication.SignOut();
            System.Web.HttpContext.Current.Session.RemoveAll();

            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Values.Count > 0)
                HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName].Values.Clear();

            while (true)
            {
                if (HttpContext.Current.Request.Cookies.AllKeys.Contains(FormsAuthentication.FormsCookieName))
                    HttpContext.Current.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
                else
                    break;
            }
        }
    }
}
