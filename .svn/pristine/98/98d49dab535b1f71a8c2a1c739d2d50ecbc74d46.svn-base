using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.IO;
using System.Configuration;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using eHR.Framework.Sessions;

namespace eHR.Framework.Common
{
    public static partial class Helper
    {
        /// <summary>
        /// SMTP 프로토콜을 이용하여 메일을 전송 합니다.<br/>
        /// 메일은 HTML 형식을 지원 합니다.
        /// </summary>
        /// <param name="dt">메일을 보내기 위해 사용되는 수신인 리스트 입니다.</param>
        /// <param name="nameField">수신인 이름 컬럼명 입니다.</param>
        /// <param name="emailField">수신인 이메일 컬럼명 입니다.</param>
        /// <param name="subject">메일 제목 입니다.</param>
        /// <param name="mailBody">메일 본문 입니다.</param>
        /// <returns></returns>
        public static bool SendMail(DataTable dt, string nameField, string emailField, string subject, string mailBody)
        {
            string strHost = ConfigurationManager.AppSettings["MailHost"];                  // "127.0.0.1";
            string strAcct = ConfigurationManager.AppSettings["MailAccount"];               // "mailUser";
            string strpwd = ConfigurationManager.AppSettings["MailAccountPwd"];             // "11";
            string strSenderName = ConfigurationManager.AppSettings["MailSender"];          // "HC CR실";
            string strSenderEmail = ConfigurationManager.AppSettings["MailSenderEmail"];    // "hcCr@sk.com";

            eHR.Framework.Mail.MailClient mc = new eHR.Framework.Mail.MailClient();

            mc.HostName = strHost;
            mc.HostAccount = strAcct;
            mc.HostAccountPwd = strpwd;
            mc.Credential = eHR.Framework.Mail.CredentialType.Account;

            mc.From.Name = strSenderName;
            mc.From.Email = strSenderEmail;

            mc.Subject = subject;
            mc.Body = mailBody;

            foreach (DataRow dr in dt.Rows)
            {
                //개별로 보내기 위해
                mc.To.Clear();
                mc.To.Add(dr[emailField].ToString(), dr[nameField].ToString());

                //mc.Cc.Add("icookie1@nate.com", "김희택");            //참조
                //mc.Bcc.Add("htkim@mostisoft.com", "김희택");         //숨은참조

                //mc.AttachFiles.Add(@"C:\noPicture.gif");                  //첨부파일
                //mc.AttachFiles.Add(@"D:\Music\2NE1\006. 2NE1 - I Don`t Care.mp3");    //첨부파일

                mc.SendMail();
            }

            return true;
        }


