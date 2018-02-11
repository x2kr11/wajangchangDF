/*==================================================================================
common.js
==================================================================================*/
/*-----------------------------------
페이지 로딩 시 초기화
-----------------------------------*/
$(document).ready(function () {
    //javascript 사용 포스트백을 위한 폼 저장.
    FORM = document.forms['aspnetForm'];

    //레이어 팝업 Error 메세지 레이어 Ok버튼 기능 정의.
    $('#__err_btnOk').click(function () {
        $('#__err_body').fadeOut();
        $('#__msg_error').fadeOut();
        return false; 
    });

    //레이어 팝업 Confirm 메세지 레이어 Yes버튼 기능 정의.
    $('#__con_btnYes').click(function () {
        $('#__con_body').fadeOut();
        $('#__msg_confirm').fadeOut();
        return false; 
    });

    //레이어 팝업 Confirm 메세지 레이어 No 버튼 기능 정의.
    $('#__con_btnNo').click(function () {
        $('#__con_body').fadeOut();
        $('#__msg_confirm').fadeOut();
        return false; 
    });

    //레이어 팝업 Warning 메세지 레이어 Ok버튼 기능 정의.
    $('#__warning_btnOk').click(function () {
        $('#__wan_body').fadeOut();
        $('#__msg_warning').fadeOut();

        MostiPopup.SetParentControlFoucs();

        return false; 
    });

    //레이어 팝업 Info 메세지 레이어 Ok버튼 기능 정의.
    $('#__info_btnOk').click(function () {
        if (MostiPopup.bSubmit) {
            if (MostiPopup.bAjax) {
                if (AjaxPageManager != null) {
                    AjaxPageManager.beginAsyncPostBack();

                    $('#__info_body').fadeOut();
                    $('#__msg_info').fadeOut();
                    $('#mw').fadeOut();
                    $('#__layer_pop').fadeOut();
                    MostiPopup.bShowPop = false;
                    MostiPopup.bSubmit = false;
                }
            }
            else {
                FORM.submit();
            }
        }
        else {
            $('#__info_body').fadeOut();
            $('#__msg_info').fadeOut();

            if (MostiPopup.bCallback) {
                if (MostiPopup.funcCallback != undefined && MostiPopup.funcCallback != null) {
                    MostiPopup.funcCallback();
                }
                MostiPopup.funcCallback = null;
                MostiPopup.bCallback = false;
            }
        }
        return false;
    });

    //윈도우 핸들러 등록
    window.onresize = MostiPopup.OnResize;
    window.onkeydown = MostiObject.Window_OnKeyDown;
    document.onkeydown = MostiObject.Document_OnKeyDown;
});

/*==================================================================================
시스템 레이어 팝업 정의
==================================================================================*/
//함수이름 중복 방지 객체생성.
var MostiPopup = {};

MostiPopup.intPopWidth = 0; //레이어 팝업 넓이
MostiPopup.intPopHeight = 0; //레이어 팝업 높이

MostiPopup.bShowPop = false; //페이어 팝업이 열렸는지 여부.
MostiPopup.bOrgPop = false; //Org 팝업이 열렸는지 여부.
MostiPopup.bSubmit = false; //폼을 서브밋할지 여부
MostiPopup.bAjax = false; //폼을 서브밋할때 Ajax 방식의 비동기 호출을 할지의 여부
MostiPopup.bCallback = false; //콜백함수 호출 여부

MostiPopup.objMemberID = null; //선택된 사원ID를 입력받을 텍스트박스
MostiPopup.objMemberName = null; //선택된 사원명을 입력받을 텍스트박스
MostiPopup.objID = null; //선택된 조직ID를 입력받을 텍스트박스
MostiPopup.objName = null; //선택된 조직명을 입력받을 텍스트박스
MostiPopup.objTargetCTL = null; //컨트롤 포커스 처리를 위한 전역 상수

MostiPopup.funcCallback = null; //콜백 함수 저장 변수

MostiPopup.strReportName = null; //출력할 크리스탈 레포트 명
MostiPopup.strReportParam = null; //크리스탈 레포트 파라미터
MostiPopup.strReportTitle = null; //크리스탈 레포트 제목

