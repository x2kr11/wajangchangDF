using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web;
using System.Web.UI;
using eHR.Framework.Common;
using System.Collections.Specialized;

namespace eHR.Framework.Base
{
    public class ShUserControlBase : UserControl, IClientPopMessage
    {
        public class MessageBox
        {
            public static class Message
            {
                public const string WARING = "오류가 발생하였습니다.";
                public const string INFORM = "저장 되었습니다.";
                public const string DELETE = "삭제 되었습니다.";
                public const string SAVE = "저장 되었습니다.";
                public const string PROCESS = "처리 되었습니다.";
                public const string Approval = "품의가 완료되었습니다.";
            }

            public class Title
            {
                public const string WARINGTITLE = "오류";
                public const string INFORMTITLE = "메시지";
                public const string DELETETITLE = "안내";
                public const string SAVETITLE = "안내";
                public const string PROCESSTITLE = "안내";
                public const string PUMUI = "안내";
            }
        }

        #region [레이어 메세지 URL]
        private readonly string MessageCONFIRM = ConfigurationManager.AppSettings["MessageCONFIRM"].ToString();
        private readonly string MessageINFORM = ConfigurationManager.AppSettings["MessageINFORM"].ToString();
        private readonly string MessageWARNING = ConfigurationManager.AppSettings["MessageWARNING"].ToString();
        private readonly string MessageERROR = ConfigurationManager.AppSettings["MessageERROR"].ToString();
        #endregion

        #region [레이어 메세지 띄우기]
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

            //this.Page.Controls.Add(literal);
            SetControlAdd(literal);
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

            //this.Page.Controls.Add(literal);
            SetControlAdd(literal);
        }

        public void ClientWarning()
        {
            this.ClientWarning(MessageBox.Message.WARING, MessageBox.Title.WARINGTITLE, _defaultW, _defaultH, "");
        }

        public void ClientWarning(string warningMessage)
        {
            this.ClientWarning(warningMessage, MessageBox.Title.WARINGTITLE, _defaultW, _defaultH, "");
        }

        public void ClientWarning(string _msg, string _title, string _callBackFunc)
        {
            this.ClientWarning(_msg, _title, _defaultW, -_defaultH, _callBackFunc);
        }

        public void ClientWarning(string _msg, string _title, int _w, int _h, string _callBackFunc)
        {
            _msg = this.SetSafeLiteral(_msg);
            _title = this.SetSafeLiteral(_title);

            Literal literal = new Literal();
            literal.Text = string.Format("<script>GtDivMsg.ShowMessage('{0}', {1}, {2}, '{3}', '{4}', \"{5}\");</script>"
              , string.Format("{0}?{1}", this.MessageWARNING, DateTime.Now.ToString("yyyyMMddHHmmss.fffzz"))
              , _w, _h, _msg, _title, _callBackFunc);

            //this.Page.Controls.Add(literal);
            SetControlAdd(literal);
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

            //this.Page.Controls.Add(literal.Text);

            SetControlAdd(literal);

            //EventLog에 작성
            //if (System.Configuration.ConfigurationManager.AppSettings["SystemTP"].ToUpper() == "ADMIN")
            //{
            //    Helper.WriteEventLog(System.Diagnostics.EventLogEntryType.Error, _msg);
            //}
        }

