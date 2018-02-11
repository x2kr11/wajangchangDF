
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
    [ToolboxData("<{0}:ShButton runat=server></{0}:ShButton>")]
    public class ShButton : System.Web.UI.WebControls.Button
    {
        private EPermissionBtnType mPermissionBtnType = EPermissionBtnType.NotSet;

        /// <summary>
        /// 버튼권한 타입
        /// </summary>
        [Category("ShControl 속성(권한 설정 관련)"),
        DefaultValue(EPermissionBtnType.NotSet),
        DescriptionAttribute("버튼의 타입을 설정합니다. 권한에 따라 상태가 변경되길 원한다면 타입을 지정해주시기 바랍니다.")]
        public EPermissionBtnType PermissionBtnType
        {
            get
            {
                return mPermissionBtnType;
            }
            set
            {
                mPermissionBtnType = value;
            }
        }
        
        #region OnInit
        protected override void OnInit(EventArgs e)
        {
            this.TabIndex = -1;

            base.OnInit(e);

            this.Attributes["onmouseover"] = "this.style.cursor='pointer';";
       
        }
        #endregion

        #region OnLoad
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

        }

        public override string OnClientClick
        {
            get
            {
                string strClientClick = string.Empty;
                if (this.DisplayLoading == true)
                {
                    if (string.IsNullOrEmpty(base.OnClientClick))
                    {
                        strClientClick = "LoadingShow();";
                    }
                    else
                    {
                        strClientClick = " if (true ==" + base.OnClientClick.Replace("return", "").Replace(";", "") + " ) {LoadingShow();} else {return false;}";
                    }
                }
                else
                {
                    strClientClick = base.OnClientClick;
                }
                return strClientClick;
            }
            set
            {
                base.OnClientClick = value;
            }
        }
       #endregion

        #region PreRender 메소드
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                this.SetText();
            }

            base.OnPreRender(e);
        }
        #endregion

        #region AddAttributesToRender
        #endregion

        #region RenderContents
        protected override void RenderContents(HtmlTextWriter output)
        {
            base.RenderContents(output);
        }
        #endregion

        #region 다국어 메소드
        /// <summary>
        /// 다국어 리소스에서 데이타를 조회하고 화면에 Text 속성에 값을 할당 합니다.
        /// </summary>
        private void SetText()
        {
            if (!Page.IsPostBack)
            {
                if (this.ShResxName.Length > 0 && this.ShResxType != ResX.None)
                {
                    string strClass = "Mosti.MultiLanguage.DataSource|" + this.ShResxType.ToString();
                    string strValue =
                        // Mosti.MultiLanguage.ExternalResourceExpressionBuilder.GetGlobalResourceObject(strClass, this.ShResxName) as string;
                       "";
                    if (!string.IsNullOrEmpty(strValue))
                    {
                        this.Text = strValue;
                    }
                }
            }
        }

        /// <summary>
        /// resx파일의 Name값을 설정합니다.
        /// </summary>
        [
        Themeable(false), Category("ShControls"),
        Description("다국어를 지원 합니다. resx파일의 Name값을 설정합니다.")
        ]
        public string ShResxName
        {
            get
            {
                if (this.ViewState["__Sh_REX_NAME"] == null)
                {
                    return string.Empty;
                }
                else
                {
                    return (string)this.ViewState["__Sh_REX_NAME"];
                }
            }
            set
            {
                this.ViewState["__Sh_REX_NAME"] = value;
            }
        }

        /// <summary>
        /// Mosti.Web.Controls.Enums.ResX 형식의 리소스타입을 설정 합니다.
        /// </summary>
        [
        Themeable(false), Bindable(true), Category("ShControls"),
        Description("다국어를 지원 합니다. 리소스타입을 설정 합니다."),
        DefaultValue(ResX.None)
        ]
        public ResX ShResxType
        {
            get
            {
                if (this.ViewState["__Sh_REX_TYPE"] == null)
                {
                    return ResX.None;
                }
                else
                {
                    return (ResX)this.ViewState["__Sh_REX_TYPE"];
                }
            }
            set
            {
                this.ViewState["__Sh_REX_TYPE"] = value;
            }
        }


        private bool bLoadingVisiable = false;
        [Bindable(true),
        DefaultValue(false), Category("ShControls"),
        Description("클릭시 Loading 표시 여부")]
        public bool DisplayLoading
        {
            get
            {
                return this.bLoadingVisiable;
            }

            set
            {
                this.bLoadingVisiable = value;
            }
        }

        #endregion
    }
}
