using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace eHR.Framework.Cryptography
{
    public class QueryStringEnDeModule : IHttpModule
    {
        /// <summary>
        /// 암호화가 되면 ?mosti=뒤에 모든 Querystring 데이타가 암호화 된다.
        /// </summary>
        private const string PARAMS_NAME = "ehr=";

        #region IHttpModule 멤버

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(OnContextBeginRequest);
        }

        void OnContextBeginRequest(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (context.Request.Url.OriginalString.ToLower().Contains("aspx") && context.Request.RawUrl.Contains("?"))
            {
                string strQuery = GetRequestQueryString(context.Request.RawUrl);

                string strVirPath = GetVirtualPath();

                if (strQuery.StartsWith(PARAMS_NAME, StringComparison.OrdinalIgnoreCase))
                {
                    string rawQuery = strQuery.Replace(PARAMS_NAME, string.Empty);
                    
                    string decryptedQuery = eHR.Framework.Cryptography.EnDe.Decrypt(rawQuery);
                    context.RewritePath(strVirPath, string.Empty, decryptedQuery);
                }
                else if (context.Request.HttpMethod == "GET")
                {
                    string encryptedQuery = "?" + PARAMS_NAME + eHR.Framework.Cryptography.EnDe.Encrypt(strQuery);
                    context.Response.Redirect(strVirPath + encryptedQuery);
                }
            }
        }

        private string GetDomain(HttpContext context)
        {
            return context.Request.Url.Scheme + System.Uri.SchemeDelimiter + context.Request.Url.Host + ":" + context.Request.Url.Port;
        }

        /// <summary>
        /// ?뒤에 있는 QueryString 전제 문자열을 반환 합니다.
        /// </summary>
        /// <param name="url">Request된 URL 입니다.</param>
        /// <returns></returns>
        private static string GetRequestQueryString(string url)
        {
            return url.Substring(url.IndexOf("?") + 1);
        }

        /// <summary>
        /// 주 도메인 뒤에 있는 ?뒤에 있는 QueryString 전제 문자열을 제외한 가상 경로를 반환 합니다.
        /// </summary>
        /// <returns></returns>
        private static string GetVirtualPath()
        {
            string strPath = HttpContext.Current.Request.RawUrl;
            strPath = strPath.Substring(0, strPath.IndexOf("?"));
            strPath = strPath.Substring(strPath.LastIndexOf("/") + 1);
            return strPath;
        }

        #endregion
    }
}