/*-----------------------------------
 기능 : 컨트롤 포커스 처리
------------------------------------*/
MostiPopup.SetParentControlFoucs = function () {
    if (!(MostiPopup.objTargetCTL == null || MostiPopup.objTargetCTL == "")) {
        MostiPopup.objTargetCTL.focus();
        MostiPopup.objTargetCTL = null;
    }
}

/*-----------------------------------
기능 : 에러 메세지 레이어 출력
-------------------------------------
strMsg      : 출력할 에러 메세지
strTitle    : 에러 메세지 제목
-----------------------------------*/
MostiPopup.ErrorMsg = function (strMsg, strTitle) {
    if (strMsg == null)
        return;
    if (strTitle == null)
        strTitle = "Error";

    document.getElementById("__err_title").innerText = strTitle;
    document.getElementById("__err_msg").innerText = strMsg;

    MostiPopup.LayerOpen("__msg_error", "__err_body");
}

/*-----------------------------------
기능 : 확인 메세지 레이어 출력
-------------------------------------
strConfirmMsg   : 출력할 확인 메세지
YesCallbackName : Yes선택 시 호출할 함수명
NoCallbackName  : No선택 시 호출할 함수명
-----------------------------------*/
MostiPopup.ConfirmMsg = function (strConfirmMsg, YesCallbackName, NoCallbackName) {
    if (strConfirmMsg == null)
        return;
    if (YesCallbackName == null && NoCallbackName == null)
        return;

    if (YesCallbackName != null)
        document.getElementById("__con_btnYes").onclick = YesCallbackName;

    if (NoCallbackName != null)
        document.getElementById("__con_btnNo").onclick = NoCallbackName;

    document.getElementById("__con_msg").innerText = strConfirmMsg;

    MostiPopup.LayerOpen("__msg_confirm", "__con_body");


}

/*-----------------------------------
기능 : 경고 메세지 레이어 출력
-------------------------------------
strWarningMsg   : 출력할 경고 메세지
ctlValidateTarget : 포커스를 되돌려줄 컨트롤
-----------------------------------*/
MostiPopup.WarningMsg = function (strWarningMsg, objFocusTargetID) {
    if (strWarningMsg == null)
        return;

    document.getElementById("__warning_msg").innerText = strWarningMsg;

    MostiPopup.LayerOpen("__msg_warning", "__wan_body");

    if (!(objFocusTargetID == null || objFocusTargetID == ''))
        MostiPopup.objTargetCTL = objFocusTargetID;
}

