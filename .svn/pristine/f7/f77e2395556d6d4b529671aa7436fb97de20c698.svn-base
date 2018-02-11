using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using eHR.Framework.Common;
using System.Web.Security;
using System.Web;
using System.Web.Script.Serialization;
using eHR.Framework.Sessions;
using System.Collections;

namespace eHR.Framework.Base
{
    public class ShBaseAuth
    {
        public static bool SetLogin(System.Web.UI.Page page , string userId, string userPwd, string defaultAfterLoginPage, out string authRedirect)
        {
            authRedirect    = page.Request["ReturnUrl"];
            userId          = userId.Trim();

            eHR.Framework.Base.ShBase shBase = new Framework.Base.ShBase(page);
            DataSet dsUser = null;

            #region # AD 인증 처리
            try
            {
                string adDomain = Helper.GetAppConfig("Domain");
                string adPath = Helper.GetAppConfig("ADPath");

                // AD 인증 PASS 처리 / 테스트 때문에 진행 
                string strAutoPassLoginProcessIds = Helper.GetAppConfig("AutoPassLoginProcessIds");
                if (!string.IsNullOrEmpty(strAutoPassLoginProcessIds) && strAutoPassLoginProcessIds.IndexOf(userId) >= 0)
                {
                    // AD 인증 PASS
                }
                else
                {
                    string adUserName = adDomain + @"\" + userId;
                    System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry(adPath, adUserName, userPwd);

                    object obj = entry.NativeObject;            //AD 인증
                    System.DirectoryServices.DirectorySearcher adUser = new System.DirectoryServices.DirectorySearcher(entry);
                }
                // 아래 임시로 주석처리 by swarry
                dsUser = new DataSet(); // GetLoginData(userId);
            }
            catch (Exception)
            {
                shBase.Waring("현재 입력하신 아이디가 </br>등록되어 있지 않거나, </br>아이디 또는 비밀번호를 </br>잘못 입력 하셨습니다");
                return false;
            }
            #endregion

            #region # 아이디 유무 확인 및 인증쿠키 발행

            // 아이디 유무 확인 
            if (dsUser.IsNullOrEmpty())
            {
                // 오류 메세지를 통일 함으로써 로그인을 시도하는 사용자에게 불필요한 정보를 제공하지 않도록 한다.
                // ( 실질적인 사유는 : 로그인 정보가 없습니다!..가 맞다.. )
                shBase.Waring("현재 입력하신 아이디가 </br>등록되어 있지 않거나, </br>아이디 또는 비밀번호를 </br>잘못 입력 하셨습니다");
                return false;
            }

            // 인증쿠키 발행 

            DataTable   dtUser = dsUser.ToFirstTable();
            DataRow     drUser = dtUser.Rows[0];

            string strAuthRedirect = SetAuthentication(page, userId, dtUser, defaultAfterLoginPage);
            authRedirect = strAuthRedirect;

            if (!string.IsNullOrEmpty(strAuthRedirect) && strAuthRedirect.Equals(defaultAfterLoginPage))
                return false;

            #endregion

            return true;
        }

        public static bool SetLogin(System.Web.UI.Page page, string defaultAfterLoginPage, out string authRedirect)
        {
            authRedirect = page.Request["ReturnUrl"];
            string userId = "";

            eHR.Framework.Base.ShBase shBase = new Framework.Base.ShBase(page);
            DataSet dsUser = null;

            #region # SSO 인증 처리
            try
            {
                userId = SSOAuth(page);

                // 아래 임시로 주석처리 by swarry
                dsUser = new DataSet(); // GetLoginData(userId);
            }
            catch (Exception)
            {
                shBase.Waring("현재 입력하신 아이디가 </br>등록되어 있지 않거나, </br>아이디 또는 비밀번호를 </br>잘못 입력 하셨습니다");
                return false;
            }
            #endregion

            #region # 아이디 유무 확인 및 인증쿠키 발행

            // 아이디 유무 확인 
            if (dsUser.IsNullOrEmpty())
            {
                // 오류 메세지를 통일 함으로써 로그인을 시도하는 사용자에게 불필요한 정보를 제공하지 않도록 한다.
                // ( 실질적인 사유는 : 로그인 정보가 없습니다!..가 맞다.. )
                shBase.Waring("현재 입력하신 아이디가 </br>등록되어 있지 않거나, </br>아이디 또는 비밀번호를 </br>잘못 입력 하셨습니다");
                return false;
            }

            // 인증쿠키 발행 

            DataTable dtUser = dsUser.ToFirstTable();
            DataRow drUser = dtUser.Rows[0];

            string strAuthRedirect = SetAuthentication(page, userId, dtUser, defaultAfterLoginPage);
            authRedirect = strAuthRedirect;

            if (!string.IsNullOrEmpty(strAuthRedirect) && strAuthRedirect.Equals(defaultAfterLoginPage))
                return false;

            #endregion

            return true;
        }

