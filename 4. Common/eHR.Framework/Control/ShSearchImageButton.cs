using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;
using System.Web.UI.WebControls;
using System.Drawing;
using eHR.Framework.Enum;

[assembly: TagPrefix("eHR.Framework.Control", "aspx")]
namespace eHR.Framework.Control
{
    /// <summary>
    /// 해당 컨트롤은 GT Quick-Win 에서만 사용 됩니다.
    /// 버튼 을 대체 합니다.
    /// </summary>
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [ToolboxData("<{0}:ShSearchImageButton runat=server />")]
    public class ShSearchImageButton : System.Web.UI.WebControls.ImageButton
    {
        /// <summary>
        /// 기본 버튼 스타일
        /// </summary>
        private const string CSSTYPE = "btn_b";

        public ShSearchImageButton()
        {

        }

        #region OnPreRender
        /// <summary>
        ///onPreRender Method
        /// </summary>
        /// <param name="e">이벤트 데이터가 들어 있는 <see cref="T:System.EventArgs"/> 개체입니다.</param>
        protected override void OnPreRender(EventArgs e)
        {

            this.Attributes.Add("onmouseover", "this.src='/images/btn_search_on.jpg'");
            this.Attributes.Add("onmouseout", "this.src='/images/btn_search.jpg'");
            this.Attributes.Add("src", "/images/btn_search.jpg");
            this.SetText();

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
                //this.Text = "<span>" + this.Text + "</span>";
                this.Text = this.Text;
            }
        }
    }
}