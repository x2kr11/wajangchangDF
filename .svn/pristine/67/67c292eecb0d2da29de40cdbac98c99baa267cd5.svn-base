using System;
using System.Linq;
using Skcc.Configuration;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web;
using eHR.Framework.Common;
using System.Collections.Specialized;
using System.Web.Security;
using eHR.Framework.Sessions;
using System.Data;


namespace eHR.Framework.Base
{
    public enum MasterPageType
    {
        Main,
        LayerPopup
    }

    public class ShBase : System.Web.UI.Page, IClientPopMessage
    {
        private bool _checkAuthenticated = true;

        /// <summary>
        /// 폼인증 여부를 확인 하지 않습니다.
        /// </summary>
        public bool CheckAuthenticated
        {
            get { return _checkAuthenticated; }
            set { _checkAuthenticated = value; }
        }

        public ShBase()
        {
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected override void OnInit(EventArgs e)
        {
            //// 시나리오 : 로그인 시도시 ShBaseAuth.SetLogin()에서  Helper.GetAppConfig("Rms_RollDataSet_SaveSession") == "true"인경우
            ////            Session에 RMS DataSet을 넣는다.
            ////           Helper.GetAppConfig("Rms_RollDataSet_SaveSession") <> "true" 경우에는 Rms를 가져와서 Context에 넣어 준다.

            //#region # 2. 권한 체크 

            //if (_checkAuthenticated)
            //{
            //    // 요청한 페이지가 Web.Config에 등록된 로그인 페이지라면 세션들의 값을 모두 삭제 시킨다.
            //    if (FormsAuthentication.LoginUrl.ToUpper().Equals(this.Page.Request.Path.ToUpper()))
            //    {
            //        // Web.Config에 설정된 LoginUrl로 들어온 경우 입니다.
            //        Helper.SetClearFormsAuthenticationAndSession();
            //    }
            //    else
            //    {
            //        //#region # 로그인 인증이 된 경우 처리
            //        //if (HttpContext.Current.User.Identity.IsAuthenticated)
            //        //{
            //        //    DataSet dsRms;
            //        //    string strRmsSaveType = Helper.GetAppConfig("Rms_RollDataSet_SaveSession");
            //        //    string strRmsUser = (Helper.GetAppConfig("Rms_RollUserId") == string.Empty) ? UserProfile.Id : Helper.GetAppConfig("Rms_RollUserId");

            //        //    #region # Get Roll Data = Session인 경우
            //        //    if (!string.IsNullOrEmpty(strRmsSaveType) && strRmsSaveType.ToLower() == "true")
            //        //    {
            //        //        // 로그인시에 Session을 넣게 되는데 Form 인증시 Session과의 시간 차이로 인해서 Session이 죽는 현상이 발생 한다. 이 현상을 보완 한다.
            //        //        if (this.Page.Session[UserProfile.SESSION_ROLLDATA_NAME] == null)
            //        //        {
            //        //            // 아래는 임시로 주석 처리 by swarry
            //        //            dsRms = new DataSet(); // ShBaseAuth.GetRmsPagePermission(strRmsUser);

            //        //            this.Page.Session[UserProfile.SESSION_ROLLDATA_NAME] = UserEncrypt(Helper.CompressDataSet(dsRms));
            //        //            Context.Items[UserProfile.CONTEXT_ROLLDATASET_NAME] = dsRms;
            //        //        }
            //        //        else
            //        //        {
            //        //            string strRmsContextRollData = this.Page.Session[UserProfile.SESSION_ROLLDATA_NAME] as string;
            //        //            dsRms = this.Context.Items[UserProfile.CONTEXT_ROLLDATASET_NAME] as DataSet;

            //        //            if (dsRms.IsNullOrEmpty())
            //        //            {
            //        //                dsRms = Helper.DeserializeFromString(UserDecrypt(strRmsContextRollData));

            //        //                if (dsRms.IsNullOrEmpty())
            //        //                    // 아래는 임시로 주석 처리 by swarry
            //        //                    dsRms = new DataSet(); //ShBaseAuth.GetRmsPagePermission(strRmsUser);

            //        //                this.Page.Session[UserProfile.SESSION_ROLLDATA_NAME] = UserEncrypt(Helper.CompressDataSet(dsRms));
            //        //                Context.Items[UserProfile.CONTEXT_ROLLDATASET_NAME] = dsRms;
            //        //            }
            //        //        }
            //        //    }
            //        //    #endregion

            //        //    #region # Get Roll Data = Real
            //        //    else
            //        //    {
            //        //        // 아래는 임시로 주석 처리 by swarry
            //        //        dsRms = new DataSet(); // ShBaseAuth.GetRmsPagePermission(strRmsUser);
            //        //        Context.Items[UserProfile.CONTEXT_ROLLDATASET_NAME] = dsRms;
            //        //    }
            //        //    #endregion
            //        //}
            //        //#endregion

            //        //#region # 로그인 인증이 안된 경우 처리
            //        //else
            //        //{
            //        //    string strAutoLogin = Helper.GetAppConfig("AutoLogin");

            //        //    // 자동 로그인으로 세팅이 된 경우가 아니면 로그인 페이지로 Redirect 시킨다.
            //        //    if (!string.IsNullOrEmpty(strAutoLogin) && strAutoLogin.Equals("true"))
            //        //    {
            //        //        ShBaseAuth.SetAutoDevLogin(this.Page);
            //        //    }
            //        //    else
            //        //    {
            //        //        this.Page.SetPageNoCache();
            //        //        FormsAuthentication.RedirectToLoginPage();
            //        //        Response.End();
            //        //    }
            //        //}
            //        //#endregion
            //    }
            //}
            //else
            //{
            //    string strAutoLogin = Helper.GetAppConfig("AutoLogin"); // 상위에서 미리 변수로 세팅을 하지 않는 것은 이곳으로 올 확율이 거의 없기 때문에 오는 경우에만 세팅을 한다.
            //    if (!string.IsNullOrEmpty(strAutoLogin) && strAutoLogin.Equals("true"))
            //    {
            //        throw new Exception("권한 체크를 하지 않는 페이지 입니다. 따라서 자동 로그인을 할 수 없습니다. 환경 설정을 확인 하세요.");
            //    }
            //}

            //#endregion



            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        /// <summary>
        /// 상속받지 않고 사용을 할때 사용 합니다.
        /// </summary>
        /// <param name="page"></param>
        public ShBase( System.Web.UI.Page page ) : this()
        {
            eHR.Framework.Control.ShTextbox box = new Control.ShTextbox();

            this.Page = page;
        }

        public class MessageBox
        {
            public static class Message
            {
                public const string WARING = "오류가 발생하였습니다.";
                public const string INFORM = "저장 되었습니다.";
                public const string DELETE = "삭제 되었습니다.";
                public const string SAVE = "저장 되었습니다.";
                public const string PROCESS = "처리 되었습니다.";
            }

            public class Title
            {
                public const string WARINGTITLE = "오류";
                public const string INFORMTITLE = "메시지";
                public const string DELETETITLE = "안내";
                public const string SAVETITLE = "안내";
                public const string PROCESSTITLE = "안내";
            }
        }

        public string GetConfig(string key)
        {
            return ConfigManager.TryGetString(key);
        }

        public string GetNEXCOREConfig(string key)
        {
            return SkccFxConfigManager.TryGetString(key);
        }

        #region [GetParamString]
        /// <summary>
        ///  파라메터를 반환합니다.
        /// </summary>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public string GetParamString(string sKey)
        {
            return GetParamString(sKey, "");
        }

        /// <summary>
        ///  파라메터를 반환합니다.
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="sDefaultValue"></param>
        /// <returns></returns>
        public string GetParamString(string sKey, string sDefaultValue)
        {
            return HttpContext.Current.Request[sKey] == null
                ? sDefaultValue
                : (HttpContext.Current.Request[sKey] == "" ? sDefaultValue : HttpContext.Current.Request[sKey].ToString());
        }
        #endregion

        #region [레이어 메세지 URL]
        private readonly string MessageCONFIRM = ConfigurationManager.AppSettings["MessageCONFIRM"];
        private readonly string MessageINFORM = ConfigurationManager.AppSettings["MessageINFORM"];
        private readonly string MessageWARNING = ConfigurationManager.AppSettings["MessageWARNING"];
        private readonly string MessageERROR = ConfigurationManager.AppSettings["MessageERROR"];
        #endregion

        #region [레이어 메세지 띄우기]
        //private int _defaultW = 470;
        //private int _defaultH = 263;
        private int _defaultW = 406;
        private int _defaultH = 206;

        public void ClientConfirm(string _msg, string _title, string _callBackFunc)
        {
            this.ClientConfirm(_msg, _title, _defaultW, _defaultH, _callBackFunc);
        }
        public void ClientConfirm(string _msg, string _title, int _w, int _h, string _callBackFunc)
        {
            _msg = this.SetSafeLiteral(_msg);
            _title = this.SetSafeLiteral(_title);

            Literal literal = new Literal();
            literal.Text = string.Format("<script>GtDivMsg.ShowMessage('{0}', {1}, {2}, '{3}', '{4}', \"{5}\");</script>"
              , string.Format("{0}?{1}", this.MessageCONFIRM, DateTime.Now.ToString("yyyyMMddHHmmss.fffzz"))
              , _w, _h, _msg, _title, _callBackFunc);

            this.Page.Controls.Add(literal);
        }

        /// <summary>
        /// 품의 중 에러 메시지
        /// </summary>
        public void ClientApprovalError()
        {
            this.ClientInform(Consts.ReportMessage.ApprovalError, Consts.ReportTitle.ApprovalErrorTitle, _defaultW, _defaultH, "");
        }

        /// <summary>
        /// 품의 중 에러 메시지
        /// </summary>
        /// <param name="callback"></param>
        public void ClientApprovalError(string callback)
        {
            this.ClientInform(Consts.ReportMessage.ApprovalError, Consts.ReportTitle.ApprovalErrorTitle, _defaultW, _defaultH, callback);
        }

        /// <summary>
        /// 품의 기안 메시지
        /// </summary>
        public void ClientDrafting()
        {
            this.ClientInform(Consts.ReportMessage.Drafting, Consts.ReportTitle.DraftingTitle, _defaultW, _defaultH, "");
        }

        /// <summary>
        /// 품의 기안 메시지
        /// </summary>
        /// <param name="callback"></param>
        public void ClientDrafting(string callback)
        {
            this.ClientInform(Consts.ReportMessage.Drafting, Consts.ReportTitle.DraftingTitle, _defaultW, _defaultH, callback);
        }

        /// <summary>
        /// 품의 반려 메시지
        /// </summary>
        public void ClientCompanion()
        {
            this.ClientInform(Consts.ReportMessage.Companion, Consts.ReportTitle.CompanionTitle, _defaultW, _defaultH, "");
        }

        /// <summary>
        /// 품의 반려 메시지
        /// </summary>
        /// <param name="callback"></param>
        public void ClientCompanion(string callback)
        {
            this.ClientInform(Consts.ReportMessage.Companion, Consts.ReportTitle.CompanionTitle, _defaultW, _defaultH, callback);
        }

        /// <summary>
        /// 품의 완료 메시지
        /// </summary>
        public void ClientApproval()
        {
            //this.ClientInform(Consts.ReportMessage.Approval, Consts.ReportTitle.ApprovalTitle, _defaultW, _defaultH, "");
        }

        /// <summary>
        /// 품의 완료 메시지
        /// </summary>
        /// <param name="callback"></param>
        public void ClientApproval(string callback)
        {
            //this.ClientInform(Consts.ReportMessage.Approval, Consts.ReportTitle.ApprovalTitle, _defaultW, _defaultH, callback);
            System.Web.UI.ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "ClientApproval", callback, true);
        }


        /// <summary>
        /// 삭제 메시지
        /// </summary>
        public void ClientDelete()
        {
            this.ClientInform(MessageBox.Message.DELETE, MessageBox.Title.DELETETITLE, _defaultW, _defaultH, "");
        }

        /// <summary>
        /// 삭제 메시지
        /// </summary>
        /// <param name="callback"></param>
        public void ClientDelete(string callback)
        {
            this.ClientInform(MessageBox.Message.DELETE, MessageBox.Title.DELETETITLE, _defaultW, _defaultH, callback);
        }

        /// <summary>
        /// 저장 메시지
        /// </summary>
        public void ClientSave()
        {
            this.ClientInform(MessageBox.Message.SAVE, MessageBox.Title.SAVETITLE, _defaultW, _defaultH, "");
        }

        /// <summary>
        /// 저장 메시지
        /// </summary>
        /// <param name="callback"></param>
        public void ClientSave(string callback)
        {
            this.ClientInform(MessageBox.Message.SAVE, MessageBox.Title.SAVETITLE, _defaultW, _defaultH, callback);
        }

        /// <summary>
        /// 처리 메시지
        /// </summary>
        public void ClientProcess()
        {
            this.ClientInform(MessageBox.Message.PROCESS, MessageBox.Title.PROCESSTITLE, _defaultW, _defaultH, "");
        }

        /// <summary>
        /// 처리 메시지
        /// </summary>
        /// <param name="callback"></param>
        public void ClientProcess(string callback)
        {
            this.ClientInform(MessageBox.Message.PROCESS, MessageBox.Title.PROCESSTITLE, _defaultW, _defaultH, callback);
        }

        public void ClientInform()
        {
            this.ClientInform(MessageBox.Message.INFORM, MessageBox.Title.INFORMTITLE, _defaultW, _defaultH, "");
        }

        public void ClientInform(string informMessage)
        {
            this.ClientInform(informMessage, MessageBox.Title.INFORMTITLE, _defaultW, _defaultH, "");
        }

        public void ClientInform(string _msg, string _title, string _callBackFunc)
        {
            this.ClientInform(_msg, _title, _defaultW, _defaultH, _callBackFunc);
        }

        public void ClientInform(string _msg, string _title, int _w, int _h, string _callBackFunc)
        {
            _msg = this.SetSafeLiteral(_msg);
            _title = this.SetSafeLiteral(_title);

            Literal literal = new Literal();
            literal.Text = string.Format("<script>GtDivMsg.ShowMessage('{0}', {1}, {2}, '{3}', '{4}', \"{5}\");</script>"
              , string.Format("{0}?{1}", this.MessageINFORM, DateTime.Now.ToString("yyyyMMddHHmmss.fffzz"))
              , _w, _h, _msg, _title, _callBackFunc);

            this.Page.Controls.Add(literal);
        }

        public string ReturnStringClientInform(string _msg, string _title, string _callBackFunc)
        {

            string strShowMessage = string.Format("<script>GtDivMsg.ShowMessage('{0}', {1}, {2}, '{3}', '{4}', \"{5}\");</script>"
              , string.Format("{0}?{1}", this.MessageINFORM, DateTime.Now.ToString("yyyyMMddHHmmss.fffzz"))
              , _defaultW, _defaultH, _msg, _title, _callBackFunc);

            return strShowMessage;
        }

        public void ClientWarning()
        {
            this.ClientWarning(MessageBox.Message.WARING, MessageBox.Title.WARINGTITLE, _defaultW, _defaultH, "");
        }

        public void ClientWarning(string _callBackFunc)
        {
            this.ClientWarning(MessageBox.Message.WARING, MessageBox.Title.WARINGTITLE, _defaultW, _defaultH, _callBackFunc);
        }

        public void ClientWarning(string _msg, string _title, string _callBackFunc)
        {
            this.ClientWarning(_msg, _title, _defaultW, _defaultH, _callBackFunc);
        }

        public void ClientWarning(string _msg, string _title, int _w, int _h, string _callBackFunc)
        {
            _msg = this.SetSafeLiteral(_msg);
            _title = this.SetSafeLiteral(_title);

            Literal literal = new Literal();
            literal.Text = string.Format("<script>GtDivMsg.ShowMessage('{0}', {1}, {2}, '{3}', '{4}', \"{5}\");</script>"
              , string.Format("{0}?{1}", this.MessageWARNING, DateTime.Now.ToString("yyyyMMddHHmmss.fffzz"))
              , _w, _h, _msg, _title, _callBackFunc);

            this.Page.Controls.Add(literal);
        }

        public string ReturnStringClientWarning(string _msg, string _title, string _callBackFunc)
        {

            string strShowMessage = string.Format("<script>GtDivMsg.ShowMessage('{0}', {1}, {2}, '{3}', '{4}', \"{5}\");</script>"
              , string.Format("{0}?{1}", this.MessageWARNING, DateTime.Now.ToString("yyyyMMddHHmmss.fffzz"))
              , _defaultW, _defaultH, _msg, _title, _callBackFunc);

            return strShowMessage;
        }

        public void ClientError(string _msg, string _title, string _callBackFunc)
        {
            this.ClientError(_msg, _title, _defaultW, -_defaultH, _callBackFunc);
        }
        public void ClientError(string _msg, string _title, int _w, int _h, string _callBackFunc)
        {
            string strErrorIsDisplay = Helper.GetAppConfig("IsDisplayClientErrorMessage");

            // Real 서버 모드인 경우 메세지만 호출이 되도록 한다. 
            if (strErrorIsDisplay.ToLower() != "true")
            {
                string strClientErrorMsg = "오류가 발생 하였습니다.<br>관리자에게 문의 하세요!";
                ClientWarning(strClientErrorMsg, "시스템 오류", _w, _h, string.Empty);
                return;
            }

            _msg = this.SetSafeLiteral(_msg);
            _title = this.SetSafeLiteral(_title);

            Literal literal = new Literal();
            literal.Text = string.Format("<script>GtDivMsg.ShowMessage('{0}', {1}, {2}, '{3}', '{4}', \"{5}\");</script>"
              , string.Format("{0}?{1}", this.MessageERROR, DateTime.Now.ToString("yyyyMMddHHmmss.fffzz"))
              , _w, _h, _msg, _title, _callBackFunc);

            this.Page.Controls.Add(literal);

            //EventLog에 작성
            //if (System.Configuration.ConfigurationManager.AppSettings["SystemTP"].ToUpper() == "ADMIN")
            //{
            //    Helper.WriteEventLog(System.Diagnostics.EventLogEntryType.Error, _msg);
            //}
        }

        #endregion

        /// <summary>
        /// Layer Div InnerHtml 렌더링시 안전하게 처리 될 수 있도록  처리 합니다.
        /// </summary>
        /// <param name="soruceData">처리할 원본 데이타 입니다.</param>
        /// <returns></returns>
        /// <example>
        /// string strData = "abc'def"
        /// this.SetSafeLiteral(strData);
        /// </example>
        public string SetSafeLiteral(string soruceData)
        {
            if (soruceData.Length > 0)
            {
                soruceData = soruceData.Replace(",", "&#44;");
                soruceData = soruceData.Replace("\r\n", "<br/>");
                soruceData = soruceData.Replace("\"", "&#34;");
                soruceData = soruceData.Replace("'", "&#39;");
                soruceData = soruceData.Replace("(", "&#40;");
                soruceData = soruceData.Replace(")", "&#41;");
            }
            return soruceData;
        }
        /// <summary>
        /// 렌더링 시 html을 안전하게 처리 할수 있도록 인코딩합니다.
        /// </summary>
        /// <param name="sourceHTML">처리 할 원본 데이터</param>
        /// <returns></returns>
        public string SafeHtmlEncode(string sourceHTML)
        {
            return Server.HtmlEncode(sourceHTML);

        }
        #region [Error ...]
        public void Error(Exception ex)
        {
            this.ClientError(ex.Message, ex.ToString(), _defaultW, _defaultH, "");
        }

        public void Waring(string warningMessage)
        {
            this.ClientWarning(warningMessage, this.Title, _defaultW, _defaultH, "");
        }


        public void Inform(string informMessage)
        {
            this.ClientInform(informMessage, this.Title, _defaultW, _defaultH, "");
        }



        public void Confirm(string confirmMessage)
        {
            this.ClientConfirm(confirmMessage, this.Title, _defaultW, _defaultH, "");
        }
        #endregion

        /// <summary>
        /// 마스터 페이지를 변경 합니다.
        /// </summary>
        /// <param name="mpType"></param>
        public void ChangeMasterPage(MasterPageType mpType)
        {
            switch (mpType)
            {
                case MasterPageType.Main:
                    this.Page.MasterPageFile = "/MasterPage/Main.Master";
                    break;
                case MasterPageType.LayerPopup:
                    this.Page.MasterPageFile = "/MasterPage/LayerPopup.Master";
                    break;
            }
        }

        /// <summary>
        /// 이윤호
        /// </summary>
        /// <param name="Key">QueryString</param>
        /// <returns></returns>
        protected string QueryString(string Key)
        {
            return QueryString(Key, string.Empty);
        }

        /// <summary>
        /// 이윤호
        /// </summary>
        /// <param name="Key">QueryString</param>
        /// <param name="DefaultValue">기본값</param>
        /// <returns></returns>
        protected string QueryString(string Key, string DefaultValue)
        {
            try
            {
                // 키가 없으면 기본값 반환
                if (!Request.QueryString.AllKeys.Contains(Key))
                {
                    return DefaultValue; 
                }

                /* HttpRequest.QueryString을 가져온다. */
                NameValueCollection Query = Request.QueryString;
                /* 반환될 QueryString */
                string qryString = string.Empty;

                /* 해당 QueryString에 대한 값을 가져온다. */
                qryString = Query.Get(Key);
                //qryString = Query.Get(Key) != null ? Server.UrlDecode(Query.Get(Key)) : "";
                /* QueryString의 값이 없을 경우 DefaultValue를 반환해 준다.*/
                return (qryString.Trim().Length > 0 ? qryString : DefaultValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 로그인한 사용자의 조건의 Role이 있는지 확인 합니다.
        /// </summary>
        /// <param name="roleCd"></param>
        /// <returns></returns>
        protected bool GetIsMyRole(string roleCd)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated || string.IsNullOrEmpty(UserProfile.Id))
                return false;

            // 아래 임시로 주석처리 by swarry
            //return ShBaseAuth.GetRmsRoleAuth(UserProfile.Id, roleCd);
            return true;
        }

        /// <summary>
        /// 작성자 : 성정오
        /// 작성일 : 2012.10.04
        /// 내  용 : 사용자 정의 Encrypt ( 상속 받는 페이지에서 사용 , 내부적으로 eHR.Framework.Cryptography.UserEnDe.Encrypt() 사용 )
        /// </summary>
        /// <param name="encryptText"></param>
        /// <returns></returns>
        public string UserEncrypt(string encryptText)
        { 
            return eHR.Framework.Cryptography.UserEnDe.Encrypt(encryptText);
        }

        /// <summary>
        /// 작성자 : 성정오
        /// 작성일 : 2012.10.04
        /// 내  용 : 사용자 정의 Decrypt ( 상속 받는 페이지에서 사용 , 내부적으로 eHR.Framework.Cryptography.UserEnDe.Decrypt() 사용 )
        /// </summary>
        /// <param name="decryptText"></param>
        /// <returns></returns>
        public string UserDecrypt(string decryptText)
        {
            return eHR.Framework.Cryptography.UserEnDe.Decrypt(decryptText);
        }
    }

}