/*-----------------------------------
기능 : 정보 메세지 레이어 출력
-------------------------------------
strInfoMsg      : 출력할 정보 메세지
blnSumit        : Ok버튼을 눌렀을경우 폼을 서브밋 할지 여부
CallbackMethod  : Ok버튼을 눌렀을 경우 호출될 콜백함수(blnSubmit이 False일때만 작동한다.)
-----------------------------------*/
MostiPopup.InfoMsg = function (strInfoMsg, blnSubmit, CallbackMethod) {
    if (strInfoMsg == null)
        return;
    
    document.getElementById("__info_msg").innerText = strInfoMsg;
    MostiPopup.bSubmit = blnSubmit;

    if (!blnSubmit) {
        if (!(CallbackMethod == undefined || CallbackMethod == null)) {
            MostiPopup.bCallback = true;
            MostiPopup.funcCallback = CallbackMethod;
        }
    }

    MostiPopup.LayerOpen("__msg_info", "__info_body");
}
/*-----------------------------------
기능 : 팝업 레이어 출력
-------------------------------------
strUrl      : 팝업안에 호출할 페이지명 
strTitle    : 팝업 제목
intWidth    : 팝업 넓이
intHeight   : 팝업 높이
-----------------------------------*/
MostiPopup.ShowPopup = function (strUrl, strTitle, intWidth, intHeight) {

    //레이어 팝업의 위치를 화면 중앙으로 잡는다.
    var intTop = parseInt((document.body.clientHeight - intHeight) / 2);
    var intLeft = parseInt((document.body.clientWidth - intWidth) / 2);

    //레이어팝업 전체 크기, 위치 조정
    var divPop = document.getElementById("__layer_pop");

    divPop.style.top = intTop + "px";
    divPop.style.left = intLeft + "px";
    divPop.style.marginTop = "0px";
    divPop.style.marginLeft = "0px";
    divPop.style.width = intWidth + "px";
    divPop.style.height = intHeight + "px";

    //레이어팝업 콘텐츠영역을 전체 크기에 맞게 조정
    var divContentBody1 = document.getElementById("__layer_pop_content_body1");
    divContentBody1.style.height = (intHeight - 50) + "px";
    var divContentBody2 = document.getElementById("__layer_pop_content_body2");
    divContentBody2.style.height = (intHeight - 50) + "px";

    //iframe설정
    var iframe = document.getElementById("__layer_pop_content_frame");
    iframe.style.height = (intHeight - 54) + "px";

    if (strUrl.indexOf("?") > 0)
        strUrl = strUrl + "&hidMenuId=" + document.getElementById("hidMenuId").value;
    else
        strUrl = strUrl + "?hidMenuId=" + document.getElementById("hidMenuId").value;

    iframe.src = strUrl;

    //레이어팝업 타이틀 설정
    var PopupTitle = document.getElementById("__layer_pop_title");
    PopupTitle.innerText = strTitle;

    //레이어 팝업 높이와 넓이를 저장
    MostiPopup.intPopWidth = intWidth;
    MostiPopup.intPopHeight = intHeight;

    MostiPopup.LayerOpen('__layer_pop', 'mw');

    MostiPopup.bShowPop = true;
}

//레이어팝업을 닫는다.
MostiPopup.HidePopup = function () {
    $('#mw').fadeOut();
    $('#__layer_pop').fadeOut();
    MostiPopup.bShowPop = false;

    return false; // 2018.01.19 이호성 추가 // 클릭 후 상단으로 스크롤 이동 방지
    // 성정오 //
    //MostiPopup.BodyNoScrollRemoveEventListener();
}

/*-----------------------------------
기능 : 사원 선택 레이어 출력
-------------------------------------
objEmpID    : 레이어에서 선택한 사원ID를 입력받을 컨트롤
objEmpName  : 레이어에서 선택한 사원이름을 입력받을 컨트롤
objMultiCheck : 다중선택 확인 여부 (Y,N);
-----------------------------------*/
MostiPopup.MemberPopup = function (objEmpID, objEmpName, objMultiCheck) {
    //레이어 팝업의 위치를 화면 중앙으로 잡는다.
    var intTop = parseInt((document.body.clientHeight - 700) / 2);
    var intLeft = parseInt((document.body.clientWidth - 900) / 2);

    //레이어팝업 전체 크기, 위치 조정
    var divPop = document.getElementById("__org_pop");

    divPop.style.top = intTop + "px";
    divPop.style.left = intLeft + "px";
    divPop.style.marginTop = "0px";
    divPop.style.marginLeft = "0px";
    divPop.style.width = 900 + "px";
    divPop.style.height = 700 + "px";

    //레이어팝업 콘텐츠영역을 전체 크기에 맞게 조정
    var divContentBody1 = document.getElementById("__org_pop_content_body1");
    divContentBody1.style.height = (700 - 50) + "px";
    var divContentBody2 = document.getElementById("__org_pop_content_body2");
    divContentBody2.style.height = (700 - 50) + "px";

    //iframe설정
    var iframe = document.getElementById("__org_pop_content_frame");
    iframe.style.height = (700 - 54) + "px";
    iframe.src = "/eHRWEB/Common/eHROrgMemberChart.aspx?hidMenuId=" + document.getElementById("hidMenuId").value + "&Mode=" + objMultiCheck;

    //레이어팝업 타이틀 설정
    var PopupTitle = document.getElementById("__org_pop_title");
    PopupTitle.innerText = "Organization member";

    MostiPopup.bOrgPop = true;
    MostiPopup.bCallback = false;
    MostiPopup.funcCallback = null;

    //선택된 값을 입력받을 컨트롤 저장
    MostiPopup.objMemberID = objEmpID;
    MostiPopup.objMemberName = objEmpName;

    MostiPopup.LayerOpen('__org_pop', '__org_body');
}