        /// <summary>
        /// 작성자 : 성정오
        /// 코드블럭 오류를 보완 한다.
        /// UserControl 부분은 보완이 필요 하다. ==..==
        /// </summary>
        /// <param name="ltl"></param>
        private void SetControlAdd(Literal ltl)
        {
            try
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Msg", ltl.Text, false);
            }
            catch (Exception)
            {
                this.Page.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Msg", ltl.Text, false);
            }
        }

        #endregion

        #region [Error ...]
        //        protected void Error(Exception ex)
        //        {
        //            HttpContext ctx = HttpContext.Current;

        //            ctx.Session["ERROR"] = ex;
        //            ctx.Session["PROGRAMID"] = this.ProgramID;

        //            string pgm = Request.AppRelativeCurrentExecutionFilePath.Remove(0, 2);

        //#if (DEBUG)
        //            Response.Redirect(String.Format("{0}?errorurl={1}&DISPLAY={2}", "/Common/Error.aspx", Server.UrlEncode(Request.Url.PathAndQuery), "TRUE"));
        //#else
        //                Response.Redirect(String.Format("{0}?errorurl={1}", "/Common/Error.aspx", Server.UrlEncode(Request.Url.PathAndQuery)));
        //#endif
        //        }

        public void Error(Exception ex)
        {
            this.ClientError(ex.Message, ex.ToString(), _defaultW, _defaultH, "");
        }

        public void Waring(string warningMessage)
        {
            this.ClientWarning(warningMessage, this.Page.Title, _defaultW, _defaultH, "");
        }

        public void Inform(string informMessage)
        {
            this.ClientInform(informMessage, this.Page.Title, _defaultW, _defaultH, "");
        }

        public void Confirm(string confirmMessage)
        {
            this.ClientConfirm(confirmMessage, this.Page.Title, _defaultW, _defaultH, "");
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
        /// 품의 완료 메시지
        /// </summary>
        public void ClientApproval()
        {
            this.ClientInform(Consts.ReportMessage.Approval, Consts.ReportTitle.ApprovalTitle, _defaultW, _defaultH, "");
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


        #endregion

        #region [Call :: ExecuteService]

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
        protected string SetSafeLiteral(string soruceData)
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
        /// Common Injection을 방지하기 위해 Conver한 문자열을 복원합니다.
        /// </summary>
        /// <param name="str">Convert된 문자열</param>
        /// <returns>UI 화면에 표시할 문자열</returns>
        public string ReverseConvertString(string str)
        {
            if (str == null) return null;
            string temp = string.Empty;
            //<br><b> 는 예외처리
            str = str.Replace("|br|", "<br>");
            str = str.Replace("|BR|", "<BR>");
            str = str.Replace("|b|", "<b>");
            str = str.Replace("|B|", "<B>");
            str = str.Replace("|/b|", "</b>");
            str = str.Replace("|/B|", "</B>");

            temp = str.Replace("\\'", "\'");
            temp = temp.Replace("&amp;", "&");
            temp = temp.Replace("&quot;", "\"");
            temp = temp.Replace("&lt;", "<");
            temp = temp.Replace("&gt;", ">");

            return temp.Trim();
        }

        /// <summary>
        /// Command Injection을 방지를 위해 String을 Convert합니다.
        /// </summary>
        /// <param name="str">UI화면에서 받은 문자열</param>
        public string ConvertString(string str)
        {
            if (str == null) return null;
            string temp = string.Empty;
            //<br><b> 는 예외처리
            str = str.Replace("<br>", "|br|");
            str = str.Replace("<BR>", "|BR|");
            str = str.Replace("<b>", "|b|");
            str = str.Replace("<B>", "|B|");
            str = str.Replace("</b>", "|/b|");
            str = str.Replace("</B>", "|/B|");

            temp = str.Replace("\'", "\\'");
            temp = temp.Replace("&", "&amp;");
            temp = temp.Replace("\"", "&quot;");
            temp = temp.Replace("<", "&lt;");
            temp = temp.Replace(">", "&gt;");

            temp = temp.Replace("|br|", "<br>");
            temp = temp.Replace("|BR|", "<BR>");
            temp = temp.Replace("|b|", "<b>");
            temp = temp.Replace("|B|", "<B>");
            temp = temp.Replace("|/b|", "</b>");
            temp = temp.Replace("|/B|", "</B>");
            return temp.Trim();
        }

        #region [GetParamString]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public string GetParamString(string sKey)
        {
            return GetParamString(sKey, "");
        }

        /// <summary>
        /// 
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

        #region [GetParamInt]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sKey"></param>
        /// <param name="sDefaultValue"></param>
        /// <returns></returns>
        public int GetParamInt(string sKey, int sDefaultValue)
        {
            return HttpContext.Current.Request[sKey] == null
                ? sDefaultValue
                : (HttpContext.Current.Request[sKey] == "" ? sDefaultValue : Convert.ToInt32(HttpContext.Current.Request[sKey]));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sKey"></param>
        /// <returns></returns>
        public int GetParamInt(string sKey)
        {
            return GetParamInt(sKey, 0);
        }

        /// <summary>
        /// ContextItem 을 가지고 온다. 
        /// </summary>
        /// <param name="itemName"></param>
        /// <returns></returns>
        public string GetContextItemString(string itemName)
        {
            string returnvalue = string.Empty;

            if (this.Context.Items.Contains(itemName))
            {
                returnvalue = this.Context.Items[itemName] as string;
            }

            return returnvalue;
        }

        #endregion


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
    }
}