        public static bool SetLogin(System.Web.UI.Page page, string userId, string defaultAfterLoginPage, out string authRedirect)
        {
            authRedirect = page.Request["ReturnUrl"];

            eHR.Framework.Base.ShBase shBase = new Framework.Base.ShBase(page);
            DataSet dsUser = null;

            #region # SSO 인증 처리
            try
            {
                // 아래 임시로 주석처리 by swarry
                dsUser = new DataSet(); // GetLoginData(userId);
            }
            catch (Exception)
            {
                shBase.Waring("현재 입력하신 아이디가 </br>등록되어 있지 않거나, </br>아이디 또는 비밀번호를 </br>잘못 입력 하셨습니다");
                return false;
            }
            #endregion

            #region # 아이디 유무 확인 및 인증쿠키 발행

            // 아이디 유무 확인 
            if (dsUser.IsNullOrEmpty())
            {
                // 오류 메세지를 통일 함으로써 로그인을 시도하는 사용자에게 불필요한 정보를 제공하지 않도록 한다.
                // ( 실질적인 사유는 : 로그인 정보가 없습니다!..가 맞다.. )
                shBase.Waring("현재 입력하신 아이디가 </br>등록되어 있지 않거나, </br>아이디 또는 비밀번호를 </br>잘못 입력 하셨습니다");
                return false;
            }

            // 인증쿠키 발행 

            DataTable dtUser = dsUser.ToFirstTable();
            DataRow drUser = dtUser.Rows[0];

            string strAuthRedirect = SetAuthentication(page, userId, dtUser, defaultAfterLoginPage);
            authRedirect = strAuthRedirect;

            if (!string.IsNullOrEmpty(strAuthRedirect) && strAuthRedirect.Equals(defaultAfterLoginPage))
                return false;

            #endregion

            return true;
        }

        public static string SSOAuth(System.Web.UI.Page page)
        {
            //eHR.Framework.Base.ShBase shBase = new Framework.Base.ShBase(page);
            string empNo = "";

            //try
            //{         
            //    string ssoSiteValue = "&" + SSOConfig.RequestSSOSiteParam + "=" + page.Request.ServerVariables["SERVER_NAME"];

            //    AuthCheck auth = new AuthCheck();
            //    AuthStatus status = auth.CheckLogon(AuthCheckLevel.Medium);
            //    String ret = HttpUtility.UrlEncode(auth.ThisURL, Encoding.UTF8);

            //    if (status == AuthStatus.SSOSuccess)
            //    {
            //        // SSO 인증 성공
            //        // 사번
            //        empNo = auth.GetSSODomainCookieValue("empNo");
            //    }
            //    else if (status == AuthStatus.SSOFirstAccess)
            //    {
            //        auth.TrySSO();
            //    }
            //    else if (status == AuthStatus.SSOUnAvailable)
            //    {
            //        shBase.Waring("인증서버를 이용할 수 없습니다.<br>");
            //    }
            //    else if (status == AuthStatus.SSOFail)
            //    {
            //        if (auth.ErrorNumber != ErrorCode.NO_ERR)
            //        {
            //            // 인증 요청 후 에러 발생
            //            shBase.Waring("인증 오류 코드 : " + auth.ErrorNumber);
            //        }
            //        else
            //        {
            //            if (page.Request["errorCode"] != null && page.Request["errorCode"] != "")
            //            {
            //                // SSO 인증 받지 않음.
            //            }
            //            else
            //            {
            //                shBase.Waring("인증 오류 코드 : errorCode=" + page.Request["errorCode"]);

            //                return "";
            //            }
            //        }
            //    }
            //    else if (status == AuthStatus.SSOAccessDenied)		// 사이트 접근이 거부로 설정 됐을 때
            //    {
            //        shBase.Waring(ErrorMessage.GetMessage(auth.ErrorNumber));

            //        // 접근 거부 안내 페이지 값이 설정되어 있는 경우 그 url로 이동한다.
            //        string deniedUrl = Helper.GetAppConfig("SITE_ACCESS_DENIED_PAGE");

            //        if (deniedUrl != "")
            //        {
            //            page.Response.Redirect(deniedUrl);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    shBase.Waring(ex.Message);
            //    return "";
            //}

            return empNo;
        }