/*-----------------------------------
기능 : 사원 선택 레이어 출력
-------------------------------------
funcCallback : 사원 선택 시 호출될 콜백함수명
-------------------------------------
funcCallback(사원ID, 사원명, 부서ID, 부서명, 직책명)의 인자를 순서로 갖는다.
-----------------------------------*/
MostiPopup.MemberPopupCallback = function (funcCallback, objMultiCheck,callbackType) {
    //레이어 팝업의 위치를 화면 중앙으로 잡는다.
    var intTop = parseInt((document.body.clientHeight - 700) / 2);
    var intLeft = parseInt((document.body.clientWidth - 900) / 2);

    //레이어팝업 전체 크기, 위치 조정
    var divPop = document.getElementById("__org_pop");

    divPop.style.top = intTop + "px";
    divPop.style.left = intLeft + "px";
    divPop.style.marginTop = "0px";
    divPop.style.marginLeft = "0px";
    divPop.style.width = 900 + "px";
    divPop.style.height = 700 + "px";

    //레이어팝업 콘텐츠영역을 전체 크기에 맞게 조정
    var divContentBody1 = document.getElementById("__org_pop_content_body1");
    divContentBody1.style.height = (700 - 50) + "px";
    var divContentBody2 = document.getElementById("__org_pop_content_body2");
    divContentBody2.style.height = (700 - 50) + "px";

    //iframe설정
    var iframe = document.getElementById("__org_pop_content_frame");
    iframe.style.height = (700 - 54) + "px";
    iframe.src = "/eHRWEB/Common/eHROrgMemberChart.aspx?hidMenuId=" + document.getElementById("hidMenuId").value + "&Mode=" + objMultiCheck +"&callType="+callbackType;

    //레이어팝업 타이틀 설정
    var PopupTitle = document.getElementById("__org_pop_title");
    PopupTitle.innerText = "Organization member";

    MostiPopup.bOrgPop = true;
    MostiPopup.bCallback = true;
    MostiPopup.funcCallback = funcCallback;

    MostiPopup.LayerOpen('__org_pop', '__org_body');
}

//멤버 팝업을 닫는다.
MostiPopup.HideMemberPopup = function () {
    $('#__org_body').fadeOut();
    $('#__org_pop').fadeOut();
    MostiPopup.bOrgPop = false;
    MostiPopup.bCallback = false;

    return false; // 2018.01.19 이호성 추가 // 클릭 후 상단으로 스크롤 이동 방지
}

/*-----------------------------------
기능 : 조직 선택 레이어 출력
-------------------------------------
objOrgID    : 레이어에서 선택한 조직ID를 입력받을 컨트롤
objOrgName  : 레이어에서 선택한 조직이름을 입력받을 컨트롤
-----------------------------------*/
MostiPopup.OrgPopup = function (objOrgID, objOrgName) {
    //레이어 팝업의 위치를 화면 중앙으로 잡는다.
    var intTop = parseInt((document.body.clientHeight - 650) / 2);
    var intLeft = parseInt((document.body.clientWidth - 450) / 2);

    //레이어팝업 전체 크기, 위치 조정
    var divPop = document.getElementById("__org_pop");

    divPop.style.top = intTop + "px";
    divPop.style.left = intLeft + "px";
    divPop.style.marginTop = "0px";
    divPop.style.marginLeft = "0px";
    divPop.style.width = 450 + "px";
    divPop.style.height = 650 + "px";

    //레이어팝업 콘텐츠영역을 전체 크기에 맞게 조정
    var divContentBody1 = document.getElementById("__org_pop_content_body1");
    divContentBody1.style.height = (650 - 50) + "px";
    var divContentBody2 = document.getElementById("__org_pop_content_body2");
    divContentBody2.style.height = (650 - 50) + "px";

    //iframe설정
    var iframe = document.getElementById("__org_pop_content_frame");
    iframe.style.height = (650 - 54) + "px";
    iframe.src = "/eHRWEB/Common/eHROrgChart.aspx?hidMenuId=" + document.getElementById("hidMenuId").value;

    //레이어팝업 타이틀 설정
    var PopupTitle = document.getElementById("__org_pop_title");
    PopupTitle.innerText = "Organization";

    MostiPopup.bOrgPop = true;

    //선택된 값을 입력받을 컨트롤 저장
    MostiPopup.objID = objOrgID;
    MostiPopup.objName = objOrgName;

    MostiPopup.LayerOpen('__org_pop', '__org_body');
}

