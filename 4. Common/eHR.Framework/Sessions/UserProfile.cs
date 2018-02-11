using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Script.Serialization;
using System.Data;
using eHR.Framework.Common;

namespace eHR.Framework.Sessions
{
    [Serializable]
    public class UserProfileInfo
    {
        /// <summary>
        /// 회사코드
        /// </summary>
        public string CompanyCd;

        /// <summary>
        /// 회사명
        /// </summary>
        public string CompanyName;

        /// <summary>
        /// 로그인 ID
        /// </summary>
        public string Id;

        /// <summary>
        /// Email
        /// </summary>
        public string Email;

        /// <summary>
        /// 사번
        /// </summary>
        public string No;

        /// <summary>
        /// 성명
        /// </summary>
        public string Name;

        /// <summary>
        /// 직위코드
        /// </summary>
        public string TitleCd;

        /// <summary>
        /// 직위켱
        /// </summary>
        public string TitleName;

        /// <summary>
        /// 직책명
        /// </summary>
        public string ResponsibleName;

        /// <summary>
        /// 직책코드
        /// </summary>
        public string ResponsibleCd;

        /// <summary>
        /// 팀코드
        /// </summary>
        public string TeamCd;

        /// <summary>
        /// 팀명
        /// </summary>
        public string TeamName;

        /// <summary>
        /// 팀구분코드
        /// </summary>
        public string TeamCd2;
    }

    /// <summary>
    /// 작성자 : 성정오
    /// 작성일 : 2012.10.04
    /// 내  용 : User 정보를 호출 합니다.
    /// </summary>
    public class UserProfile
    {
        public static readonly string CONTEXT_NAME              = "SESSION_USERINFO_WEB_PAGE_CONTEXT_CACHE_NAME";
        public static readonly string CONTEXT_ROLLDATASET_NAME  = "SESSION_USERINFO_WEB_PAGE_CONTEXT_CACHE_ROLLDATASET_NAME";
        public static readonly string SESSION_ROLLDATA_NAME     = "SESSION_USERINFO_WEB_PAGE_SESSION_CACHE_ROLLDATASET_NAME";

        public static System.Web.HttpContext Context
        {
            get { return System.Web.HttpContext.Current; }
        }

        public static System.Web.SessionState.HttpSessionState Session
        {
            get { return System.Web.HttpContext.Current.Session; }
        }

        public static System.Web.HttpRequest Request
        {
            get { return System.Web.HttpContext.Current.Request; }
        }

        public static System.Web.HttpResponse Response
        {
            get { return System.Web.HttpContext.Current.Response; }
        }

        /// <summary>
        /// 회사코드
        /// </summary>
        public static string CompanyCd { get { UserProfileInfo info = GetUserProfileInfo(); return info.CompanyCd; } }

        /// <summary>
        /// 회사명
        /// </summary>
        public static string CompanyName { get { UserProfileInfo info = GetUserProfileInfo(); return info.CompanyName; } }

        /// <summary>
        /// 로그인 ID
        /// </summary>
        public static string Id { get { UserProfileInfo info = GetUserProfileInfo(); return info.Id; } }

        /// <summary>
        /// Email
        /// </summary>
        public static string Email { get { UserProfileInfo info = GetUserProfileInfo(); return info.Email; } }

        /// <summary>
        /// 사번
        /// </summary>
        public static string No { get { UserProfileInfo info = GetUserProfileInfo(); return info.No; } }

        /// <summary>
        /// 성명
        /// </summary>
        public static string Name { get { UserProfileInfo info = GetUserProfileInfo(); return info.Name; } }

        /// <summary>
        /// 직위코드
        /// </summary>
        public static string TitleCd { get { UserProfileInfo info = GetUserProfileInfo(); return info.TitleCd; } }

        /// <summary>
        /// 직위명
        /// </summary>
        public static string TitleName { get { UserProfileInfo info = GetUserProfileInfo(); return info.TitleName; } }

        /// <summary>
        /// 직책명
        /// </summary>
        public static string ResponsibleName { get { UserProfileInfo info = GetUserProfileInfo(); return info.ResponsibleName; } }

        /// <summary>
        /// 직책코드
        /// </summary>
        public static string ResponsibleCd { get { UserProfileInfo info = GetUserProfileInfo(); return info.ResponsibleCd; } }

        /// <summary>
        /// 팀코드
        /// </summary>
        public static string TeamCd { get { UserProfileInfo info = GetUserProfileInfo(); return info.TeamCd; } }

        /// <summary>
        /// 팀명
        /// </summary>
        public static string TeamName { get { UserProfileInfo info = GetUserProfileInfo(); return info.TeamName; } }

        /// <summary>
        /// 팀구분코드
        /// </summary>
        public static string TeamCd2 { get { UserProfileInfo info = GetUserProfileInfo(); return info.TeamCd2; } }

