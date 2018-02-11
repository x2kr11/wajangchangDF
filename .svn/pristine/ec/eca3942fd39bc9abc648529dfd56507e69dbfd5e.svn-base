
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
    /// 버튼 컨트롤 입니다.
    /// </summary>
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [ToolboxData("<{0}:ShLiteral runat=server></{0}:ShLiteral>")]
    public class ShLiteral : System.Web.UI.WebControls.Literal
    {
        /// <summary>
        /// 작성자 : 이윤호
        /// 설  명 : Xss에 맞게 Text 재정의
        /// </summary>
        new public string Text  
        {
            get
            {
                //if (this.DesignMode)
                    
                    return base.Text;
            }
            set
            {
                if (!this.DesignMode)
                {
                    if (IsXss)
                        base.Text = SetHtmlEncode(value);
                    else
                        base.Text = value;
                }
            }
        }

        /// <summary>
        /// TextXss 사용 하면 css 적용
        /// </summary>
        public string TextXss
        {
            private get
            {
                return this.Text;
            }
            set
            {
                IsXss = true;
                //if (IsXss)
                //{
                this.Text = value;
                //}
                //else
                //{
                //    this.Text = value;
                //}
            }
        }

        #region # IsXss Backup() 
        /// <summary>
        /// Xss 사용 여부
        /// </summary>
        //public bool IsXss
        //{
        //    get
        //    {
        //        if (this.ViewState["__Sh_IsXss"] == null)
        //        {
        //            this.ViewState["__Sh_IsXss"] = true;
        //        }

        //        return Convert.ToBoolean(this.ViewState["__Sh_IsXss"]);
        //    }
        //    set
        //    {
        //        this.ViewState["__Sh_IsXss"] = value;
        //    }
        //}
        #endregion

        bool isXss = true;

        public bool IsXss
        {
            get
            {
                return isXss;

            }
            set
            {
                isXss = value;
            }
        }

        /// <summary>
        /// HtmlEncode 적용
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string SetHtmlEncode(string value)
        {
            return this.Context.Server.HtmlEncode(value).Replace("\r\n", "<br>");
        }

        /// <summary>
        /// HtmlEncode 적용
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private string SetHtmlDecode(string value)
        {
            return this.Context.Server.HtmlDecode(value).Replace("<br>", "\r\n");
        }
    }
}
