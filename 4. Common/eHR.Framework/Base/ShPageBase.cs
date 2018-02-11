using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using Skcc.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using System.Configuration;
using eHR.Framework.Sessions;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using eHR.Framework.Common;
using System.Web.Security;

namespace eHR.Framework.Base
{
    public class ShPageBase : ShBase
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            #region # RMS Menu Roll 검증

            //if ( this.CheckAuthenticated && !FormsAuthentication.LoginUrl.ToUpper().Equals(HttpContext.Current.Request.Path.ToUpper()))
            //{
            //    DataSet ds              = UserProfile.RollData;
            //    string  sFileName       = Request.Path.Replace("~", string.Empty);
            //    string  strFilterUrl    = string.Format("{0}='{1}'", "Url_NM", sFileName); //현재 페이지명을 데이터셋에서 검색한다.

            //    if ( ds.IsNullOrEmpty() || ds.Tables[0].Select(strFilterUrl).Length <= 0) //데이터에서 검색된 페이지가 없으면 강제로 로그인 페이지로 이동한다
            //    {
            //        this.SetPageNoCache();
            //        FormsAuthentication.RedirectToLoginPage();
            //        Response.End();
            //    }
            //}
            #endregion

            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }

        /// <summary>
        /// 마스터 페이지의 Width 들어온 값을 더해서 재 설정 한다
        /// </summary>
        /// <param name="addwidth"></param>
        public void SetMasterWith(int addwidth)
        {
            ((IMasterPageDesign)this.Master).SetMasterWithAdd(addwidth);
        }

    }
}