        /// <summary>
        /// 디자인 형식에 맞춰서 이메일 보내기 (다중건)
        /// </summary>
        /// <param name="toMailInfo">보낼 이메일 Dictionary[ Email , 보내는 사람 이름 ]</param>
        /// <param name="subject">메일 제목</param>
        /// <param name="bodyHtmlNomal">내용의 타이틀</param>
        /// <param name="bodyHtmlNomal">텍스트 맨위의 들어갈 글자</param>
        /// <param name="bodyHtmlBold">그다음 밑에 들어갈 굵은 글자</param>
        /// <param name="bodyHtmlBody">가운데 들어갈 글자</param>
        /// <param name="bodyHtmlLink">이미지 하이퍼 링크(아무값도 넣지 않으면 없어진다)</param>
        /// <param name="teamemail">teamemail를 true로 설정하면 보낸 사람 이메일이 연구지원팀으로 들어가고 false로 하면 세션에서 email를 가져온다</param>
        /// <param name="type">html 타입(1타입 : 700 whdth, 2타입: 900 width)</param>
        /// <returns></returns>
        public static bool SendMailForDesignFormat(
                                                        string fromMailName,
                                                        string fromMailAddress,
                                                        Dictionary<string, string> toMailInfo, 
                                                        Dictionary<string, string> toMailInfo_CC,
                                                        Dictionary<string, string> toMailInfo_BCC,
                                                        string subject, 
                                                        string bodyHtmlTitle, 
                                                        string bodyHtmlNomal, 
                                                        string bodyHtmlBold, 
                                                        string bodyHtmlBody, 
                                                        string bodyHtmlLink, 
                                                        //bool fromteamemail, 
                                                        List<Mosti.GTFileUploadSL.Server.Library.GtFileUploadInfo> sendMailFile, 
                                                        Consts.DesignSendMail.DesignFormatHtml designFormatHtmlType
                                                    )
        {
            #region # 유효성 체크 

            if (string.IsNullOrEmpty(fromMailAddress))
                throw new Exception("보내시는 분의 이메일 계정이( 이메일 ) 없습니다.!");
            else if (string.IsNullOrEmpty(fromMailName))
                throw new Exception("보내시는 분의 이메일 계정( 이름 )이 없습니다.!");

            if (toMailInfo == null || toMailInfo.Count <= 0)
                return false;
            #endregion

            #region # Get Web.Config 고정 값 및 지역 변수 
            string strName = Helper.GetAppConfig("SendMailName");

            string strHost  = string.Empty;
            string strPort  = string.Empty;
            int iPort       = 25;
            string strAcct  = string.Empty;
            string strpwd   = string.Empty;

#if DEBUG
            strHost = Helper.GetAppConfig("SendMail_DEBUG");
            strPort = Helper.GetAppConfig("SendMailPort_DEBUG");
            strAcct = Helper.GetAppConfig("SendMailAddress_DEBUG");
            strpwd  = Helper.GetAppConfig("SendMailPwd_DEBUG");   
#else
            strHost = Helper.GetAppConfig("SendMail");
            strPort = Helper.GetAppConfig("SendMailPort");
            strAcct = Helper.GetAppConfig("SendMailAddress");
            strpwd  = Helper.GetAppConfig("SendMailPwd");
                
#endif
            iPort = string.IsNullOrEmpty(strPort) ? 25 : Int32.Parse(strPort);


            eHR.Framework.Mail.MailClient mc = new eHR.Framework.Mail.MailClient(strHost, iPort, strAcct, strpwd);
            mc.Credential = eHR.Framework.Mail.CredentialType.Account;
            
            #endregion

            #region # FROM Setting 
              
            mc.From.Email   = fromMailAddress;
            mc.From.Name    = fromMailName;

            #endregion

            #region # TO Setting
            if (Helper.GetAppConfig("SendMailTest_Status").ToString().ToLower() == "true")
            {
                string strTo_TestAddress    = Helper.GetAppConfig("SendMailTest_Address");
                string strTo_TestName       = Helper.GetAppConfig("SendMailTest_Name");

                mc.To.Add(strTo_TestAddress, strTo_TestName);
            }
            else
            {
                foreach (var mailInfo in toMailInfo)
                {
                    mc.To.Add(mailInfo.Key, mailInfo.Value ?? string.Empty);
                }
            }
            #endregion

            #region # CC Setting 
            if (Helper.GetAppConfig("SendMailTest_Status").ToString().ToLower() == "true")
            {
            }
            else
            {
                if (toMailInfo_CC != null && toMailInfo_CC.Count > 0)
                {
                    foreach (var mailCCInfo in toMailInfo_CC)
                    {
                        mc.Cc.Add(mailCCInfo.Key, mailCCInfo.Value ?? string.Empty);
                    }
                }
            }
            #endregion

            #region # Bcc Setting
            if (Helper.GetAppConfig("SendMailTest_Status").ToString().ToLower() == "true")
            {
            }
            else
            {
                if (toMailInfo_BCC != null && toMailInfo_BCC.Count > 0)
                {
                    foreach (var mailBCCInfo in toMailInfo_BCC)
                    {
                        mc.Bcc.Add(mailBCCInfo.Key, mailBCCInfo.Value ?? string.Empty);
                    }
                }
            }
            #endregion

            #region # 파일첨부 Setting
            if (sendMailFile != null)
            {
                for (int i = 0; i < sendMailFile.Count; i++)
                {
                    mc.AttachFiles.Add(ConfigurationManager.AppSettings["GTFileUploadPath"]+"\\"+ sendMailFile[i].SubPath+"\\"+sendMailFile[i].SaveAsFileName);
                }
            }
            #endregion

            #region # Body HTML 작성 
            StreamReader    sr  = new StreamReader(HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings[designFormatHtmlType.ToDescription()]));
            string          str = sr.ReadToEnd().ToString();
            
