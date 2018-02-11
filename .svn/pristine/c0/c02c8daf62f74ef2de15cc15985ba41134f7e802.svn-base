using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;
using System.ComponentModel;

[assembly: TagPrefix("eHR.Framework.Control", "aspx")]
namespace eHR.Framework.Control
{
    /// <summary>
    /// 해당 컨트롤은 GT Quick-Win 에서만 사용 됩니다.
    /// 버튼 을 대체 합니다.
    /// </summary>
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [ToolboxData("<{0}:ShEappLinkButton runat=server CssClass='btn_b'>button</{0}:ShEappLinkButton>")]
    public class ShEappLinkButton : System.Web.UI.WebControls.LinkButton
    {


        private int _WindowWidth = 1024;
        private int _WindowHeight = 768;
        private string _DocID = string.Empty;

        [Bindable(false),
       Category("Sh Window 창 띄우기 속성"),
       DefaultValue(""),
       Description("Window 창 넓이 (기본값은 1024 입니다)")]
        public int WindowWidth
        {
            get { return _WindowWidth; }
            set { _WindowWidth = value; }
        }

        [Bindable(false),
       Category("Sh Window 창 띄우기 속성"),
       DefaultValue(""),
       Description("Window 창 높이 (기본값은 768 입니다)")]
        public int WindowHeight
        {
            get { return _WindowHeight; }
            set { _WindowHeight = value; }
        }

       // [Bindable(false),
       //Category("Sh Window 창 띄우기 속성"),
       //DefaultValue(""),
       //Description("Window 창 DocID")]
        //public string DocID
        //{
        //    get { return _DocID; }
        //    set { _DocID = value; }
        //}

        [Bindable(false),
         Category("Sh Window 창 띄우기 속성"),
         DefaultValue(""),
         Description("Window 창 DocID")]
        public string DocID
        {
            get
            {
                if (this.ViewState["__Sh_DocID"] == null)
                {
                    this.ViewState["__Sh_DocID"] = "";
                }

                return this.ViewState["__Sh_DocID"].ToString();
            }
            set
            {
                this.ViewState["__Sh_DocID"] = value;
            }
        }

        /// <summary>
        /// 기본 버튼 스타일
        /// </summary>
        private const string CSSTYPE = "btn_b";

        public ShEappLinkButton()
        {

        }

        #region OnPreRender
        /// <summary>
        ///onPreRender Method
        /// </summary>
        /// <param name="e">이벤트 데이터가 들어 있는 <see cref="T:System.EventArgs"/> 개체입니다.</param>
        protected override void OnPreRender(EventArgs e)
        {
            string EappUrl = eHR.Framework.Common.Helper.GetAppConfig("EappUrl");
            if (!string.IsNullOrEmpty(DocID) && !string.IsNullOrEmpty(EappUrl))
            {
                //this.Attributes.Add("OnClick", "window.open ('" + EappUrl + "?ID=" + _DocID + "' ,'register','width=" + _WindowWidth + ", height=" + _WindowHeight + ", resizable=yes,left=524,top=268'); return false;");
                //this.OnClientClick = "window.open ('" + EappUrl + "?ID=" + _DocID + "' ,'register','width=" + _WindowWidth + ", height=" + _WindowHeight + ", resizable=yes,left=524,top=268'); return false;";

                // 이윤호 추가
                this.OnClientClick = "window.open ('" + EappUrl + "?_guid=" + DocID + "' ,'register','width=" + _WindowWidth + ", height=" + _WindowHeight + ", resizable=yes,left=524,top=268,scrollbars=yes'); return false;";
            }
            else
            {
                this.Text = string.Empty;
            }

            base.OnPreRender(e);

        }
        #endregion

           
        /// <summary>
        /// 기본 값 생성
        /// </summary>
        private void SetText()
        {
            // 없으면 추가
            if (this.Text.IndexOf("<span>") == -1)
            {
                this.Text = "<span>" + this.Text + "</span>";
            }
        }
    }
}
