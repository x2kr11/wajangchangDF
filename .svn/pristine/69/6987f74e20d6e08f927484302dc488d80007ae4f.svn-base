//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace eHR.Framework.Control
//{
//    class ShTextBox
//    {
//    }
//}
using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Security.Permissions;
using System.Web.UI.WebControls;
using System.Drawing;
using eHR.Framework.Enum;
using System.Text;

[assembly: TagPrefix("eHR.Framework.Control", "aspx")]
namespace eHR.Framework.Control
{

    //AspNetHostingPermission 권한의 Level이 적어도 Minimal인 상태에서 코드를 실행해야 합니다.
    // An interface that the transformer provides to the consumer.
    [AspNetHostingPermission(SecurityAction.Demand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [ToolboxBitmap(typeof(System.Web.UI.WebControls.TextBox))]
    [ToolboxData("<{0}:ShTextbox runat=server></{0}:ShTextbox>")]

    public class ShTextbox : System.Web.UI.WebControls.TextBox
    {
        #region ENUM 모음
       
        #endregion

        #region 클래스변수 모음
        private EChangeEnter isEnterTAB = EChangeEnter.TAB;
        private EImeMode mImeMode;         // IME-MODE
        private ETextType mTextType;       // 텍스트박스 동작모드
        private EStrongCheck mStrongCheck; // 유효성검사 강도
        private EHtmlCodeType mHtmlCodeType;
        private string mEnterActionButtonID = "";   // 엔터키를 쳤을때 클릭할 버튼 ID
        private bool mUseEnterAction = false; // 엔터키를눌렀을때 버튼을 클릭할것인지 여부
        private bool mReadOnly = true; // ReadOnly여부
        private string mUserBlurFunc = "";  // 사용자 정의 OnBlur 자바 스크립트
        private string mUserFocusFunc = ""; // 사용자 정의 OnFocus 자바 스크립트
        private int mPoint_Size = 1;  // 소수점 입력하는 숫자 및 금액의 소수점 길이 (Default = 1)
        private int mInteger_Size = 10;  // 소수점 입력하는 숫자 및 금액의 정수 길이 (Default = 10)
        private bool _renderUpLevel;
        private string strObjectName = string.Empty;
        private string _requiredMessage = string.Empty; //필수입력 메시지
        private string _ValidateGroup = string.Empty;   //유효성검사 그룹명
        private string _ExpressMessage = string.Empty;  //수식 입력 메시지
        private string _Express = string.Empty;         //수식
        private ExpressConfig _ExpressCondition;//적합 OR 부적합
        private string _compareMessage = string.Empty;  //비교 메시지
        private string _compareObject;   //비교할 object
             
        #endregion
        
        
        #region 프로퍼티 모음
        public new bool ReadOnly
        {
            get
            {
                return false;
            }
            set
            {
                if (value)
                {
                    this.Attributes.Add("readonly", "readonly");
                }
                else
                {
                    this.Attributes.Remove("readonly");
                }
            }
        }
        [Bindable(false),
        Category("Sh Validation 속성"),
        DefaultValue(""),
        Description("Validate Group이름")]
        public string ValidateGroup
        {
            get { return _ValidateGroup; }
            set { _ValidateGroup = value; }
        }

        [Bindable(false),
        Category("Sh Validation 속성"),
        DefaultValue(""),
        Description("필수입력 메시지")]
        public string RequiredMessage
        {
            get { return _requiredMessage; }
            set { _requiredMessage = value; }
        }
        
        [Bindable(false),
        Category("Sh Validation 속성"),
         DefaultValue(""),
        Description("수식 입력 메시지")]
        public string ExpressMessage
        {
            get { return _ExpressMessage; }
            set { _ExpressMessage = value; }
        }

        [Bindable(false),
        Category("Sh Validation 속성"),
        DefaultValue(""),
        Description("Validation 수식")]
        public string Express
        {
            get { return _Express; }
            set { _Express = value; }
        }

        [Bindable(false),
        Category("Sh Validation 속성"),
        DefaultValue(ExpressConfig.None),
        Description("Validation 수식 규칙(false--> Not")]
        public ExpressConfig ExpressCondition
        {
            get { return _ExpressCondition; }
            set { _ExpressCondition = value; }
        }

         [Bindable(false),
        Category("Sh Validation 속성"),
        DefaultValue(""),
        Description("비교대상 textbox id")]
        public string CompareTextbox
        {
            get { return _compareObject; }
            set { _compareObject = value; }
        }
             
         [Bindable(false),
        Category("Sh Validation 속성"),
         DefaultValue(""),
        Description("비교 입력 메시지")]
        public string CompareMessage
        {
            get { return _compareMessage; }
            set { _compareMessage = value; }
        }

        


        [Bindable(true),
        Category("Sh Textbox 속성 (Enter키 동작)"),
        DefaultValue(false),
        Description("엔터키를 눌렀을때 버튼을 클릭할것인지 여부")]
        public bool UseEnterAction
        {
            get { return mUseEnterAction; }
            set { mUseEnterAction = value; }
        }

        [Bindable(true),
        Category("Sh Textbox 속성 (Enter키 동작)"),
        DefaultValue(""),
        Description("엔터키를 쳤을때 클릭할 버튼 ID")]
        public string EnterActionButtonID
        {
            get { return mEnterActionButtonID; }
            set { mEnterActionButtonID = value; }
        }

        [Bindable(true),
        Category("Sh Textbox 속성 (사용자정의 자바 스크립트)"),
        DefaultValue(""),
        DescriptionAttribute("UserBlurFunc 속성은 이 컨트롤의 포커스를 벗어날때 호출되는 사용자 지정 자바스크립트 함수명입니다. 아무값도 넣지 않으면 작동하지 않습니다.")]
        public string UserBlurFunc
        {
            get
            {
                return mUserBlurFunc;
            }
            set
            {
                mUserBlurFunc = value;
            }
        }


        [Bindable(true),
        Category("Sh Textbox 속성 (사용자정의 자바 스크립트)"),
        DefaultValue(""),
        DescriptionAttribute("UserFocusFunc 속성은 이 컨트롤에 포커스가 들어올때 호출되는 사용자 지정 자바스크립트 함수명입니다. 아무값도 넣지 않으면 작동하지 않습니다.")]
        public string UserFocusFunc
        {
            get
            {
                return mUserFocusFunc;
            }
            set
            {
                mUserFocusFunc = value;
            }
        }

        [Bindable(true),
        Category("Sh Textbox 속성 (소수점 자리수)"),
        DefaultValue(1),
        DescriptionAttribute("Currency_Point 또는 Number_Point인경우 소수점 몇 자리까지 입력할것인지 입력한다. 0에서부터 20까지 입력가능")]
        public int PointSize
        {
            get
            {
                return this.mPoint_Size;
            }
            set
            {
                if (value >= 1 && value <= 20)
                {
                    mPoint_Size = value;
                }
                else
                {
                    mPoint_Size = 1;
                }
            }
        }


        [Bindable(true),
        Category("Sh Textbox 속성 (정수 자리수)"),
        DefaultValue(0),
        DescriptionAttribute("Currency_Point 또는 Number_Point인경우 입력한다.")]
        public int IntegerSize
        {
            get
            {
                return this.mInteger_Size;
            }
            set
            {
                mInteger_Size = value;
                MaxLength = mInteger_Size;
            }
        }

        [Bindable(true),
        Category("Sh Textbox 속성"),
        DefaultValue(EImeMode.Default),
        Description("한글/ 영문 초기모드 (최초 로딩시 선택되는 입력모드)")]
        public EImeMode ImeMode
        {
            get { return mImeMode; }
            set
            {
                mImeMode = value;
                switch (mImeMode)
                {
                    case EImeMode.Default:
                        this.Style["IME-MODE"] = "deactivated";
                        break;

                    case EImeMode.ENG:
                        this.Style["IME-MODE"] = "inactive";
                        break;

                    case EImeMode.KOR:
                        this.Style["IME-MODE"] = "active";
                        break;

                }
            }
        }

        [Bindable(true),
        Category("Sh Textbox 속성"),
        DefaultValue(EHtmlCodeType.None),
        Description("Text를 화면에 표시할때 Decode 할지를 결정")]
        public EHtmlCodeType HtmlCodeType
        {
            get { return mHtmlCodeType; }
            set
            {
                mHtmlCodeType = value;
            }
        }

        [Bindable(true),
        Category("Sh Textbox 속성"),
        DefaultValue(ETextType.Basic),
        Description("텍스트박스 동작 모드설정")]
        public ETextType TextType
        {
            get { return mTextType; }
            set
            {
                mTextType = value;
                switch (mTextType)
                {
                    // 주민번호 자리수 : 13자리
                    case ETextType.Jumin_No:
                        base.MaxLength = 13;
                        break;

                    // 사업자등록번호 : 10자리
                    case ETextType.Business_No:
                        base.MaxLength = 10;
                        break;

                    case ETextType.Time:
                        base.MaxLength = 8;
                        break;

                    case ETextType.Time_HHMM:
                        base.MaxLength = 5;
                        break;

                    case ETextType.IP_Address:
                        base.MaxLength = 12;
                        break;

                    case ETextType.IP_Address_C_Class:
                        base.MaxLength = 9;
                        break;

                    case ETextType.Machine_No:
                        base.MaxLength = 14;
                        break;

                    case ETextType.E_READER_INFO_PAGE:
                        base.MaxLength = 8;
                        break;

                    case ETextType.Jumin_BusinessNo:
                        base.MaxLength = 13;
                        break;
                }
            }
        }

        [Bindable(true),
        Category("Sh Textbox 속성"),
        DefaultValue(EStrongCheck.NormalCheck),
        Description("유효성검사 범위 설정 (StrongCheck : 강력한 유효성 검사)")]
        public EStrongCheck ValidLevel
        {
            get { return mStrongCheck; }
            set { mStrongCheck = value; }
        }

        [Bindable(true),
        Category("Sh Textbox 속성"),
       DefaultValue(EChangeEnter.TAB),
        Description("Enter키를 TAB로 전환할지 여부 (기본값 TAB키로 전환)")]
        public EChangeEnter ChangeEnterTAB
        {
            get { return isEnterTAB; }
            set { isEnterTAB = value; }
        }



        [Bindable(true),
        Category("동작"),
        DefaultValue(0),
        Description("최대 입력 가능한 문자수 (주민번호나 사업자등록번호에서는 무시됨)")]
        public override int MaxLength
        {
            get
            {
                return base.MaxLength;
            }
            set
            {
                base.MaxLength = value;
            }
        }

        [Bindable(true),
        Category("Sh Textbox 속성"),
        DefaultValue(""),
        Description("TextType에 따른 value값. ex) TextType이 Currency인 경우 Text값이 1,451,000이면 Value값은 1451000이다")]
        public string Value
        {
            get
            {
                string returnValue = "";
                switch (TextType)
                {
                    case ETextType.IP_Address:
                    case ETextType.IP_Address_C_Class:
                    case ETextType.NO_Korean:
                    case ETextType.Number:
                    case ETextType.Number_Point:
                    case ETextType.Basic:
                        returnValue = base.Text;
                        break;

                    case ETextType.Business_No:
                    case ETextType.NumberAndDash:
                    case ETextType.Jumin_No:
                    case ETextType.Machine_No:
                    case ETextType.Jumin_BusinessNo:
                        returnValue = base.Text.Replace("-", "");
                        break;
                    case ETextType.E_READER_INFO_PAGE:
                        returnValue = base.Text.Replace("/", "");
                        break;
                    case ETextType.Currency:
                    case ETextType.Currency_Point:
                        returnValue = base.Text.Replace(",", "");

                        if (returnValue == "")
                        {
                            returnValue = "0";
                        }
                        break;

                    case ETextType.Time:
                        returnValue = base.Text.Replace(":", "");
                        break;

                    case ETextType.Time_HHMM:
                        returnValue = base.Text.Replace(":", "");
                        break;
                }

                return returnValue.Trim().Replace("'", "\"");
            }
        }

        [Bindable(true),
        Category("Sh Textbox 속성"),
        DefaultValue(""),
        Description("Text Xss 적용하여 값을 가져옵니다.")]
        public string TextXss
        {
            get
            {
                string strVal = base.Text;


                strVal = strVal.Replace("<", "＜");
                strVal = strVal.Replace(">", "＞");
                strVal = strVal.Replace("&", "＆");
                strVal = strVal.Replace("'", "`");
                strVal = strVal.Replace("\"", "＂");
                strVal = strVal.Replace("#", "＃");
                strVal = strVal.Replace("\\", "￦");

                strVal = strVal.Replace("javas", "ｊａｖａ");
                strVal = strVal.Replace("JAVAS", "ＪＡＶＡＳ");
                strVal = strVal.Replace("Javas", "Ｊａｖａｓ");
                strVal = strVal.Replace("cript", "ｃｒｉｐｔ");
                strVal = strVal.Replace("CRIPT", "ＣＲＩＰＴ");
                strVal = strVal.Replace("iframe", "ｉｆｒａｍｅ");
                strVal = strVal.Replace("IFRAME", "ＩＦＲＡＭＥ");

                return strVal;

            }
        }

        [Bindable(true),
        Category("모양"),
        DefaultValue(""),
        Description("재정의된 Text 속성입니다. 텍스트 박스의 내용입니다.")]
        public override string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }
            set
            {
                string setValue = "";

                if (value == null)
                {
                    value = "";
                }

                switch (TextType)
                {
                    case ETextType.Business_No:

                        try
                        {
                            string tmpValue = value.Replace("-", "");

                            if (tmpValue.Length == 10)
                            {
                                setValue = tmpValue.Substring(0, 3) + "-" + tmpValue.Substring(3, 2) + "-" + tmpValue.Substring(5, 5);
                            }
                        }
                        catch (Exception)
                        {
                            setValue = value;
                        }

                        break;

                    case ETextType.Machine_No:

                        try
                        {
                            string tmpValue = value.Replace("-", "");

                            if (tmpValue.Length == 14)
                            {
                                setValue = tmpValue.Substring(0, 2) + "-" + tmpValue.Substring(2, 4) + "-" + tmpValue.Substring(6, 4) + "-" + tmpValue.Substring(10, 4);
                            }
                        }
                        catch (Exception)
                        {
                            setValue = value;
                        }

                        break;

                    case ETextType.Jumin_No:
                        try
                        {
                            string tmpValue = value.Replace("-", "");

                            if (tmpValue.Length == 13)
                            {
                                setValue = tmpValue.Substring(0, 6) + "-" + tmpValue.Substring(6);
                            }
                        }
                        catch (Exception)
                        {
                            setValue = value;
                        }

                        break;

                    case ETextType.Jumin_BusinessNo:
                        try
                        {
                            string tmpValue = value.Replace("-", "");

                            if (tmpValue.Length == 13)
                            {
                                setValue = tmpValue.Substring(0, 6) + "-" + tmpValue.Substring(6);
                            }
                            else if (tmpValue.Length == 10)
                            {
                                setValue = tmpValue.Substring(0, 3) + "-" + tmpValue.Substring(3, 2) + "-" + tmpValue.Substring(5, 5);
                            }
                            else
                            {
                                setValue = value;
                            }
                        }
                        catch (Exception)
                        {
                            setValue = value;
                        }

                        break;

                    case ETextType.E_READER_INFO_PAGE:
                        try
                        {
                            string tmpValue = value.Replace("/", "");

                            if (tmpValue.Length == 8)
                            {
                                setValue = tmpValue.Substring(0, 2) + "/" + tmpValue.Substring(2, 2) + "/" + tmpValue.Substring(4, 2) + "/" + tmpValue.Substring(6, 2);
                            }
                        }
                        catch (Exception)
                        {
                            setValue = value;
                        }
                        break;

                    case ETextType.Currency:

                        try
                        {
                            setValue = String.Format("{0:#,##0}", Convert.ToDecimal(value.Replace(",", "")));
                        }
                        catch (System.FormatException)
                        {
                            setValue = value;
                        }
                        catch (System.NullReferenceException)
                        {
                            setValue = value;
                        }
                        break;

                    case ETextType.Currency_Point:

                        try
                        {
                            setValue = String.Format("{0:#,##0.#####################}", Convert.ToDecimal(value.Replace(",", "")));
                        }
                        catch (System.FormatException)
                        {
                            setValue = value;
                        }
                        catch (System.NullReferenceException)
                        {
                            setValue = value;
                        }
                        break;

                    case ETextType.Number_Point:

                        try
                        {
                            setValue = String.Format("{0:#,##0.#####################}", Convert.ToDecimal(value));
                        }
                        catch (System.FormatException)
                        {
                            setValue = value;
                        }
                        catch (System.NullReferenceException)
                        {
                            setValue = value;
                        }
                        break;

                    case ETextType.Time:
                        try
                        {
                            string tmpValue = value.Replace(":", "");

                            if (tmpValue.Length == 6)
                            {
                                setValue = tmpValue.Substring(0, 2) + ":" + tmpValue.Substring(2, 2) + ":" + tmpValue.Substring(4, 2);
                            }
                            else
                            {
                                setValue = value;
                            }
                        }
                        catch (Exception)
                        {
                            setValue = value;
                        }

                        break;

                    case ETextType.Time_HHMM:
                        try
                        {
                            string tmpValue = value.Replace(":", "");

                            if (tmpValue.Length == 4)
                            {
                                setValue = tmpValue.Substring(0, 2) + ":" + tmpValue.Substring(2, 2);
                            }
                            else
                            {
                                setValue = value;
                            }
                        }
                        catch (Exception)
                        {
                            setValue = value;
                        }

                        break;

                    default:
                        setValue = value;
                        break;
                }


                switch (mHtmlCodeType)
                {
                    case EHtmlCodeType.Decode:
                        setValue = HttpUtility.HtmlDecode(setValue);
                        break;
                }

                ViewState["Text"] = setValue;
            }
        }

        #region ========== 페이지 인잇, 언로드 ==========

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            // 혹시 차후에 자바스크립트를 등록하려면 여기서 등록해라.
            _renderUpLevel = this.DetermineRenderUpLevel();

            if (_renderUpLevel)
            {
                string strScript = string.Empty;
                try
                {
                    strObjectName = "_cal_" + this.ClientID;
                    strScript = "<script language='javascript'>var " + strObjectName + " = new UtilTextBox.Textbox('" + strObjectName + "')</script>";
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }


                string url = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "eHR.Framework.Resources.GTTextBox.js");
                if (!this.Page.ClientScript.IsClientScriptIncludeRegistered("shButton"))
                    this.Page.ClientScript.RegisterClientScriptInclude(Page.GetType(), "shButton", url);

                if (!this.Page.ClientScript.IsClientScriptBlockRegistered(strObjectName))
                    this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), strObjectName, strScript);
            }

        }
        #endregion


        #endregion

        #region AddAttributesToRender : 텍스트박스 Type에 따른 렌더링

        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            string ClickBtnID = "";

            string userFocusFuncName = mUserFocusFunc.Trim() == "" ? "" : mUserFocusFunc.Trim();
            string userBlurFuncName = mUserBlurFunc.Trim() == "" ? "" : mUserBlurFunc.Trim();

            // 엔터키를 눌렀을때 클릭할 버튼의 ID를 구한다.
            if (UseEnterAction && EnterActionButtonID != "")
            {
                ClickBtnID = mEnterActionButtonID;
            }

            if (this.mTextType == ETextType.Number)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");

                // 숫자의 경우에는 무조건 오른쪽 정렬
                writer.AddStyleAttribute("text-align", "right");
                writer.AddStyleAttribute("padding-right", "5px");

                //writer.AddAttribute("OnKeyDown", strObjectName + ".NumericOnlyKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                //writer.AddAttribute("OnFocus", strObjectName + ".TxtSelect(this); " + userFocusFuncName);

            }
            else if (this.mTextType == ETextType.Number_Point)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");

                // 숫자의 경우에는 무조건 오른쪽 정렬
                writer.AddStyleAttribute("text-align", "right");
                writer.AddStyleAttribute("padding-right", "5px");

                writer.AddAttribute("OnKeyDown", strObjectName + ".NumericOnly_PointKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + this.mPoint_Size + "', '" + ClickBtnID + "')");
                writer.AddAttribute("OnFocus", strObjectName + ".TxtSelect(this); " + userFocusFuncName);

            }
            else if (this.mTextType == ETextType.NumberAndDash)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");

                writer.AddAttribute("OnKeyDown", strObjectName + ".NumericAndDash(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                writer.AddAttribute("OnFocus", strObjectName + ".TxtSelect(this); " + userFocusFuncName);
            }
            else if (this.mTextType == ETextType.Time)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");

                //writer.AddAttribute("OnKeyDown", strObjectName + ".NumericOnlyKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                //writer.AddAttribute("OnFocus", strObjectName + ".TxtTimeSelect(this); " + userFocusFuncName);
                ////writer.AddAttribute("OnBlur", strObjectName + ".TimeFormat(this); " + userBlurFuncName);
                //writer.AddAttribute("OnKeyUp", strObjectName + ".TimeKeyUp(this)");

                // 시간의 경우에는 가운데 정렬
                writer.AddStyleAttribute("text-align", "center");
            }
            else if (this.mTextType == ETextType.Time_HHMM)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");

                //writer.AddAttribute("OnKeyDown", strObjectName + ".NumericOnlyKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                //writer.AddAttribute("OnFocus", strObjectName + ".TxtTimeSelect(this); " + userFocusFuncName);
                ////writer.AddAttribute("OnBlur", strObjectName + ".TimeFormat_HHMM(this); " + userBlurFuncName);
                //writer.AddAttribute("OnKeyUp", strObjectName + ".TimeKeyUp_HHMM(this)");

                // 시간의 경우에는 가운데 정렬
                writer.AddStyleAttribute("text-align", "center");
            }

            else if (this.mTextType == ETextType.Currency)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");

                // 금액의 경우에는 무조건 오른쪽 정렬
                writer.AddStyleAttribute("text-align", "right");
                writer.AddStyleAttribute("padding-right", "5px");

                writer.AddAttribute("OnKeyDown", strObjectName + ".CurrencyKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                writer.AddAttribute("OnBlur", strObjectName + ".CommaFormat(this); " + userBlurFuncName);
                writer.AddAttribute("OnFocus", strObjectName + ".CurrencySelect(this); " + userFocusFuncName);
            }
            else if (this.mTextType == ETextType.Currency_Point)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");

                // 금액의 경우에는 무조건 오른쪽 정렬
                writer.AddStyleAttribute("text-align", "right");
                writer.AddStyleAttribute("padding-right", "5px");

                writer.AddAttribute("OnKeyDown", strObjectName + ".Currency_PointKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + this.mPoint_Size + "', '" + ClickBtnID + "')");
                writer.AddAttribute("OnBlur", strObjectName + ".CommaFormat(this); " + userBlurFuncName);
                writer.AddAttribute("OnFocus", strObjectName + ".CurrencySelect(this); " + userFocusFuncName);
            }
            else if (this.mTextType == ETextType.Jumin_No)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");
                writer.AddAttribute("MaxLength", "14");

                // 강력한 유효성 체크한 경우
                if (this.mStrongCheck == EStrongCheck.StrongCheck)
                {
                    //writer.AddAttribute("OnBlur", strObjectName + ".CheckJuminBunho(this); " + userBlurFuncName);
                }
                else
                {
                    //writer.AddAttribute("OnBlur", strObjectName + ".ShowJuminBunho(this); " + userBlurFuncName);
                }

                //writer.AddAttribute("OnKeyDown", strObjectName + ".JuminNoKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                //writer.AddAttribute("OnFocus", strObjectName + ".NumTxtSelect(this); " + userFocusFuncName);
            }
            else if (this.mTextType == ETextType.E_READER_INFO_PAGE)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");
                writer.AddAttribute("MaxLength", "8");
                //writer.AddAttribute("OnBlur", strObjectName + ".ShowPageNo(this); " + userBlurFuncName);
                //writer.AddAttribute("OnKeyDown", strObjectName + ".PageNoKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                //writer.AddAttribute("OnFocus", strObjectName + ".NumPageSelect(this); " + userFocusFuncName);
            }

            else if (this.mTextType == ETextType.Business_No)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");
                writer.AddAttribute("MaxLength", "10");

                // 강력한 유효성 체크한 경우
                if (this.mStrongCheck == EStrongCheck.StrongCheck)
                {
                   // writer.AddAttribute("OnBlur", strObjectName + ".chkBusiness_no(this); " + userBlurFuncName);
                }
                else
                {
                   // writer.AddAttribute("OnBlur", strObjectName + ".ShowBusiness_no(this); " + userBlurFuncName);
                }

                //writer.AddAttribute("OnKeyDown", strObjectName + ".BusinessNoKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                //writer.AddAttribute("OnFocus", strObjectName + ".NumTxtSelect(this); " + userFocusFuncName);
            }
            else if (this.mTextType == ETextType.Machine_No)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");
                writer.AddAttribute("MaxLength", "14");
                //writer.AddAttribute("OnBlur", strObjectName + ".ShowMachineNo(this); " + userBlurFuncName);

                writer.AddAttribute("OnKeyDown", strObjectName + ".MachineNoKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                writer.AddAttribute("OnFocus", strObjectName + ".NumTxtSelect(this); " + userFocusFuncName);
            }
            else if (this.mTextType == ETextType.IP_Address)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");

                //writer.AddAttribute("OnKeyDown", strObjectName + ".NumericOnlyKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                //writer.AddAttribute("OnFocus", strObjectName + ".IP_TxtSelect(this); " + userFocusFuncName);
                //writer.AddAttribute("OnBlur", strObjectName + ".ShowIP(this); " + userBlurFuncName);
            }
            else if (this.mTextType == ETextType.IP_Address_C_Class)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");

                //writer.AddAttribute("OnKeyDown", strObjectName + ".NumericOnlyKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                //writer.AddAttribute("OnFocus", strObjectName + ".IP_TxtSelect(this); " + userFocusFuncName);
                //writer.AddAttribute("OnBlur", strObjectName + ".ShowIP(this); " + userBlurFuncName);
            }
            else if (this.mTextType == ETextType.Jumin_BusinessNo)
            {
                // 한글입력을 원천적으로 봉쇄한다.
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");
                writer.AddAttribute("MaxLength", "13");

                //writer.AddAttribute("OnKeyDown", strObjectName + ".NumericOnlyKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "')");
                //writer.AddAttribute("OnFocus", strObjectName + ".TxtSelect(this); " + userFocusFuncName);
                //writer.AddAttribute("OnBlur", strObjectName + ".ShowJuminBusiness(this); " + userBlurFuncName);
            }
            else if (this.mTextType == ETextType.NO_Korean)
            {
                // 한글입력 금지 
                this.Style.Remove("IME-MODE");
                writer.AddStyleAttribute("IME-MODE", "disabled");
            }
            else
            {
                //writer.AddAttribute("OnFocus", strObjectName + ".TxtSelect(this); " + userFocusFuncName);
                //writer.AddAttribute("OnKeyDown", strObjectName + ".BasicKeyDown(this, '" + this.isEnterTAB.ToString() + "', '" + this.TextMode + "', '" + ClickBtnID + "'); ");
            }
            //ClientScriptManager csm = Page.ClientScript;
            //writer.AddAttribute("OnFocus", strObjectName + ".TxtSelect(this); " + userFocusFuncName);
            
            if (!mReadOnly)
            {
                writer.AddAttribute("ReadOnly", "ReadOnly");
            }

            //// 지정된 CssClass가 없다면 디폴트 CssClass를 지정해준다.
            //if (ReadOnly)
            //{
            //    if (this.CssClass == "")
            //    {
            //        if (this.TextMode == TextBoxMode.MultiLine)
            //        {
            //            this.CssClass = "rbox_textarea";
            //        }
            //        else
            //        {
            //            this.CssClass = "rbox";
            //        }
            //    }

            //    this.TabIndex = -1;
            //}
            //else
            //{
            //    if (this.CssClass == "")
            //    {
            //        if (this.TextMode == TextBoxMode.MultiLine)
            //        {
            //            this.CssClass = "box_textarea";
            //        }
            //        else
            //        {
            //            this.CssClass = "box";
            //        }
            //    }
            //}

           

            base.AddAttributesToRender(writer);
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

        #region OnPreRender
        /// <summary>
        ///onPreRender Method
        /// </summary>
        /// <param name="e">이벤트 데이터가 들어 있는 <see cref="T:System.EventArgs"/> 개체입니다.</param>
        protected override void OnPreRender(EventArgs e)
        {

            base.OnPreRender(e);

        
        }
        #endregion

        #region Render 메소드
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
        }
        #endregion

        #region 메소드
        
        #endregion
    }
}