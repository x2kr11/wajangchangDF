using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using eHR.Framework.Common;
using System.Web.Security;
using System.Web;
using eHR.Framework.Sessions;

namespace eHR.Framework.Base
{
    public class ShPopUpBase : ShBase
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            #region # 팝업은 권한 보류 ( 협의 : 2012.10.19 With 강신호 )
            //if (!FormsAuthentication.LoginUrl.ToUpper().Equals(HttpContext.Current.Request.Path.ToUpper()))
            //{
            //    DataSet ds = UserProfile.RollData;// Helper.DeserializeFromString(eHR.Framework.Sessions.UserProfileM.UserRollData);
            //    string sFileName = Request.PhysicalPath.Replace(Server.MapPath(".."), "").Replace("\\", "/");  //현재 페이지 명을 가져온다.
            //    //string sFileName = Path.GetFileName(Request.PhysicalPath); //현재 페이지 명을 가져온다.
            //    string strFilterUrl = string.Format("{0}='{1}'", "Url_NM", sFileName); //현재 페이지명을 데이터셋에서 검색한다.

            //    DataRow[] dtUrl = ds.Tables[0].Select(strFilterUrl);
            //    if (dtUrl.Length == 0) //데이터에서 검색된 페이지가 없으면 강제로 로그인 페이지로 이동한다
            //    {
            //        FormsAuthentication.RedirectToLoginPage();
            //        Response.End();
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// body가 OnLoad 되면 Layer을 닫습니다.
        /// </summary>
        protected void CloseLayerPopup()
        {
            CloseLayerPopup(string.Empty);
        }

        /// <summary>
        /// body가 OnLoad 되면 Layer을 닫습니다.
        /// </summary>
        /// <param name="function"></param>
        protected void CloseLayerPopup(string function)
        {
            System.Web.UI.Control plhOnLoadAdd = this.Master.FindControl("plhOnLoadAdd");
            
            if( plhOnLoadAdd != null )
                plhOnLoadAdd.Visible = true;  
            
            Page.ClientScript.RegisterStartupScript(GetType(), string.Empty, function + ";", true);
        }
        /// <summary>
        /// 마스터 페이지의 Width 들어온 값을 더해서 재 설정 한다
        /// </summary>
        /// <param name="addwidth"></param>
        public void SetScrollStyle(string width)
        {
            ((ILayerMasterPageDesign)this.Master).SetScrollStyle(width);
        }       
    }
}