            if (string.IsNullOrEmpty(bodyHtmlTitle))
                str = str.Replace("##titlestyle", "none");
            else
                str = str.Replace("##titlestyle", "block");

            str = str.Replace("##texttitle" , bodyHtmlTitle ?? string.Empty);
            str = str.Replace("##textnomal" , bodyHtmlNomal ?? string.Empty);
            str = str.Replace("##textbold"  , bodyHtmlBold  ?? string.Empty);
            str = str.Replace("##textbody"  , bodyHtmlBody  ?? string.Empty);
            str = str.Replace("##textlink"  , bodyHtmlLink  ?? string.Empty);

            if (string.IsNullOrEmpty(bodyHtmlLink))
                str = str.Replace("##linkstyle", "none");
            else
                str = str.Replace("##linkstyle", "block");
            #endregion

            #region # Send Mail 
            mc.Subject = subject; // 제목
            mc.Body = str;

            mc.SendMail();
            sr.Close();
            #endregion

            return true;
        }

        /// <summary>
        /// 디자인 형식에 맞춰서 이메일 보내기 (단일건)
        /// </summary>
        /// <param name="name">보낼 이름</param>
        /// <param name="email">보낼 이메일</param>
        /// <param name="subject">메일 제목</param>
        /// <param name="bodyHtmlNomal">내용의 타이틀</param>
        /// <param name="bodyHtmlNomal">텍스트 맨위의 들어갈 글자</param>
        /// <param name="bodyHtmlBold">그다음 밑에 들어갈 굵은 글자</param>
        /// <param name="bodyHtmlBody">가운데 들어갈 글자</param>
        /// <param name="bodyHtmlLink">이미지 하이퍼 링크(아무값도 넣지 않으면 없어진다)</param>
        /// <param name="teamemail">teamemail를 true로 설정하면 보낸 사람 이메일이 연구지원팀으로 들어가고 false로 하면 세션에서 email를 가져온다</param>
        /// <param name="type">html 타입(1타입 : 700 whdth, 2타입: 900 width)</param>
        /// <returns></returns>
        public static bool SendMailForDesignFormat(
                                                    string fromMailName,
                                                    string fromMailAddress,
                                                    string toName, 
                                                    string toEmail, 
                                                    string subject, 
                                                    string bodyHtmlTitle, 
                                                    string bodyHtmlNomal, 
                                                    string bodyHtmlBold, 
                                                    string bodyHtmlBody, 
                                                    string bodyHtmlLink, 
                                                    Consts.DesignSendMail.DesignFormatHtml designFormatHtmlType
                                                  )
        {
            Dictionary<string,string>   sendMailInfo    = new Dictionary<string,string>();
            Dictionary<string, string>  sendMailCCInfo  = new Dictionary<string, string>();
            Dictionary<string, string>  sendMailBCCInfo = new Dictionary<string, string>();
            List<Mosti.GTFileUploadSL.Server.Library.GtFileUploadInfo> sendMailFile = null;

            if (string.IsNullOrEmpty(fromMailAddress))
                throw new Exception("보내시는 분의 이메일 계정이( 이메일 ) 없습니다.!");
            else if (string.IsNullOrEmpty(fromMailName))
                throw new Exception("보내시는 분의 이메일 계정( 이름 )이 없습니다.!");

            if( toName.IndexOf(";") > 0 )
            {
                string[] arrMail = toName.Split(';');
                string[] arrName = toEmail.Split(';');

                if (arrMail.Count() != arrName.Count())
                    throw new Exception("이메일과 보내는 사람의 짝이 맞지 않습니다!");

                for (int i = 0; i < arrMail.Count(); i++)
                {
                    if( !string.IsNullOrEmpty(arrMail[i]))
                        sendMailInfo.Add(arrMail[i], arrName[i]);
                }
            }
            else
            {
                sendMailInfo.Add(toEmail , toName);
            }

            return SendMailForDesignFormat(
                                                fromMailName,
                                                fromMailAddress,
                                                sendMailInfo, 
                                                sendMailCCInfo,
                                                sendMailBCCInfo, 
                                                subject,
                                                bodyHtmlTitle, 
                                                bodyHtmlNomal, 
                                                bodyHtmlBold, 
                                                bodyHtmlBody, 
                                                bodyHtmlLink, 
                                                sendMailFile, 
                                                designFormatHtmlType
                                            );
        }
    }
}