//Org 팝업을 닫는다.
MostiPopup.HideOrgPopup = function () {
    $('#__org_body').fadeOut();
    $('#__org_pop').fadeOut();
    MostiPopup.bOrgPop = false;

    return false; // 2018.01.19 이호성 추가 // 클릭 후 상단으로 스크롤 이동 방지
}

//윈도우 리사이즈 시 팝업 레이어위치를 항상 중앙으로 변경한다.
MostiPopup.OnResize = function () {
    if (MostiPopup.bShowPop) {
        var divPop;

        //레이어팝업 전체 크기, 위치 조정
        divPop = document.getElementById("__layer_pop");

        divPop.style.top = parseInt((window.innerHeight - MostiPopup.intPopHeight) / 2) + "px";
        divPop.style.left = parseInt((document.body.clientWidth - MostiPopup.intPopWidth) / 2) + "px";
    }

    if (MostiPopup.bOrgPop) {
        var divPop;

        //레이어팝업 전체 크기, 위치 조정
        divPop = document.getElementById("__org_pop");

        divPop.style.top = parseInt((window.innerHeight - 700) / 2) + "px";
        divPop.style.left = parseInt((document.body.clientWidth - 900) / 2) + "px";
    }
}

//layer popup Open/Close
MostiPopup.LayerOpen = function (strPopID, strBodyID) {

    // 성정오 SCROLL //
    //MostiPopup.BodyNoScrollAddEventListener();

    var Layer_id = $('#' + strPopID),
        bg = Layer_id.parents('pop_bg');

    var fadeInSec = 200; // 2018.01.24 이호성 시간은 밀리세컨 단위 // 
    if (bg) {
        $('#' + strBodyID).fadeIn(fadeInSec);
        Layer_id.fadeIn(fadeInSec);
    } else {
        Layer_id.fadeIn(fadeInSec);
    };

    Layer_id.css('display', 'block');

    if (Layer_id.outerHeight() < $(document).height()) {
        Layer_id.css("top", Math.max(0, (($(window).height() - $(Layer_id).outerHeight()) / 2) + $(window).scrollTop()) + "px");
    } else {
        Layer_id.css('top', '0px');
    };

    Layer_id.find('.close_area').click(function () {       
        if (bg) {
            $('#' + strBodyID).fadeOut();
            Layer_id.fadeOut();
        } else {
            Layer_id.fadeOut();
        }
        window.onresize = null;

        return false; // 2018.01.19 이호성 추가 // 클릭 후 상단으로 스크롤 이동 방지
    });
};

/*-----------------------------------
기능 : 크리스탈레포트뷰어 팝업
-------------------------------------
strReportTitle  : 레포트뷰어 제목창에 출력할 텍스트
strReportName   : 레포트 파일명
strReportParam  : "|"를 구분자로 하는 레포트 파라미터(ex:"Name=이호성|Dept=IT")
-----------------------------------*/
MostiPopup.ReportPopup = function (strReportTitle, strReportName, strReportParam) {
    MostiPopup.strReportTitle = strReportTitle;
    MostiPopup.strReportName = strReportName;
    MostiPopup.strReportParam = strReportParam;

    var intTop = (window.screen.height - window.innerHeight) / 2;
    var intLeft = (window.screen.width - 870) / 2;

    var strOptions = "toolbar=no, location=no, menubar=no, scrollbars=no, status=no, resizable=no, width=870, height=" + window.innerHeight + ", top=" + intTop + ", left=" + intLeft;

    window.open("/Common/ReportViewer/RunReportViewer.aspx?hidMenuId=" + document.getElementById("hidMenuId").value, "ReportViewer", strOptions);
}