        /// <summary>
        /// 작성자 : 고동남
        /// 작성일 : 2012.09.04
        /// 내  용 : 폼 인증 정보를 설정 하고 Redirect될 Url을 반환 합니다.
        /// </summary>
        public static string SetAuthentication(System.Web.UI.Page page ,  string userId, DataTable dtUser, string defaultAfterLoginPage)
        {
            eHR.Framework.Base.ShBase shBase = new Framework.Base.ShBase(page);

            Helper.SetClearFormsAuthenticationAndSession();

            string strRedirect = page.Request["ReturnUrl"];

            try
            {
                //방법 1.
                //FormsAuthentication.RedirectFromLoginPage(txtID.Text.Trim(), false);

                //방법 2.
                //또는 사용자 정의 데이타를 추가로 넣을 수 있다.
                string strTicketData = "Mostisoft GTWebFramework is Good solution";

                string strRmsUser = (Helper.GetAppConfig("Rms_RollUserId") == string.Empty) ? userId : Helper.GetAppConfig("Rms_RollUserId");

                DataRow drUser  = dtUser.Rows[0];
            
                UserProfileInfo info = new UserProfileInfo()
                {
                    CompanyCd           = drUser.ToEmptyString("SKCompany_CD")  
                    ,CompanyName        = drUser.ToEmptyString("SKCompany_NM")  
                    ,Id                 = drUser.ToEmptyString("Logon_ID")
                    ,Email              = drUser.ToEmptyString("EMailAddress")             
                    ,No                 = drUser.ToEmptyString("Emp_NO")
                    ,Name               = drUser.ToEmptyString("Emp_NM")          
                    ,TitleCd            = drUser.ToEmptyString("Title_CD")      
                    ,TitleName          = drUser.ToEmptyString("Title_NM")      
                    ,ResponsibleName    = drUser.ToEmptyString("Responsibility_NM")
                    ,ResponsibleCd      = drUser.ToEmptyString("Responsibility_CD")
                    ,TeamCd             = drUser.ToEmptyString("Team_CD")
                    ,TeamName           = drUser.ToEmptyString("Team_NM")
                    ,TeamCd2            = drUser.ToEmptyString("Team_CD2")
                    //,RollData           = Helper.CompressDataSet(dsRms)   // Cookie는 4096Byte 이상으로 만들어 지지 않기 때문에 포기. Roll Data 부분만 Session으로 돌린다.
                };

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                strTicketData   = shBase.UserEncrypt(serializer.Serialize(info));

                bool isPersistent = false;
                string strCookieString;
                HttpCookie httpCookie;

                //faTicket = new FormsAuthenticationTicket(1, txtID.Text.Trim(), DateTime.Now, DateTime.Now.AddMinutes(30), isPersistent, strCustomData);
                FormsAuthenticationTicket faTicket = new FormsAuthenticationTicket(1, userId, DateTime.Now, DateTime.Now.AddMinutes(FormsAuthentication.Timeout.Minutes), isPersistent, strTicketData);

                strCookieString = FormsAuthentication.Encrypt(faTicket);

                #region # Form 인증된 이후에 인증쿠키를 굽는다. ( 아래 사항 없다면 HttpContext.Current.User.Identity.IsAuthenticated = false 가 됨 )
                httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, strCookieString);

                string strRmsSaveType = Helper.GetAppConfig("Rms_RollDataSet_SaveSession");

                // 아래는 임시로 주석처리 by swarry
                DataSet dsRms = new DataSet(); // GetRmsPagePermission(strRmsUser);

                #region # RMS Permission 
                if (dsRms.IsNullOrEmpty())
                {
                    shBase.Waring("사이트 접근에 대한<br>권한이 없습니다.!</br>관리자에게 문의하세요!");
                    strRedirect = Helper.GetAppConfig("Rms_NotPermission_Code") ;
                    return strRedirect;
                }
                #endregion

                HttpContext.Current.Items[UserProfile.CONTEXT_ROLLDATASET_NAME] = dsRms;

                #region # Get Roll Data = Session인 경우 로그인과 동시에 Roll Data를 Session에 넣는다.
                if (string.IsNullOrEmpty(strRmsSaveType) || strRmsSaveType.ToLower() == "true")
                {
                    // Session의 TimeOut 시간을 폼인증 시간과 동일하게 진행한다. ( Cookie는 페이지가 로드되는 시간들( PostBack 되는 시간)을 제외 하지만 Session은 그러하지 못하기 때문에 X 2를 하여 보강 한다. 로그인데 대한 것은 인증쿠키에서 관여를 하기 때문에 상관없다. )
                    page.Session[UserProfile.SESSION_ROLLDATA_NAME] = shBase.UserEncrypt(Helper.CompressDataSet(dsRms));   // Session의 용량을 줄임과 동시에 보안을 강화 한다.
                }
                #endregion


                if (isPersistent)
                    httpCookie.Expires = faTicket.Expiration;

                //httpCookie.Expires = faTicket.Expiration;
                    
                httpCookie.Path = FormsAuthentication.FormsCookiePath;
                HttpContext.Current.Response.Cookies.Add(httpCookie);
                #endregion
            }
            catch (Exception ex)
            {
                shBase.Waring("인증 실패 하였습니다!</br>관리자에게 문의하세요!");
                strRedirect = defaultAfterLoginPage;
            }
        
