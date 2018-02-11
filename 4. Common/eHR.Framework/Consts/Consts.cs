using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace eHR.Framework
{
    public static class Consts
    {
        /// <summary>
        /// 채번 관리 Class
        /// </summary>
        public static class Sequential
        {
            /// <summary>
            /// 채번 업무 구분
            /// </summary>
            public enum Biz
            {
                /// <summary>
                /// 공통 ( CMM )
                /// </summary>
                [Description("공통")]
                C = 0,
                /// <summary>
                /// 위탁연구 ( ETR )
                /// </summary>
                [Description("위탁연구")]
                E = 1,
                /// <summary>
                /// 국책과제 ( NPA )
                /// </summary>
                [Description("국책과제")]
                N = 2,
                /// <summary>
                /// 투자예산 ( IVE )
                /// </summary>
                [Description("투자예산")]
                I = 3,
                /// <summary>
                /// Shared Service ( SSV )
                /// </summary>
                [Description("SharedService")]
                S = 4
            }

            /// <summary>
            /// 공통 구분
            /// </summary>
            public enum CmmDiv
            {
                /// <summary>
                /// 전자결재 품의 관리
                /// TB_CMM_EappConsultation에 ID 채번
                /// </summary>
                [Description("전자결재 품의 관리")]
                EC
            }

            /// <summary>
            /// 국책과제 구분
            /// </summary>
            public enum NpaDiv
            {
                #region # Master / Detail
                /// <summary>
                /// Master 구분
                /// </summary>
                [Description("Master")]
                M0,

                /// <summary>
                /// Detail 구분
                /// </summary>
                [Description("Detail")]
                D0,
                #endregion

                #region # 국책과제 상세 - 품의
                /// <summary>
                /// 국책과제 상세 - 참여품의
                /// </summary>
                [Description("참여품의")]
                DA,

                /// <summary>
                ///  국책과제 상세 - 연구비카드신청품의
                /// </summary>
                [Description("연구비카드신청품의")]
                DB,

                /// <summary>
                ///  국책과제 상세 - 협약품의
                /// </summary>
                [Description("협약품의")]
                DC,

                /// <summary>
                ///  국책과제 상세 - 년차/단계/최종
                /// </summary>
                [Description("보고서")]
                DD,

                /// <summary>
                ///  국책과제 관리 - 기술료 품의
                /// </summary>
                [Description("기술료")]
                DE,

                /// <summary>
                ///  국책과제 관리 - 정산환수금 품의
                /// </summary>
                [Description("정산환수금")]
                DF,

                /// <summary>
                ///  국책과제 관리 - 기술료/정산환수금 동시 품의
                /// </summary>
                [Description("기술료/정산환수금")]
                DG
                #endregion
            }

            /// <summary>
            /// 국책과제 파일업로드 구분 
            /// </summary>
            public enum NpaFileDiv
            {
                /// <summary>
                ///  사업계획서 파일업로드 
                /// </summary>
                [Description("사업계획서")]
                BP,

                /// <summary>
                ///  협약서 파일업로드 
                /// </summary>
                [Description("협약서")]
                AG,

                /// <summary>
                ///  보고서 파일업로드 
                /// </summary>
                [Description("보고서")]
                RP,

                /// <summary>
                ///  납부요청공문 파일업로드 
                /// </summary>
                [Description("납부요청공문")]
                RD,

                /// <summary>
                ///  실시계약서 파일업로드 파일업로드 
                /// </summary>
                [Description("실시계약서")]
                EF,

                /// <summary>
                ///  회계감사보고서 파일업로드 파일업로드 
                /// </summary>
                [Description("회계감사보고서")]
                AR,

                /// <summary>
                /// 기타( 기본 ) 파일업로드 
                /// </summary>
                [Description("기타")]
                EC
            }

            /// <summary>
            /// 위탁연구 구분
            /// </summary>
            public enum EtrDiv
            {
                #region # Master / Detail
                /// <summary>
                /// Master 구분
                /// </summary>
                [Description("Master")]
                M0,

                /// <summary>
                /// Detail 구분
                /// </summary>
                [Description("Detail")]
                D0,
                #endregion

                #region # 위탁연구 상세 - 품의
                /// <summary>
                /// 위탁연구 상세 - 수행품의
                /// </summary>
                [Description("수행품의")]
                DA,

                /// <summary>
                ///  위탁연구 상세 - 위탁연구 진행내역
                /// </summary>
                [Description("진행내역")]
                DB,

                /// <summary>
                ///  위탁연구 상세 - 중간/최종 보고서
                /// </summary>
                [Description("보고서")]
                DC
                #endregion

            }

            /// <summary>
            /// 위탁연구 파일업로드 구분
            /// </summary>
            public enum EtrFileDiv
            {
                #region # 위탁연구 상세 - 수행품의
                /// <summary>
                /// 위탁연구 상세 - 수행품의 - 연구계획서 파일업로드
                /// </summary>
                [Description("연구계획서")]
                RP,

                /// <summary>
                ///  위탁연구 상세 - 수행품의 - 연구계약서 파일업로드
                /// </summary>
                [Description("연구계약서")]
                RS,

                /// <summary>
                ///  위탁연구 상세 - 수행품의 - 품의서 파일업로드
                /// </summary>
                [Description("품의서")]
                AP,
                #endregion

                #region # 위탁연구 상세 - 중간/최종 보고서

                /// <summary>
                ///  위탁연구 상세 - 중간/최종 보고서 - 최종보고서 파일업로드
                /// </summary>
                [Description("최종보고서")]
                FR,

                /// <summary>
                ///  위탁연구 상세 - 중간/최종 보고서 - 최종발표회 파일업로드
                /// </summary>
                [Description("최종발표회")]
                FB,

                #endregion

                /// <summary>
                /// 기타( 기본 ) 파일업로드 
                /// </summary>
                [Description("기타")]
                EC
            }

            /// <summary>
            /// 투자예산 구분
            /// </summary>
            public enum IveDiv
            {
                #region # Master
                /// <summary>
                /// Master 구분
                /// </summary>
                [Description("필드정의")]
                M0
                #endregion
            }

            /// <summary>
            /// 투자예산 파일업로드 구분
            /// </summary>
            public enum IveFileDiv
            {
                /// <summary>
                /// 기타( 기본 ) 파일업로드 
                /// </summary>
                [Description("첨부파일")] 
                EC
            }
        }

        /// <summary>
        /// 국책과제 상수 Class
        /// </summary>
        public static class Npa
        {
            /// <summary>
            /// 국책과제 보고서 구분
            /// </summary>
            public enum NpaReport
            {
                /// <summary>
                /// 년차 보고서
                /// </summary>
                CMM03008
                /// <summary>
                /// 단계 보고서
                /// </summary>
                , CMM03009
                /// <summary>
                /// 최종 보고서
                /// </summary>
                , CMM03010
            }
        }


        public static class Cmm
        {
            /// <summary>
            /// 전자결재 상태
            /// </summary>
            public enum ApprovalState
            {
                /// <summary>
                /// 전자결재 승인
                /// </summary>
                CMM04001
                
                /// <summary>
                /// 전자결재 철회
                /// </summary>
                , CMM04002
                
                /// <summary>
                /// 전자결재 품의중
                /// </summary>
                , CMM04003
                
                /// <summary>
                /// 전자결재 외부 품의
                /// </summary>
                , CMM04004

                /// <summary>
                /// 전자결재 전송실패
                /// </summary>
                , CMM04005

               
            }

            /// <summary>
            /// 전자결재 구분
            /// </summary>
            public enum ApprovalDivision
            {
                /// <summary>
                /// 위탁연구 - 수행품의
                /// </summary>
                CMM03001
                /// <summary>
                /// 위탁연구 - 변경품의
                /// </summary>
                ,CMM03002
                /// <summary>
                /// 위탁연구 - 중간품의
                /// </summary>
                ,CMM03003
                /// <summary>
                /// 위탁연구 - 종료품의
                /// </summary>
                ,CMM03004
                /// <summary>
                /// 국책과제 - 참여품의
                /// </summary>
                ,CMM03005
                /// <summary>
                /// 국책과제 - 연구비카드품의
                /// </summary>
                ,CMM03006
                /// <summary>
                /// 국책과제 - 협약품의
                /// </summary>
                ,CMM03007
                /// <summary>
                /// 국책과제 - 년차보고품의
                /// </summary>
                ,CMM03008
                /// <summary>
                /// 국책과제 - 단계보고품의
                /// </summary>
                ,CMM03009
                /// <summary>
                /// 국책과제 - 최종보고품의
                /// </summary>
                ,CMM03010
                /// <summary>
                /// 국책과제 - 기술료품의
                /// </summary>
                ,CMM03011
                /// <summary>
                /// 국책과제 - 정산환수금품의
                /// </summary>
                ,CMM03012
                /// <summary>
                /// 국책과제 - 기술료/정산환수금 동시품의
                /// </summary>
                ,CMM03013

            }

            /// <summary>
            /// 작성자 : 강신호
            /// 전자결재 품의상태 [CMM05]
            /// </summary>
            public enum EApprovalState
            {
                /// <summary>
                /// 기안(draft)
                /// </summary>
                CMM05001,

                /// <summary>
                /// 완료(complete)
                /// </summary>
                CMM05002,

                /// <summary>
                /// 반려(reject)
                /// </summary>
                CMM05003,

                /// <summary>
                /// 철회(withdraw)
                /// </summary>
                CMM05004

            }
        }

        /// <summary>
        /// 이메일
        /// </summary>
        public static class Email
        {
            /// <summary>
            /// 이메일 구분
            /// </summary>
            public enum EmailStatus
            {
                /// <summary>
                /// 이메일 구분 - To
                /// </summary>
                CMM01001
                /// <summary>
                /// 이메일 구분 - Cc
                /// </summary>
                ,CMM01002
                /// <summary>
                /// 이메일 구분 - Bcc
                /// </summary>
                ,CMM01003
            }
            /// <summary>
            /// 이메일 업무 구분
            /// </summary>
            public enum EmailWorkLoadStatus
            {
                /// <summary>
                /// Shared Service - 업무량 등록 요청
                /// </summary>
                CMM02001
                /// <summary>
                /// Shared Service - 업무량 수정 요청
                /// </summary>
                ,CMM02002
                /// <summary>
                /// 국책과제 - 신용평가의뢰 요청
                /// </summary>
                ,CMM02003
            }
        }

        /// <summary>
        /// 위탁연구 상수 Class
        /// </summary>
        public static class Etr
        {
            /// <summary>
            /// 위탁연구 보고회 여부
            /// </summary>
            public enum DetailStatus
            {
                /// <summary>
                /// 위탁연구 상세 - 수행품의
                /// </summary>
                ContractConsultation_CD

                /// <summary>
                    /// 위탁연구 상세 - 중간/최종 보고서 - 중간 보고회 여부 
                    /// </summary>
                ,
                MidBriefingSes_TP

                    /// <summary>
                    /// 위탁연구 상세 - 중간/최종 보고서 - 중간 보고서 품의 여부
                    /// </summary>
                    ,
                MidReport_CD

                    /// <summary>
                    /// 위탁연구 상세 - 중간/최종 보고서 - 최종 보고회 여부
                    /// </summary>
                    ,
                FinalBriefingSes_TP

                    /// <summary>
                    /// 위탁연구 상세 - 중간/최종 보고서 - 최종 보고서 품의 여부
                    /// </summary>
                    ,
                FinalReport_TP

                    /// <summary>
                    /// 위탁연구 상세 - 종료보고
                    /// </summary>
                    , SignOffBriefing_CD
            }
        }

        /// <summary>
        /// 투자예산 상수 Class
        /// </summary>
        public static class Ive
        {

        }

        /// <summary>
        /// ShareService 상수 Class
        /// </summary>
        public static class Ssv
        {
            ///// <summary>
            ///// 연구과제 팀 구분
            ///// </summary>
            //public enum ManageTeam
            //{
            //    /// <summary>
            //    /// N본부
            //    /// </summary>
            //    [Description ("Eng.본부")]
            //    SSV03001
            //    /// <summary>
            //    /// 기술원
            //    /// </summary>
            //    ,[Description ("기술원")]
            //    SSV03002
            //}

            public enum DivisionCD
            {
                /// <summary>
                /// 기술원
                /// </summary>
                [Description ("기술원")]
                SSV01
                /// <summary>
                /// Eng.본부
                /// </summary>
                ,[Description ("Eng.본부")]
                SSV02
            }
        }

        /// <summary>
        /// 전자결재 품의 메시지
        /// </summary>
        public static class ReportMessage
        {
            // 기안
            public const string Drafting = "품의가 기안되었습니다.";
            // 반려
            public const string Companion = "품의가 반려되었습니다.";
            /// <summary>
            /// 승인
            /// </summary>
            public const string Approval = "품의가 완료되었습니다.";

            /// <summary>
            /// 품의 실패
            /// </summary>
            public const string ApprovalFalse = "품의 진행이 정상적으로 완료 되지 않았습니다.";

            /// <summary>
            /// 품의중 에러
            /// </summary>
            public const string ApprovalError = "품의 중 에러가 발생하였습니다.";
        }
        
        /// <summary>
        /// 전자결재 품의 메시지 타이틀
        /// </summary>
        public static class ReportTitle
        {
            // 기안
            public const string DraftingTitle = "안내";
            // 반려
            public const string CompanionTitle = "안내";
            /// <summary>
            /// 승인
            /// </summary>
            public const string ApprovalTitle = "안내";

            /// <summary>
            /// 품의 중 에러
            /// </summary>
            public const string ApprovalErrorTitle = "안내";
        }

        /// <summary>
        /// 작성자 : 강신호
        /// 작성일 : 2012.10.09
        /// 내  용 : 전자결재 상태저장 결과 [공통코드 CMM06]
        /// </summary>
        public static class ApprovalResponseCode
        { 
            // 성공
            public const string CMM06001_NM = "0000";
            public const string CMM06001_Comment = "성공";

            //DB 오류
            public const string CMM06002_NM = "0010";
            public const string CMM06002_Comment = "DB 오류";

            //System 오류
            public const string CMM06003_NM = "0020";
            public const string CMM06003_Comment = "System 오류";
        }

        /// <summary>
        /// 
        /// </summary>
        public static class Eapp
        {
            // 기안
            public const string CMM06001_NM = "0000";
            public const string CMM06001_Comment = "성공";

            //DB 오류
            public const string CMM06002_NM = "0010";
            public const string CMM06002_Comment = "DB 오류";

            //System 오류
            public const string CMM06003_NM = "0020";
            public const string CMM06003_Comment = "System 오류";
        }

        /// <summary>
        /// 리스트에 데이터가 없을때 메시지
        /// </summary>
        public static class DataListNullMessage
        {
            public const string Noinformation = "조회하신 정보가 없습니다.";

            public const string NoCreateinformation = "등록할 정보가 없습니다.";

            public const string NoEmcReport = "예산통제부 내역이 등록되지 않았습니다.";

            public const string NoWorkLoad = "담당자가 지정되어 있지 않습니다. 담당자를 지정하셔야 합니다!<br/> 기술 전략팀에 문의 하세요!";
            
            public const string NoClickWorkLoad = "조회된 데이터가 없습니다.";
        }

        /// <summary>
        /// 작성자 : 이윤호
        /// 작성일 : 2012.09.05
        /// 내  용 : 팝업 공통 메시지
        /// </summary>
        public static class PopMessage
        {
            /// <summary>
            /// 파일첨부 필수 메시지
            /// </summary>
            public const string NonAttachments = "파일을 첨부하세요"; 
        }
       
        /// <summary>
        /// 작성자 : 고동남
        /// 작성일 : 2012.09.05
        /// 내  용 : GTFileUpLoad의 필터를 세팅
        /// </summary>
        public enum GtFileUploadFilter
        {
            [Description("GTFileUploadFilter_Document_A")]
            DocumentA = 1,
            [Description("GTFileUploadFilter_Document_B")]
            DocumentB = 2,
            [Description("GTFileUploadFilter_Image_A")]
            ImageA = 4,
            [Description("GTFileUploadFilter_Image_B")]
            ImageB = 8,
        }

        /// <summary>
        /// 메일 디자인 형식에 따라 전송
        /// </summary>
        public static class DesignSendMail
        {

            public enum DesignFormatHtml
            {
                /// <summary>
                /// 디자인 보통 사이즈
                /// </summary>
                [Description("SendMailHtmlTemplate_Basic")]
                HtmlType01,

                /// <summary>
                /// 디자인 960 사이즈
                /// </summary>
                [Description("SendMailHtmlTemplate_960")]
                HtmlType02
            }
        }

        /// <summary>
        /// RepeaterStatus의 요약 설명입니다.
        /// </summary>
        public struct RepeaterRowStatus
        {
            /// <summary>
            /// 리피터 신규행 플래그
            /// biz 단에서 데이터 추가
            /// </summary>
            public const string ADD = "A";

            /// <summary>
            /// 리피터 신규행 삭제 플래그
            /// biz 단에서 비 삭제
            /// </summary>
            public const string ADDDELETE = "AD";

            /// <summary>
            /// 리피터 데이터 삭제 플래그
            /// biz 단에서 데이터 삭제
            /// </summary>
            public const string ORGDELETE = "OD";

            /// <summary>
            /// 리피터 데이터 업데이트 플래그
            /// biz 단에서 데이터 업데이트
            /// </summary>
            public const string ORGUPDATE = "OU";

            /// <summary>
            /// 리피터 기존 데이터
            /// biz 단에서 기존 데이터 변경 안함
            /// </summary>
            public const string ORG = "O";
        }
    }
}