/*-----------------------------------
기능 : 결재창 열기
-------------------------------------
strUrl          : 결재창에 출력할 화면 URL
strWindowName   : 윈도우이름
-----------------------------------*/
MostiPopup.ApprPopup = function (strUrl, strWindowName) {
    // Fixes dual-screen position                         Most browsers      Firefox
    var dualScreenLeft = window.screenLeft != undefined ? window.screenLeft : screen.left;
    var dualScreenTop = window.screenTop != undefined ? window.screenTop : screen.top;

    var width = window.innerWidth ? window.innerWidth : document.documentElement.clientWidth ? document.documentElement.clientWidth : screen.width;
    var height = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight ? document.documentElement.clientHeight : screen.height;

    var left = ((width / 2) - (797 / 2)) + dualScreenLeft;
    var top = ((height / 2) - (750 / 2)) + dualScreenTop;

    var newWindow = window.open(strUrl, strWindowName, "toolbar=no, location=no, menubar=no, scrollbars=yes, status=no, resizable=no, width=797, height=750, top=" + top + ", left=" + left);

    // Puts focus on the newWindow
    if (window.focus) {
        newWindow.focus();
    }
}

/*==================================================================================
공통 문자열 함수 정의
==================================================================================*/
//함수이름 중복 방지 객체생성.
var MostiStr = {};

/*-----------------------------------
기능 : 문자열의 공백을 모두 제거
-------------------------------------
strString   : 공백을 제거할 문자열
-----------------------------------*/
MostiStr.AllTrim = function (strString) {
    return strString.replace(/\s/g, "");
}

/*-----------------------------------
기능 : 문자열 앞/뒤의 공백을 제거
-------------------------------------
strString   : 공백을 제거할 문자열
-----------------------------------*/
MostiStr.Trim = function (strString) {
    return strString.replace(/(^\s*)|(\s*$)/gi, "");
}

/*-----------------------------------
기능 : 문자열 앞의 공백을 제거
-------------------------------------
strString   : 공백을 제거할 문자열
-----------------------------------*/
MostiStr.LTrim = function (strString) {
    return strString.replace(/^\s+/, "");
}

/*-----------------------------------
기능 : 문자열 뒤의 공백을 제거
-------------------------------------
strString   : 공백을 제거할 문자열
-----------------------------------*/
MostiStr.RTrim = function (strString) {
    return strString.replace(/\s+$/, "");
}

/*-----------------------------------
기능 : 문자열의 크기만큼 대체 문자로 왼쪽을 채운다.
-------------------------------------
strString   : 대체 문자로 채울 문자열
intLength   : 문자열의 최대 크기
strRepChar  : 대체 문자열
-----------------------------------*/
MostiStr.LPad = function (strString, intLength, strRepChar) {
    var strString = strString + "";

    while (strString.length < intLength) {
        strString = strRepChar + strString;
    }

    return strString;
}

/*-----------------------------------
기능 : 문자열의 크기만큼 대체 문자로 오른쪽을 채운다.
-------------------------------------
strString   : 대체 문자로 채울 문자열
intLength   : 문자열의 최대 크기
strRepChar  : 대체 문자열
-----------------------------------*/
MostiStr.RPad = function (strString, intLength, strRepChar) {

    var strString = strString + "";

    while (strString.length < intLength) {
        strString = strString + strRepChar;
    }

    return strString;
}

/*-----------------------------------
기능 : 숫자로 된 문자열을 ',' 를 포함한 형식으로 변환
-------------------------------------
strString   : 변환할 문자열
-----------------------------------*/
MostiStr.FormatNumber = function (strString) {
    var aryString;
    var strNum;

    if (strString == "")
        return "";

    if (strString.lastIndexOf('.') > 0) {
        aryString = strString.split('.');

        aryString[0] = aryString[0].replace(/\D/g, "");
        aryString[1] = aryString[1].replace(/\D/g, "");

        if (aryString[1] == "")
            strNum = aryString[0];
        else
            strNum = aryString[0] + "." + aryString[1];
    }
    else
        strNum = strString.replace(/\D/g, "");

    var i;

    if (strNum.lastIndexOf('.') > 0)
        i = strNum.lastIndexOf('.') - 3;
    else
        i = strNum.length - 3;

    while (i > 0) {
        strNum = strNum.substr(0, i) + "," + strNum.substr(i);
        i -= 3;
    }

    return strNum;
}

