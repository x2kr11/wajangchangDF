using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace eHR.Framework.Mail
{
    /// <summary>
    /// 이 클래스는 SMTP를 이용해서 메일을 전송 합니다.
    /// </summary>
    public class MailClient
    {
        #region 생성자
        public MailClient() { }

        /// <summary>
        /// 오버로드 되었습니다. <br />
        /// SMTP Host 정보를 포함 합니다. <br />
        /// CredentialType은 None이 기본값 입니다.
        /// </summary>
        /// <param name="host">SMTP서버 접속 정보 입니다.</param>
        /// <param name="hostAccount">UseCredential 이 None 이면 이 값은 무시 됩니다.</param>
        /// <param name="hostAccountPwd">UseCredential 이 None 이면 이 값은 무시 됩니다.</param>
        public MailClient(string hostName, string hostAccount, string hostAccountPwd)
        {
            this.HostName = hostName;
            this.HostAccount = hostAccount;
            this.HostAccountPwd = hostAccountPwd;
        }

        /// <summary>
        /// 오버로드 되었습니다. <br />
        /// SMTP Host 정보를 포함 합니다. <br />
        /// CredentialType은 None이 기본값 입니다.
        /// </summary>
        public MailClient(string hostName, int hostPort , string hostAccount, string hostAccountPwd)
        {
            this.HostName   = hostName;
            this.Port       = hostPort;

            this.HostAccount = hostAccount;
            this.HostAccountPwd = hostAccountPwd;
        } 

        #endregion

        #region Mail Server Host 정보
        private string _hostName = string.Empty;
        /// <summary>
        /// SMTP서버 주소 입니다.<br />
        /// </summary>
        public string HostName
        {
            get
            {
                return this._hostName;
            }
            set
            {
                this._hostName = value;
            }
        }

        private int _port = 25;
        /// <summary>
        /// SMTP서버 포트를 설정하거나 가져 옵니다.
        /// </summary>
        public int Port
        {
            get 
            {
                return this._port;
            }
            set
            {
                this._port = value;
            }
        }


        private string _hostAccount = string.Empty;
        /// <summary>
        /// UseCredential 값이 None이 아닌 경우 Host에 Access하기 위한 Email 계정 입니다.<br />
        /// </summary>
        public string HostAccount
        {
            get
            {
                return this._hostAccount;
            }
            set
            {
                this._hostAccount = value;
            }
        }

        private string _hostAccountPwd = string.Empty;
        /// <summary>
        /// UseCredential 값이 None이 아닌 경우 HostAccount Email 계정의  패스워드 입니다.<br />
        /// </summary>
        public string HostAccountPwd
        {
            get
            {
                return this._hostAccountPwd;
            }
            set
            {
                this._hostAccountPwd = value;
            }
        }

        private CredentialType _credential = CredentialType.None;
        /// <summary>
        /// 인증여부를 결정 합니다.<br />
        /// 이 값이 None이 아니면 인증을 사용 합니다.
        /// </summary>
        public CredentialType Credential
        {
            get
            {
                return this._credential;
            }
            set
            {
                this._credential = value;
            }
        }
        #endregion

        #region 보내는 사람 정보
        private Sender _from = new Sender();
        /// <summary>
        /// 보내는 사람 이메일 주소 입니다.<br />
        /// </summary>
        public Sender From
        {
            get
            {
                return this._from;
            }
            set
            {
                this._from = value;
            }
        }
        #endregion

        #region 받는 사람 정보
        private To _to = null;
        /// <summary>
        /// 받는 사람 정보 입니다.
        /// </summary>
        public To To
        {
            get
            {
                if (this._to == null)
                {
                    this._to = new To();
                }
                return this._to;
            }
        }

        private To _cc = null;
        /// <summary>
        /// 참조 정보 입니다.
        /// </summary>
        public To Cc
        {
            get
            {
                if (this._cc == null)
                {
                    this._cc = new To();
                }
                return this._cc;
            }
        }

        private To _bcc = null;
        /// <summary>
        /// 숨은 참조 정보 입니다.
        /// </summary>
        public To Bcc
        {
            get
            {
                if (this._bcc == null)
                {
                    this._bcc = new To();
                }
                return this._bcc;
            }
        } 
        #endregion

        #region 첨부 파일 정보
        private AttachFile _attachFiles = null;
        /// <summary>
        /// 첨부 파일 정보 입니다. 
        /// </summary>
        public AttachFile AttachFiles
        {
            get
            {
                if (this._attachFiles == null)
                {
                    this._attachFiles = new AttachFile();
                }
                return this._attachFiles;
            }
        } 
        #endregion

        #region 메일 Body 설정 정보
        private string _subject = string.Empty;
        /// <summary>
        /// 메일 제목 입니다.
        /// </summary>
        public string Subject
        {
            get
            {
                return this._subject;
            }
            set
            {
                this._subject = value;
            }
        }

        private bool _useBodyHtml = true;
        /// <summary>
        /// 메일 본문을 HTML 형식을 사용할지 여부 입니다.<br />
        /// </summary>
        public bool UseBodyHtml
        {
            get
            {
                return this._useBodyHtml;
            }
            set
            {
                this._useBodyHtml = value;
            }
        }

        private string _body = string.Empty;
        /// <summary>
        /// 메일 본문 입니다.
        /// </summary>
        public string Body
        {
            get
            {
                return this._body;
            }
            set
            {
                this._body = value;
            }
        }

        private MailPriority _priority = MailPriority.Normal;
        /// <summary>
        /// 메일 우선 순위를 설정 합니다.<br />기본값은 Normal 입니다.
        /// </summary>
        public MailPriority Priority
        {
            get
            {
                return this._priority;
            }
            set
            {
                this._priority = value;
            }
        }

        private Encoding _mailEncoding = System.Text.Encoding.UTF8;
        /// <summary>
        /// 인코딩 타입을 설정 하거나 반환 합니다.
        /// </summary>
        public Encoding MailEncoding
        {
            get
            {
                return this._mailEncoding;
            }
            set
            {
                this._mailEncoding = value;
            }
        }
	    #endregion

        /// <summary>
        /// 메일을 전송 합니다.
        /// </summary>
        /// <example>
        /// string strHost = "mostisoft.com";
        /// string strAcct = "user1@mostisoft.com";
        /// string strpwd = "xxxx";
        /// 
        /// Mosti.Fundamentals.Mail.MailClient mc = new Mosti.Fundamentals.Mail.MailClient(
        ///     strHost, strAcct, strpwd);
        /// mc.Credential = Mosti.Fundamentals.Mail.CredentialType.Account;
        /// 
        /// mc.From.Name = "모스티";
        /// mc.From.Email = "user1@mostisoft.com";
        /// 
        /// mc.To.Add("icookie@naver.com", "김희택");
        /// mc.Cc.Add("icookie1@nate.com", "김희택");
        /// mc.Bcc.Add("user2@mostisoft.com", "김희택");
        /// 
        /// mc.Subject = "메일 테스트 입니다.";
        /// mc.Body = "<font color='red'>first</font>테스트 입니다.";
        /// mc.AttachFiles.Add(@"C:\noPicture.gif");
        /// mc.AttachFiles.Add(@"D:\Music\2NE1\006. 2NE1 - I Don`t Care.mp3");
        /// 
        /// mc.SendMail();
        /// </example>
        public void SendMail()
        {
            MailMessage message = null;
            try
            {
                //Include some non-ASCII characters in body and subject
                string someArrows = new string(new char[] { '\u2190', '\u2191', '\u2192', '\u2193' });

                SmtpClient client = new SmtpClient();

                client.Host = this.HostName;
                client.Port = this.Port;

                //인증에 따라서 설정 합니다.
                switch (this.Credential)
                {
                    case CredentialType.None:
                        break;
                    case CredentialType.Account:
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = true;
                        client.Credentials = new System.Net.NetworkCredential(this.HostAccount, this.HostAccountPwd);
                        break;
                    case CredentialType.Ssl:
                        client.EnableSsl = true;
                        client.Credentials = new System.Net.NetworkCredential(this.HostAccount, this.HostAccountPwd);
                        break;
                }

                message = new MailMessage();
                
                //보내는 사람 설정
                message.From = new MailAddress(this.From.Email, this.From.Name, this.MailEncoding);

                //받는 사람 설정
                foreach (KeyValuePair<String, String> info in this.To.Receivers)
                {
                    message.To.Add(new MailAddress(info.Key, info.Value, this.MailEncoding));
                }

                //참조 설정
                foreach (KeyValuePair<String, String> info in this.Cc.Receivers)
                {
                    message.CC.Add(new MailAddress(info.Key, info.Value, this.MailEncoding));
                }

                //숨은 참조 설정
                foreach (KeyValuePair<String, String> info in this.Bcc.Receivers)
                {
                    message.Bcc.Add(new MailAddress(info.Key, info.Value, this.MailEncoding));
                }

                message.IsBodyHtml = this.UseBodyHtml;
                message.Body = this.Body;
                message.Priority = this.Priority;
                message.Subject = this.Subject;

                message.BodyEncoding = this.MailEncoding;
                message.SubjectEncoding = this.MailEncoding;

                if (this.AttachFiles.Count > 0)
                {
                    foreach (string file in this.AttachFiles.Files)
                    {
                        message.Attachments.Add(new Attachment(file));
                    }
                }

                //메일 전송 
                client.Send(message);
            }
            finally
            {
                if (message != null)
                    message.Dispose();
            }
        }
        
    }
}