            return strRedirect;
        }

        /// <summary>
        /// 작성자 : 고동남
        /// 작성일 : 2012.09.04
        /// 내  용 : 개발시 편의를 제공하기 위해서 로그인을 하지 않아도 자동으로 로그인이 가능 하도록 한다.
        /// </summary>
        public static void SetAutoDevLogin(System.Web.UI.Page page)
        {
            string strAutoLogin = Helper.GetAppConfig("AutoLogin");
            if (!string.IsNullOrEmpty(strAutoLogin) && strAutoLogin.Equals("true"))
            {
                if (!page.User.Identity.IsAuthenticated || UserProfile.Id == null)
                {
                    string strAuthRedirect;
                    ShBaseAuth.SetLogin(page, Helper.GetAppConfig("AutoLogin_Id"), Helper.GetAppConfig("AutoLogin_Pwd"), "Main.aspx", out strAuthRedirect);
                        
                    // 자동으로 로그인을 하도록 하는 경우 인증을 하고 나서 페이지 이동을 한다.
                    // 폼인증의 특성상 인증을 한 페이지의 LiveCycle 안에서는 인증 ( Identity.IsAuthenticated )이 False가 되므로
                    // 현재 페이지를 다시 로드 시키도록 한다.
                    // 이 메서드를 호출 하는 곳은 Master의 Init가 될 것이다...
                    page.SetPageNoCache();
                    page.Response.Redirect(page.Request.Url.PathAndQuery);
                    page.Response.End();
                }
            }
        }

        private static DataSet GetLoginData(string userId)
        {
            Hashtable ht = new Hashtable();
            eHR.Cmn.Biz.EmployeeBiz biz = new eHR.Cmn.Biz.EmployeeBiz();
            ht.Add("USERID", userId.Trim());
            return biz.SelectLoginEmployee(ht);
        }

        ///// <summary>
        ///// RMS 권한
        ///// </summary>
        ///// <param name="UserID"></param>
        ///// <returns></returns>
        //public static DataSet GetRmsPagePermission(string UserID)
        //{
        //    Hashtable hs = new Hashtable();
        //    eHR.CMM.Biz.RmsBiz PP = new eHR.CMM.Biz.RmsBiz();
        //    hs.Add("User_ID", UserID);
        //    return PP.RmsPagePermission(hs);
        //}

        ///// <summary>
        ///// RMS Role 권한 채크
        ///// </summary>
        ///// <param name="UserID"></param>
        ///// <returns></returns>
        //public static bool GetRmsRoleAuth(string userId , string roleCd)
        //{
        //    eHR.CMM.Biz.RmsBiz rb = new eHR.CMM.Biz.RmsBiz();
        //    Hashtable hs = new Hashtable();
        //    hs.Add("User_ID", userId);
        //    hs.Add("Role_ID", roleCd);
        //    bool bResult = rb.GetLoginRoleAuth(hs);

        //    return bResult;
        //}
    }
}
