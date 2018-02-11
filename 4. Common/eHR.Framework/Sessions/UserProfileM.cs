using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eHR.Framework.Cryptography;
using System.Data;
using eHR.Framework.Common;

namespace eHR.Framework.Sessions
{
    // ★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★
    // 2012.10.04 성정오 사용 하지 않습니다.
    // UserProfileM 대신에 UserProfile을 사용 할 것
    // ★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★★

    //public class UserProfileM
    //{
    //    private const string USER_ID                = "UserID";
    //    private const string USER_NM                = "UserName";
    //    private const string ADMIN_YN               = "AdminYN";
    //    private const string USER_EMAIL             = "Email";
    //    private const string USER_DATASET           = "UserDataSet";
    //    private const string USER_NO                = "UserNo";
    //    private const string USER_DEPT_CODE         = "UserDeptCode";
    //    private const string USER_TEAM_CODE         = "UserTeamCode";
    //    private const string USER_TEAM_NAME         = "UserTeamName";
    //    private const string USER_RESPONSIBLE_NAME  = "UserResponsibleName";
    //    private const string USER_COMPANY_NAME      = "UserCompanyName";
    //    private const string USER_TITLE_NAME        = "UserTitleName";

    //    /// <summary>
    //    /// 권한 데이터셋 String
    //    /// </summary>
    //    public static string UserRollData
    //    {
    //        get
    //        {
    //            string strDataSet = string.Empty;
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_DATASET];
    //            if (cookieDisclaimer != null)
    //            {
    //                strDataSet = UserEnDe.Decrypt(System.Web.HttpContext.Current.Request.Cookies[USER_DATASET].Values[0]);

    //                //if (string.IsNullOrEmpty(strUserID))
    //                //    strUserID = UserProfileM.HINET_USER;

    //                System.Web.HttpContext.Current.Request.Cookies[USER_DATASET].Value = UserEnDe.Encrypt(strDataSet);
    //                return strDataSet;
    //            }
    //            else
    //            {
    //                return null;
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_DATASET];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_DATASET, UserEnDe.Encrypt(value));
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                //cookieDisclaimer[USER_DATASET] = UserEnDe.Encrypt(value);
    //                cookieDisclaimer[USER_DATASET] = UserEnDe.Encrypt(value);
    //            }
    //            else
    //            {
    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                //cookieDisclaimer[USER_DATASET] = UserEnDe.Encrypt(value);
    //                cookieDisclaimer[USER_DATASET] = UserEnDe.Encrypt(value);
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 권한 데이터셋
    //    /// </summary>
    //    public static DataSet UserRollDataSet
    //    {
    //        get
    //        {
    //            return Helper.DeserializeFromString(eHR.Framework.Sessions.UserProfileM.UserRollData);
    //        }
    //    }

    //    /// <summary>
    //    /// 사원 아이디
    //    /// </summary>
    //    public static string UserID
    //    {
    //        get
    //        {
    //            string strUserID = string.Empty;
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_ID];
    //            if (cookieDisclaimer != null)
    //            {
    //                strUserID = UserEnDe.Decrypt(System.Web.HttpContext.Current.Request.Cookies[USER_ID].Values[0]);

    //                //if (string.IsNullOrEmpty(strUserID))
    //                //    strUserID = UserProfileM.HINET_USER;

    //                System.Web.HttpContext.Current.Request.Cookies[USER_ID].Value = UserEnDe.Encrypt(strUserID);
    //                return strUserID;
    //            }
    //            else
    //            {
    //                return "";
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_ID];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_ID, UserEnDe.Encrypt(value));
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_ID] = UserEnDe.Encrypt(value);
    //            }
    //            else
    //            {
    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_ID] = UserEnDe.Encrypt(value);
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 사원 이름
    //    /// </summary>
    //    public static string UserName
    //    {
    //        get
    //        {
    //            string strUserNM = string.Empty;
    //            try
    //            {
    //                HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_NM];
    //                if (cookieDisclaimer != null)
    //                {
    //                    strUserNM = System.Web.HttpContext.Current.Request.Cookies[USER_NM].Values[0];
    //                    if (string.IsNullOrEmpty(strUserNM))
    //                        strUserNM = UserProfileM.USER_NM;

    //                    return strUserNM;
    //                }
    //                else
    //                {
    //                    return string.Empty;
    //                }
    //            }
    //            catch (Exception)
    //            {
    //                return string.Empty;
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_NM];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_NM, value);
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);
    //            }

    //            if (cookieDisclaimer.Values.Count > 0) 
    //                cookieDisclaimer.Values.Clear();

    //            cookieDisclaimer[USER_NM] = value;
    //        }
    //    }

    //    /// <summary>
    //    /// 사원 이름
    //    /// </summary>
    //    public static string UserEmail
    //    {
    //        get
    //        {
    //            string strUserEmail = string.Empty;
    //            try
    //            {
    //                HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_EMAIL];
    //                if (cookieDisclaimer != null)
    //                {
    //                    strUserEmail = System.Web.HttpContext.Current.Request.Cookies[USER_EMAIL].Values[0];
    //                    if (string.IsNullOrEmpty(strUserEmail))
    //                        strUserEmail = UserProfileM.USER_NM;

    //                    return strUserEmail;
    //                }
    //                else
    //                {
    //                    return "";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return "";
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_EMAIL];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_EMAIL, value);
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_EMAIL] = value;
    //            }
    //            else
    //            {
    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_EMAIL] = value;
    //            }
    //        }
    //    }

    //    //public static string UserName
    //    //{
    //    //    get
    //    //    {
    //    //        string strUserNM = string.Empty;
    //    //        HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_NM];
    //    //        if (cookieDisclaimer != null)
    //    //        {
    //    //            strUserNM = UserEnDe.Decrypt(System.Web.HttpContext.Current.Request.Cookies[USER_NM].Values[0]);

    //    //            System.Web.HttpContext.Current.Request.Cookies[USER_NM].Value = UserEnDe.Encrypt(strUserNM);
    //    //            return strUserNM;
    //    //        }
    //    //        else
    //    //        {
    //    //            return "";
    //    //        }
    //    //    }
    //    //    set
    //    //    {
    //    //        HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_NM];
    //    //        if (cookieDisclaimer == null)
    //    //        {
    //    //            cookieDisclaimer = new HttpCookie(USER_NM, UserEnDe.Encrypt(value));
    //    //            System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //    //            if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //    //            cookieDisclaimer[USER_NM] = UserEnDe.Encrypt(value);
    //    //        }
    //    //        else
    //    //        {
    //    //            if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //    //            cookieDisclaimer[USER_NM] = UserEnDe.Encrypt(value);
    //    //        }
    //    //    }
    //    //}

    //    /// <summary>
    //    /// 사원번호
    //    /// </summary>
    //    public static string UserNo
    //    {
    //        get
    //        {
    //            string strUserNO = string.Empty;
    //            try
    //            {
    //                HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_NO];
    //                if (cookieDisclaimer != null)
    //                {
    //                    strUserNO = System.Web.HttpContext.Current.Request.Cookies[USER_NO].Values[0];
    //                    if (string.IsNullOrEmpty(strUserNO))
    //                        strUserNO = UserProfileM.USER_NO;

    //                    return strUserNO;
    //                }
    //                else
    //                {
    //                    return "";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return "";
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_NO];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_NO, value);
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_NO] = value;
    //            }
    //            else
    //            {
    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_NO] = value;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 부서 코드
    //    /// </summary>
    //    public static string UserDeptCode
    //    {
    //        get
    //        {
    //            string strUserDeptCode = string.Empty;
    //            try
    //            {
    //                HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_DEPT_CODE];
    //                if (cookieDisclaimer != null)
    //                {
    //                    strUserDeptCode = System.Web.HttpContext.Current.Request.Cookies[USER_DEPT_CODE].Values[0];
    //                    if (string.IsNullOrEmpty(strUserDeptCode))
    //                        strUserDeptCode = UserProfileM.USER_DEPT_CODE;

    //                    return strUserDeptCode;
    //                }
    //                else
    //                {
    //                    return "";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return "";
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_DEPT_CODE];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_DEPT_CODE, value);
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_DEPT_CODE] = value;
    //            }
    //            else
    //            {
    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_DEPT_CODE] = value;
    //            }
    //        }
    //    }


    //    /// <summary>
    //    /// 팀 코드
    //    /// </summary>
    //    public static string UserTeamCode
    //    {
    //        get
    //        {
    //            string strUserTeamCode = string.Empty;
    //            try
    //            {
    //                HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_TEAM_CODE];
    //                if (cookieDisclaimer != null)
    //                {
    //                    strUserTeamCode = System.Web.HttpContext.Current.Request.Cookies[USER_TEAM_CODE].Values[0];
    //                    if (string.IsNullOrEmpty(strUserTeamCode))
    //                        strUserTeamCode = UserProfileM.USER_TEAM_CODE;

    //                    return strUserTeamCode;
    //                }
    //                else
    //                {
    //                    return "";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return "";
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_TEAM_CODE];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_TEAM_CODE, value);
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_TEAM_CODE] = value;
    //            }
    //            else
    //            {
    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_TEAM_CODE] = value;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 팀 이름
    //    /// </summary>
    //    public static string UserTeamName
    //    {
    //        get
    //        {
    //            string strUserTeamName = string.Empty;
    //            try
    //            {
    //                HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_TEAM_NAME];
    //                if (cookieDisclaimer != null)
    //                {
    //                    strUserTeamName = System.Web.HttpContext.Current.Request.Cookies[USER_TEAM_NAME].Values[0];
    //                    if (string.IsNullOrEmpty(strUserTeamName))
    //                        strUserTeamName = UserProfileM.USER_TEAM_NAME;

    //                    return strUserTeamName;
    //                }
    //                else
    //                {
    //                    return "";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return "";
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_TEAM_NAME];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_TEAM_NAME, value);
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_TEAM_NAME] = value;
    //            }
    //            else
    //            {
    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_TEAM_NAME] = value;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 담당
    //    /// </summary>
    //    public static string UserResponsibleName
    //    {
    //        get
    //        {
    //            string strUserResponsibleName = string.Empty;
    //            try
    //            {
    //                HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_RESPONSIBLE_NAME];
    //                if (cookieDisclaimer != null)
    //                {
    //                    strUserResponsibleName = System.Web.HttpContext.Current.Request.Cookies[USER_RESPONSIBLE_NAME].Values[0];
    //                    if (string.IsNullOrEmpty(strUserResponsibleName))
    //                        strUserResponsibleName = UserProfileM.USER_RESPONSIBLE_NAME;

    //                    return strUserResponsibleName;
    //                }
    //                else
    //                {
    //                    return "";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return "";
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_RESPONSIBLE_NAME];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_RESPONSIBLE_NAME, value);
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_RESPONSIBLE_NAME] = value;
    //            }
    //            else
    //            {
    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_RESPONSIBLE_NAME] = value;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 회사이름
    //    /// </summary>
    //    public static string UserCompanyName
    //    {
    //        get
    //        {
    //            string strUserCompanyName = string.Empty;
    //            try
    //            {
    //                HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_COMPANY_NAME];
    //                if (cookieDisclaimer != null)
    //                {
    //                    strUserCompanyName = System.Web.HttpContext.Current.Request.Cookies[USER_COMPANY_NAME].Values[0];
    //                    if (string.IsNullOrEmpty(strUserCompanyName))
    //                        strUserCompanyName = UserProfileM.USER_COMPANY_NAME;

    //                    return strUserCompanyName;
    //                }
    //                else
    //                {
    //                    return "";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return "";
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_COMPANY_NAME];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_COMPANY_NAME, value);
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_COMPANY_NAME] = value;
    //            }
    //            else
    //            {
    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_COMPANY_NAME] = value;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 직책
    //    /// </summary>
    //    public static string UserTitleName
    //    {
    //        get
    //        {
    //            string strUserTitleName = string.Empty;
    //            try
    //            {
    //                HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_TITLE_NAME];
    //                if (cookieDisclaimer != null)
    //                {
    //                    strUserTitleName = System.Web.HttpContext.Current.Request.Cookies[USER_TITLE_NAME].Values[0];
    //                    if (string.IsNullOrEmpty(strUserTitleName))
    //                        strUserTitleName = UserProfileM.USER_TITLE_NAME;

    //                    return strUserTitleName;
    //                }
    //                else
    //                {
    //                    return "";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                return "";
    //            }
    //        }
    //        set
    //        {
    //            HttpCookie cookieDisclaimer = System.Web.HttpContext.Current.Request.Cookies[USER_TITLE_NAME];
    //            if (cookieDisclaimer == null)
    //            {
    //                cookieDisclaimer = new HttpCookie(USER_TITLE_NAME, value);
    //                System.Web.HttpContext.Current.Response.Cookies.Add(cookieDisclaimer);

    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_TITLE_NAME] = value;
    //            }
    //            else
    //            {
    //                if (cookieDisclaimer.Values.Count > 0) cookieDisclaimer.Values.Clear();
    //                cookieDisclaimer[USER_TITLE_NAME] = value;
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 사용자 세션을 제거합니다.
    //    /// </summary>
    //    public static void Remove()
    //    {
    //        if (System.Web.HttpContext.Current.Request.Cookies[USER_NM].Values != null)
    //        {
    //            System.Web.HttpContext.Current.Response.Cookies[USER_NM].Expires = DateTime.Today.AddDays(-1);
    //            System.Web.HttpContext.Current.Response.Cookies[USER_ID].Expires = DateTime.Today.AddDays(-1);
    //        }
    //    }

    //    //public static string HINET_USER
    //    //{
    //    //    set
    //    //    {
    //    //        HttpContext.Current.Session["HINET_USER"] = value;
    //    //    }
    //    //    get
    //    //    {
    //    //        if (HttpContext.Current.Session["HINET_USER"] == null)
    //    //            return "";
    //    //        else
    //    //            return HttpContext.Current.Session["HINET_USER"].ToString();
    //    //    }
    //    //}

    //    //public static string HINET_USER_NM
    //    //{
    //    //    set
    //    //    {
    //    //        HttpContext.Current.Session["HINET_USER_NM"] = value;
    //    //    }
    //    //    get
    //    //    {
    //    //        if (HttpContext.Current.Session["HINET_USER_NM"] == null)
    //    //            return "";
    //    //        else
    //    //            return HttpContext.Current.Session["HINET_USER_NM"].ToString();
    //    //    }
    //    //}

    //    //public static string HINET_ADMIN_YN
    //    //{
    //    //    set
    //    //    {
    //    //        HttpContext.Current.Session["HINET_ADMIN_YN"] = value;
    //    //    }
    //    //    get
    //    //    {
    //    //        if (HttpContext.Current.Session["HINET_ADMIN_YN"] == null)
    //    //            return "";
    //    //        else
    //    //            return HttpContext.Current.Session["HINET_ADMIN_YN"].ToString();
    //    //    }
    //    //}
    //}
}