        /// <summary>
        /// UserProfileInfo를 리턴 합니다.
        /// </summary>
        /// <returns></returns>
        public static UserProfileInfo GetUserProfileInfo()
        {
            UserProfileInfo info = new UserProfileInfo();

            if (Context.Items.Contains(CONTEXT_NAME) && Context.Items[CONTEXT_NAME] != null)
                return Context.Items[CONTEXT_NAME] as UserProfileInfo;

            var formCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (formCookie == null)
                return info;

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(formCookie.Value);
            string strUserData = ticket.UserData;

            if (string.IsNullOrEmpty(strUserData))
                return info;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            info = serializer.Deserialize<UserProfileInfo>(eHR.Framework.Cryptography.UserEnDe.Decrypt(strUserData));

            if (info != null)
                Context.Items[CONTEXT_NAME] = info;

            return info;
        }

        /// <summary>
        /// RollData
        /// </summary>
        public static DataSet RollData
        {
            get
            {
                // 처음 호출시 Context에 담아두고 LifeCycle 동안에 Cache에서 쓰도록 하여 리소스를 관리 한다.
                // RollData는 암호화 하여 관리를 한다.

                if (Context.Items.Contains(CONTEXT_ROLLDATASET_NAME) && Context.Items[CONTEXT_ROLLDATASET_NAME] != null)
                {
                    DataSet dtRetContext = Context.Items[CONTEXT_ROLLDATASET_NAME] as DataSet;

                    if (!dtRetContext.IsNullOrEmpty())
                        return dtRetContext;
                }

                string strRoll = Session[SESSION_ROLLDATA_NAME] as string;
                DataSet ds = null;

                string strRmsSaveType = Helper.GetAppConfig("Rms_RollDataSet_SaveSession");

                #region # RMS 정보를 Session에 저장 시킨다.  ( Helper.GetAppConfig("Rms_RollDataSet_SaveSession") == "true"인경우 ) 
                if (string.IsNullOrEmpty(strRmsSaveType) || strRmsSaveType.ToLower() == "true")
                {
                    if (string.IsNullOrEmpty(strRoll))
                        return null;

                    // Session이 말썽 부리면 이 부분에 RMS Session을 넣어 줄 것
                    //if (HttpContext.Current.User.Identity.IsAuthenticated)
                    //{ 
                            //DataSet dsRms = ShBaseAuth.GetRmsPagePermission(UserProfile.Id);
                            //Session[UserProfile.SESSION_ROLLDATA_NAME] = UserEncrypt(eHR.Framework.Common.Helper.CompressDataSet(dsRms));   // Session의 용량을 줄임과 동시에 보안을 강화 한다.

                            //Context.Items[UserProfile.CONTEXT_ROLLDATASET_NAME] = dsRms;
                    //}

                    ds = Helper.DeserializeFromString(eHR.Framework.Cryptography.UserEnDe.Decrypt(strRoll));
                    System.Web.HttpContext.Current.Items[CONTEXT_ROLLDATASET_NAME] = ds;
                }
                #endregion

                #region # RMS 정보를 Real에서 직접 호출 한다. 
                else 
                {
                    // 일반적인 Real Time Rms 구조에서는 이 위치에 올 수 없다.
                    // 정상적이라면 ShBase에 OnInit의 Init에서 구현이 이루어져 있을 것이기 때문이다.
                }
                #endregion

                return ds;
            }
        }
    }

    //public class UserProfile
    //{

    //    private static string _userID = string.Empty;
    //    /// <summary>
    //    /// CRNet 사용자 ID 입니다.
    //    /// </summary>
    //    public static string UserID 
    //    {
    //        get 
    //        {
    //            FormsIdentity id = (FormsIdentity)System.Web.HttpContext.Current.User.Identity;
    //            return  id.Ticket.Name;
    //        }
    //    }
    //    /// <summary>
    //    /// CRNet 사용자 이름 입니다.
    //    /// </summary>
    //    public static string UserName 
    //    {
    //        get
    //        {
    //            FormsIdentity id = (FormsIdentity)System.Web.HttpContext.Current.User.Identity;
    //            return id.Ticket.UserData.Split('|')[0];
    //        }
    //    }
    //    /// <summary>
    //    /// 이 값이 True( 1 ) 이면 CRNet 로그인 사용자 입니다. 
    //    /// </summary>
    //    public static string AdminYN
    //    {
    //        get
    //        {
    //            FormsIdentity id = (FormsIdentity)System.Web.HttpContext.Current.User.Identity;
    //            return id.Ticket.UserData.Split('|')[1];
    //        }
    //    }
    //    /// <summary>
    //    /// 이 값이 True( 1 ) 이면 CRNet 관리자 입니다.
    //    /// </summary>
    //    public static string SuperAdminYN
    //    {
    //        get
    //        {
    //            FormsIdentity id = (FormsIdentity)System.Web.HttpContext.Current.User.Identity;
    //            return id.Ticket.UserData.Split('|')[2];
    //        }
    //    }
    //}
}
