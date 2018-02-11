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
    /// gtCalendarBox CLass
    /// </summary>


    //AspNetHostingPermission 권한의 Level이 적어도 Minimal인 상태에서 코드를 실행해야 합니다.
    // An interface that the transformer provides to the consumer.
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [ToolboxBitmap(typeof(eHR.Framework.Control.ShButton), "eHR.Framework.Resources.ShCalendar.gif")]
    [ToolboxData("<{0}:ShCalendar runat=server></{0}:ShCalendar>")]
    [DefaultProperty("Text")]

    public class ShCalendar : WebControl
    {
        #region ENUM 모음
        /// <summary>
        /// can set a Dataformat.
        /// </summary>
        public enum DataFormat
        {
            /// <summary>
            /// yyyymmdd type
            /// </summary>
            YYYY_MM_DD,
            /// <summary>
            /// yyyymmdd type
            /// </summary>
            YYYY_MM,
            /// <summary>
            /// yyyymmdd type
            /// </summary>
            YYYY,
            /// <summary>
            /// mmddyyyy type
            /// </summary>
            DD_MM_YYYY,
            /// <summary>
            /// mmddyyyy type
            /// </summary>            
            MM_YYYY
        }

        /// <summary>
        /// Type of Delimeter for Calander Control
        /// </summary>
        public enum DelimiterType
        {
            /// <summary>
            /// -
            /// </summary>
            Dash,
            /// <summary>
            /// /
            /// </summary>
            Slash
        }
        #endregion

        #region Field
        private Unit width = Unit.Pixel(60);
        private TextBox gtTextBox;

        private System.Web.UI.WebControls.Image gtImage;
        private System.Web.UI.WebControls.Image gtImage2;
        private Panel gtPanel;
        private Label lblFrame;
        private DataFormat _gtDataFormat = DataFormat.YYYY_MM_DD;
        //private string gtDelimiter;
        private bool gtTBReadOnly;
        //private string gtImageURL;
        private string strObjectName = string.Empty;
        private string id;
        /// <summary>
        /// determine the rendering level
        /// </summary>
        private bool _renderUpLevel;

        ClientScriptManager csManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="gtCalendarBox"/> class.
        /// </summary>
        public ShCalendar()
        {

        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating whether [render up level].
        /// </summary>
        /// <value><c>true</c> if [render up level]; otherwise, <c>false</c>.</value>
        public bool RenderUpLevel
        {
            get
            {
                return _renderUpLevel;
            }
        }

        //[
        //Category("Sh Calendar 속성"),
        //Description("The ID")
        //]
        //public override string ID
        //{
        //    get
        //    {
        //        return id;
        //    }
        //    set
        //    {
        //        id = value;
        //        this.UniqueID = TextUniqueID;
        //    }
        //}

        [
        Category("Sh Calendar 속성"),
        Description("Text ID")
        ]
        public string TextUniqueID
        {
            get
            {
                string[] arr = this.UniqueID.Split('$');

                string _id = arr[0];

                for (int i = 1; i < arr.Length - 1; i++)
                {
                    _id = string.Concat(arr[i], "$", arr[i]);
                }

                return string.Format("{0}${1}", _id, ID);
            }
        }

        [
        Category("Sh Calendar 속성"),
        Description("Text ID")
        ]
        public string TextClientID
        {
            get
            {
                string[] arr = this.ClientID.Split('_');

                string _id = arr[0];

                for (int i = 1; i < arr.Length - 1; i++)
                {
                    _id = string.Concat(_id, "_", arr[i]);
                }

                return string.Format("{0}_{1}", _id, ID);
            }
        }

        [
        Category("Sh Calendar 속성"),
        Description("The TextBox's Text property.")
        ]
        public string Text
        {
            get
            {
                EnsureChildControls();
                return gtTextBox.Text;
            }
            set
            {
                EnsureChildControls();
                gtTextBox.Text = value;
            }
        }



        [
        Category("Sh Calendar 속성"),
        Description("The CssClass.")
        ]
        public override string CssClass
        {
            get
            {
                EnsureChildControls();
                return gtTextBox.CssClass;
            }
            set
            {
                EnsureChildControls();
                gtTextBox.CssClass = value;
            }
        }

        [
        Themeable(true),
        Category("Sh Calendar 속성"),
        Description("The TextBox's Width property.")
        ]
        public override Unit Width
        {
            get
            {
                EnsureChildControls();
                return width;
            }
            set
            {
                EnsureChildControls();
                width = value;
                gtTextBox.Width = width;
            }
        }

        [
        Category("Sh Calendar 속성"),
        Description("The TextBox's Height property.")
        ]
        public override Unit Height
        {
            get
            {
                EnsureChildControls();
                return gtTextBox.Height;
            }
            set
            {
                EnsureChildControls();
                gtTextBox.Height = value;
            }
        }


        [
        Category("Sh Calendar 속성"),
        Description("The TextBox's ReadOnly property.")
        ]
        public bool ReadOnly
        {
            get
            {
                EnsureChildControls();
                return gtTBReadOnly;
            }
            set
            {
                EnsureChildControls();
                gtTBReadOnly = value;
            }

        }

        [
        Category("Sh Calendar 속성"),
        Description("Can Select one of the DataFormat.")
        ]
        public DataFormat sDataFormat
        {
            get
            {
                EnsureChildControls();
                return _gtDataFormat;
            }
            set
            {
                EnsureChildControls();
                _gtDataFormat = value;
            }
        }


        [
        Category("Sh Calendar 속성"),
        Description("set the image path")
        ]
        public DelimiterType sDelimiterType
        {
            get
            {
                if (this.ViewState["__gt_DELI_TYPE__"] == null)
                {
                    return DelimiterType.Dash;
                }
                else
                    return (DelimiterType)this.ViewState["__gt_DELI_TYPE__"];
            }
            set
            {
                this.ViewState["__gt_DELI_TYPE__"] = value;
            }
        }

        [
        Category("Sh Calendar 속성"),
        Description("set the CalType")
        ]
        public CALType calType
        {
            get
            {
                if (this.ViewState["__gt_CALType__"] == null)
                {
                    return CALType.DD;
                }
                else
                    return (CALType)this.ViewState["__gt_CALType__"];
            }
            set
            {
                this.ViewState["__gt_CALType__"] = value;
            }
        }

        [
        Category("Sh Calendar 속성"),
        Description("set the DELType")
        ]
        public bool DELType
        {
            get
            {
                if (this.ViewState["__gt_DELType__"] == null)
                {
                    return false;
                }
                else
                    return (bool)this.ViewState["__gt_DELType__"];
            }
            set
            {
                this.ViewState["__gt_DELType__"] = value;
            }
        }
        #endregion

        #region Method

        #region CreateChildControls
        /// <summary>
        /// the method to create childcontrols
        /// </summary>
        protected override void CreateChildControls()
        {
            try
            {
                Controls.Clear();

                gtImage = new System.Web.UI.WebControls.Image();
                gtImage2 = new System.Web.UI.WebControls.Image();

                gtImage.ImageAlign = ImageAlign.AbsMiddle;
                gtImage2.ImageAlign = ImageAlign.AbsMiddle;

                gtTextBox = new TextBox();
                gtTextBox.Width = this.width;
                gtTextBox.ID = string.Format("{0}{1}", this.ClientID, ID);
                gtTextBox.MaxLength = 10;


                gtPanel = new Panel();
                gtPanel.ID = ID + "gtPanel";
                gtPanel.Attributes.Add("style", "display:none");
                gtPanel.Attributes.Add("style", "z-index:4000;");

                this.lblFrame = new Label();
                this.lblFrame.Height = 20;
                this.lblFrame.Style["padding"] = "0";
                this.Controls.Add(gtImage);
                this.Controls.Add(gtImage2);
                this.Controls.Add(gtTextBox);
                this.Controls.Add(gtPanel);
                this.Controls.Add(this.lblFrame);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region OnInit
        /// <summary>
        /// 	<see cref="E:System.Web.UI.Control.Init"/> 
        /// </summary>
        /// <param name="e"> <see cref="T:System.EventArgs"/> </param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            EnsureChildControls();
        }
        #endregion

        #region DetermineRenderUpLevel
        /// <summary>
        /// this method determines rendering level
        /// </summary>
        /// <returns></returns>
        protected virtual bool DetermineRenderUpLevel()
        {
            if (!DesignMode)
            {
                HttpBrowserCapabilities browser = Page.Request.Browser;


                if (browser.W3CDomVersion.Major >= 1 && browser.EcmaScriptVersion.CompareTo(new Version(1, 2)) >= 0)
                    return true;
                else
                    return false;
            }
            return true;
        }
        #endregion

        #region AddAttributesToRender
        /// <summary>
        /// This method makes a attribute for a validation
        /// </summary>
        /// <param name="writer"></param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            try
            {
                _renderUpLevel = this.DetermineRenderUpLevel();

                if (RenderUpLevel)
                {

                    if (this.gtTBReadOnly)
                    {
                        this.gtTextBox.ReadOnly = true;
                    }

                    gtImage.ImageUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "eHR.Framework.Resources.ShCalendar.gif");

                    if (!this.gtTBReadOnly)
                    {
                        gtImage.Attributes.Add("onclick", strObjectName + ".displayCal('" + this.calType.ToString() + "')");
                        gtImage.Attributes.Add("style", "cursor:pointer;vertical-align:middle;");
                    }

                    if (this.DELType)
                    {
                        gtImage2.ImageUrl = Page.ClientScript.GetWebResourceUrl(this.GetType(), "eHR.Framework.Resources.btnEraser.gif");

                        if (!this.gtTBReadOnly)
                        {
                            gtImage2.Attributes.Add("onclick", strObjectName + ".erase('" + gtTextBox.ClientID + "')");
                            gtImage2.Attributes.Add("style", "cursor:pointer;");
                        }
                        gtImage2.Attributes.Add("alt", "날짜삭제");
                        gtImage2.Attributes.Add("title", "날짜삭제");
                    }
                    gtImage.Attributes.Add("alt", "날짜선택");
                    gtImage.Attributes.Add("title", "날짜선택");


                    gtTextBox.Style.Remove("IME-MODE");
                    gtTextBox.Attributes.Add("onchange", strObjectName + ".getFormValue(); " + strObjectName + ".hide();");
                    gtTextBox.Attributes.Add("IME-MODE", "disabled");

                    gtTextBox.Attributes.Add("OnKeyDown", strObjectName + ".CalendarKeyDown(" + gtTextBox.ClientID + ")");
                    gtTextBox.Attributes.Add("OnBlur", strObjectName + ".CalendarKeyUp(" + gtTextBox.ClientID + ",'" + this.calType.ToString() + "')");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            base.AddAttributesToRender(writer);
        }
        #endregion

        #region OnPreRender
        /// <summary>
        ///onPreRender Method
        /// </summary>
        /// <param name="e">이벤트 데이터가 들어 있는 <see cref="T:System.EventArgs"/> 개체입니다.</param>
        protected override void OnPreRender(EventArgs e)
        {

            base.OnPreRender(e);

            _renderUpLevel = this.DetermineRenderUpLevel();

            if (_renderUpLevel)
            {
                csManager = this.Page.ClientScript;
                string strScript = string.Empty;
                try
                {
                    strObjectName = "_cal_" + this.ClientID;
                    string strDelimiterType = string.Empty;
                    string strTargetId = this.gtPanel.UniqueID.Replace("$", "_");
                    //string strTargetLabelId = this.gtLabel.UniqueID.Replace("$", "_");
                    string strTextBoxId = gtTextBox.UniqueID.Replace("$", "_");
                    strDelimiterType = GetDelimiterType(sDelimiterType);
                    strScript = "<script language='javascript'>var " + strObjectName + " = new Utils.Calendar('" + strObjectName + "', '" + strTargetId + "', '" + strTextBoxId + "','" + sDataFormat.ToString().ToLower() + "','" + strDelimiterType + "','')</script>";


                    //this.gtPanel.Attributes.Add("style", "POSITION: absolute; TOP:200px");
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }


                string url = csManager.GetWebResourceUrl(this.GetType(), "eHR.Framework.Resources.ShCalendarJS.js");
                if (!csManager.IsClientScriptIncludeRegistered("sCalendar"))
                    csManager.RegisterClientScriptInclude(Page.GetType(), "sCalendar", url);

                if (!csManager.IsClientScriptBlockRegistered(strObjectName))
                    csManager.RegisterClientScriptBlock(this.GetType(), strObjectName, strScript);

            }

        }
        #endregion

        #region Render
        /// <summary>
        /// Render Method
        /// </summary>
        /// <param name="writer"> <see cref="T:System.Web.UI.HtmlTextWriter"/> </param>
        protected override void Render(HtmlTextWriter writer)
        {
            try
            {
                //CreateChildControls();
                EnsureChildControls();
                AddAttributesToRender(writer);

                Table tb = new Table();
                TableRow tr = new TableRow();
                TableCell td = new TableCell();
                //tb.Style["border"] = "none";
                tb.BorderStyle = BorderStyle.None;
                tb.BorderWidth = 0;
                tb.Style["padding"] = "0";

                tb.CellPadding = 0;
                tb.CellSpacing = 0;
                tb.Width = 60;
                tb.Height = 10;

                //td.Controls.Add(gtPanel);
                //tr.Controls.Add(td);

                td = new TableCell();
                td.Style["padding"] = "0";
                td.BorderStyle = BorderStyle.None;
                td.BorderWidth = 0;
                td.Controls.Add(gtPanel);
                td.Controls.Add(gtTextBox);
                tr.Controls.Add(td);

                td = new TableCell();
                td.Style["padding-left"] = "3px";
                td.BorderStyle = BorderStyle.None;
                td.BorderWidth = 0;
                td.Controls.Add(gtImage);
                tr.Controls.Add(td);


                if (this.DELType)
                {
                    td = new TableCell();
                    td.Style["padding-left"] = "3px";
                    td.BorderStyle = BorderStyle.None;
                    td.BorderWidth = 0;
                    td.Controls.Add(gtImage2);
                    tr.Controls.Add(td);
                }

                tb.Controls.Add(tr);

                lblFrame.Controls.Add(tb);

                lblFrame.RenderControl(writer);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
        #endregion

        #region GetDelimiterType
        /// <summary>
        /// Gets the type of the delimiter.
        /// </summary>
        /// <param name="Type">Type of the STR.</param>
        /// <returns></returns>
        private string GetDelimiterType(DelimiterType Type)
        {
            string strDelimiterType = string.Empty;
            switch (Type)
            {
                case DelimiterType.Dash:
                    strDelimiterType = "-";
                    break;
                case DelimiterType.Slash:
                    strDelimiterType = "/";
                    break;
                default:
                    strDelimiterType = "-";
                    break;

            }
            return strDelimiterType;

        }
        #endregion

        #endregion
    }
}