/*==================================================================================
공통 객체 함수 정의
==================================================================================*/
//함수 중복 방지를 위한 객체 생성
MostiObject = {};

/*-----------------------------------
기능 : 트리 Object 를 만든다.
-------------------------------------
objTreeID   : 트리로 만들 Object ID
blnExpand   : true = 트리펼침, false = 2단
-----------------------------------*/
MostiObject.Maketree = function (objTreeID, blnExpand) {
    $tree = $('#' + objTreeID);

    var togglePlus = "<button class='toggle plus' type='button'></button>",
        toggleMinus = "<button class='toggle minus' type='button'></button>";

    if (blnExpand == true) // 펼쳐진 상태
        $tree.find('.tree_item').addClass('open');
    else // 닫힌상태
        $tree.find('.tree_item:gt(0)').find('ul').css('display', 'none');

    //default
    $tree.find('li:last-child').addClass('last');
    $tree.find('ul').siblings('.tree_item_wrap').prepend(togglePlus);
    $tree.find('.toggle').siblings('a').find('.ico').addClass('folder');

    //open 되어있는 li가 있을 경우
    $tree.find('.tree_item.open').parents('.tree_item').addClass('open');
    $tree.find('.tree_item.open').find('>ul').css('display', 'block');
    $tree.find('.tree_list').each(function () {
        if ($(this).css('display') == 'block') {
            $(this).siblings('.tree_item_wrap').find('.toggle').removeClass('plus').addClass('minus');
            $(this).siblings('.tree_item_wrap').find('.ico').removeClass('folder').addClass('folder_open')
        };
    });

    //선택한 노드에 select 효과를 준다.
    $tree.find('.tree_item_wrap').click(function (e) {
        $('.tree_list .txt').removeClass('select');
        $(this).children().find('.txt').addClass("select");
    });

    //click toggle
    $tree.find('.toggle').click(function (e) {
        var $item = $(this).closest('.tree_item'),
            $ico = $(this).siblings('a').find('.ico');
        $item.toggleClass('open');
        if ($item.hasClass('open')) {
            $(this).removeClass('plus').addClass('minus');
            $ico.removeClass('folder').addClass('folder_open');
            $item.find('>ul').slideDown(200);
        } else {
            $(this).removeClass('minus').addClass('plus');
            $ico.removeClass('folder_open').addClass('folder');
            $item.find('>ul').slideUp(200);
        }
        e.stopPropagation();
    });
}

/*-----------------------------------
기능 : 텍스트박스에서 엔터키 입력을 막는다.
-----------------------------------*/
MostiObject.Document_OnKeyDown = function () {
    if (event.srcElement.tagName.toUpperCase() == "INPUT")
        if (event.keyCode == 13) {
            event.keyCode = 9;
            return true;
        }
}

MostiObject.Window_OnKeyDown = function (e) {
    var evtK = (e) ? e.which : window.event.keyCode;
    var isCtrl = ((typeof isCtrl != 'undefiend' && isCtrl) || ((e && evtK == 17) || (!e && event.ctrlKey))) ? true : false;

    if ((isCtrl && evtK == 82) || evtK == 116) {
        if (e) { evtK = 505; } else { event.keyCode = evtK = 505; }
    }

    if (evtK == 505) {
        // 자바스크립트에서 현재 경로는 받아내는 메소드로 대치.
        location.reload(location.href);
        return false;
    }
}
/*-----------------------------------
기능 : eHR 표준 캘린더 출력
------------------------------------*/
$.fn.MostiDatepicker = function () {
    return this.each(function () {
        $(this).datepicker({
            showOn: "button",
            buttonImage: "/styles/images/form/calendar.jpg",
            buttonImageOnly: true,
            buttonText: "Select date",
            dateFormat: "yy-mm-dd",
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true
        });
    });
}

