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
using eHR.Framework.Control;

namespace eHR.Framework.Common
{
    public  static partial class HelperExpansion
    {
        #region # TextBox

        #endregion

        /// <summary>
        /// Page NoCache 설정
        /// </summary>
        /// <param name="page"></param>
        public static void SetPageNoCache(this System.Web.UI.Page page)
        {
            page.Response.Expires = 0;
            page.Response.Cache.SetNoStore();
            page.Response.AppendHeader("Pragma", "no-cache");

            //page.Response.AddHeader("pragma", "no-cache");
            //page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //page.Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
            //page.Response.CacheControl = "no-cache";
            //page.Response.Expires = -1;
        }

        /// <summary>
        /// 새로고침 막기 - 저장 후 PostBack이 일어 난 후 계속 그 페이지에 머믈러 있는 경우
        /// 중복 저장을 막아야 하는 경우 사용 합니다.
        /// </summary>
        /// <param name="page"></param>
        public static void RedirectNoCache(this System.Web.UI.Page page)
        {
            page.Response.Redirect(page.Request.RawUrl);
        }

    }
}