/*-----------------------------------
기능 : eHR 표준 캘린더 출력(minDate 범위 지정)
------------------------------------*/
$.fn.MostiDatepickerMinDate = function (minDate) {
    return this.each(function (minDate) {
        $(this).datepicker({
            showOn: "button",
            buttonImage: "/styles/images/form/calendar.jpg",
            buttonImageOnly: true,
            buttonText: "Select date",
            dateFormat: "yy-mm-dd",
            minDate: minDate,
            changeMonth: true,
            changeYear: true,
            showButtonPanel: true                       
        });

        $('#ui-datepicker-div').addClass('minDate'); // 이전 날짜 선택 불가능한 경우 디자인 적용 위하여 minDate 클래스 추가
    });
}

/*-----------------------------------------
기능 : Main 페이지의 Attendance 리스트 롤링
------------------------------------------*/
jQuery(function () {
    jQuery('#newsticker').Vnewsticker({
        speed: 2000,         //스크롤 스피드
        pause: 3000,        //잠시 대기 시간
        mousePause: true,   //마우스 오버시 일시정지(true=일시정지)
        showItems: 3,       //스크롤 목록 갯수 지정(1=한줄만 보임)
        direction: "Up"    //left=옆으로스크롤, up=위로스크롤, 공란=아래로 스크롤
    });
});

(function (a) {
    a.fn.Vnewsticker = function (b) {
        var c =
            {
                speed: 700,
                pause: 4000,
                showItems: 3,
                mousePause: true,
                isPaused: false,
                direction: "left",
                width: 0
            };
        var b = a.extend(c, b);
        moveSlide = function (g, d, e) {
            if (e.isPaused) {
                return
            }
            var f = g.children("ul");
            var h = f.children("li:first").clone(true);
            if (e.width > 0) {
                d = f.children("li:first").width()

            }
            f.animate({
                left: "-=" + d + "px"

            },
                e.speed, function () {
                    a(this).children("li:first").remove();
                    a(this).css("left", "0px")
                });
            h.appendTo(f)

        };
        moveUp = function (g, d, e) {
            if (e.isPaused) {
                return
            }
            var f = g.children("ul");
            var h = f.children("li:first").clone(true);
            if (e.height > 0) {
                d = f.children("li:first").height()
            }
            f.animate({
                top: "-=" + d + "px"
            },
                e.speed, function () {
                    a(this).children("li:first").remove();
                    a(this).css("top", "0px")
                });
            h.appendTo(f)
        };
        moveDown = function (g, d, e) {
            if (e.isPaused) {
                return
            }
            var f = g.children("ul");
            var h = f.children("li:last").clone(true);
            if (e.height > 0) {
                d = f.children("li:first").height()
            }
            f.css("top", "-" + d + "px").prepend(h);
            f.animate({
                top: 0
            },
                e.speed, function () {
                    a(this).children("li:last").remove()
                });
        };
        return this.each(function () {
            var f = a(this);
            var e = 0;
            var u = f.children("ul");
            var l = u.children("li").length;
            var w = u.children("li").width();
            var ulw = l * w + "px";
            f.css({ overflow: "hidden" })
                .children("ul").css({ position: "absolute" });

            if (b.width == 0) {
                f.children("ul").children("li").each(function () {
                    if (a(this).width() > e) {
                        e = a(this).height();
                        e2 = a(this).width();
                    }
                });
                f.children("ul").children("li").each(function () {
                    a(this).height(e)
                });
                f.height(e * b.showItems)
            }
            else {
                f.width(b.width)
            }
            var d = setInterval(function () {
                if (b.direction == "left") {
                    moveSlide(f, e2, b)
                    u.css({ width: ulw })
                } else if (b.direction == "Up") {
                    moveUp(f, e, b)
                }
                else {
                    moveDown(f, e, b)
                }
            },
                b.pause);
            if (b.mousePause) {
                f.bind("mouseenter", function () {
                    b.isPaused = true;
                }).bind("mouseleave", function () {
                    b.isPaused = false;
                })
            }
        })
    }
})(jQuery);
