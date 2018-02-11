using System;
using System.Globalization;

namespace eHR.Framework.Common
{
    /// 작성자 : 안익수
    /// 작성일 : 2013.02.25
    /// 내  용 : Create Data for TB_CMM_Calendar Table  
    public class CreateCalendarData
    {
         private DateTime _sourceDate;
        private string _nation = "Korea";
        public DateTime SourceDatre
        {
            set { this._sourceDate = value; }
        }

        private Calendar myCal = CultureInfo.InvariantCulture.Calendar;
    
        public CreateCalendarData ()
        {
            _sourceDate = DateTime.Now;
        }

        public CreateCalendarData(DateTime sourceDate)
        {
            SourceDatre = sourceDate;
        }

          //▶해당 요일
        public string GetDayNmOfWeek()
        {
            string txtResult = string.Empty;
            txtResult = ConvertFromDayOfWeekToString(myCal.GetDayOfWeek(_sourceDate), _nation);
            return txtResult;
        }

        //▶해당주에서 몇번째 일인지
        public string GetDayIndexOfWeek()
        {
            string txtResult = string.Empty;
            DayOfWeek tmpDayOfWeek = myCal.GetDayOfWeek(_sourceDate);
            txtResult = string.Format("{0}", (int) tmpDayOfWeek + 1);

            return txtResult;
        }
            //▶일자
       public string GetDayOfDate()
       {
           string txtResult = string.Empty;
            txtResult = _sourceDate.Day.ToString();
           return txtResult;
       }
        //▶월
        public string GetMonthOfDate()
        {
            string txtResult = string.Empty;
            txtResult = _sourceDate.Month.ToString();
            return txtResult;
        }
            //▶년도
        public string GetYearOfDate()
        {
            string txtResult = string.Empty;
            txtResult = _sourceDate.Year.ToString();
            return txtResult;
        }
        
            //▶해당월에 몇번재 주인지
        public int GetWeekNumberOfMonthISO8601(DateTime date)
        {
            int iResult = GetWeekNumberOfYearISO8601(date);
            int iResult1 = GetWeekNumberOfYearISO8601(date.AddDays(1 - date.Day));
            if (iResult >= iResult1)
                iResult = iResult - iResult1 + 1;

            return iResult;
        } 
            //▶해당년도에 몇번째 주인지
        public int   GetWeekNumberOfYearISO8601(DateTime date)
        {
            return  myCal.GetWeekOfYear(date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Sunday);
        }
            //▶해당년도에 몇 분기인지
        public int GetQuarterOfYear()
        {
            int quarter = 0;
            int tmpMonth = _sourceDate.Month;
            if (tmpMonth < 4)
                quarter = 1;
            else if (tmpMonth >= 4 && tmpMonth < 7)
                quarter = 2;
            else if (tmpMonth >= 7 && tmpMonth < 10)
                quarter = 3;
            else
                quarter = 4;
            return quarter;
        }
            //▶해당년도에 전후반체키
        public int GetHalfOfYear()
        {
            int half = 0;
            int tmpMonth = _sourceDate.Month;
            if (tmpMonth >= 1 && tmpMonth < 7)
                half = 1;
            else
                half = 2;
            return half;
        }

        private string ConvertFromDayOfWeekToString(DayOfWeek dayOfWeek, string nationType)
        {
            string txtResult = string.Empty;

            if (nationType.Equals("Korea"))
            {
                switch ((int) dayOfWeek)
                {
                    case 0:
                        txtResult = "일요일";
                        break;
                    case 1:
                        txtResult = "월요일";
                        break;
                    case 2:
                        txtResult = "화요일";
                        break;
                    case 3:
                        txtResult = "수요일";
                        break;
                    case 4:
                        txtResult = "목요일";
                        break;
                    case 5:
                        txtResult = "금요일";
                        break;
                    case 6:
                        txtResult = "토요일";
                        break;

                }
            }
            else
            {
                txtResult = dayOfWeek.ToString();
            }

            return txtResult;
        }
    }
    
      /*달력데이터 생성
        다른 곳에 넣구 돌리깅*/
        //DateTime startDate = new DateTime(2010,1,1);
        //DateTime endDate = new DateTime(2020,12,31);

        
        //for (int i = 0; i < 10000; i++)
        //{
        //    DateTime insertDate = startDate.AddDays(i);

        //    if (insertDate <= endDate)
        //    {
        //        CreateCalendarData ccd = new CreateCalendarData(insertDate);
        //        eHR.CMM.Biz.Calendar biz = new eHR.CMM.Biz.Calendar();

        //        Hashtable ht = new Hashtable();
        //        ht.Add("FullDate_dd", insertDate.ToString("yyyyMMdd"));
        //        ht.Add("Day_NM", ccd.GetDayNmOfWeek());
        //        ht.Add("Day_IDX", Convert.ToInt32(ccd.GetDayIndexOfWeek()));
        //        ht.Add("Date_NUM", Convert.ToInt32(ccd.GetDayOfDate()));
        //        ht.Add("Month_NUM", Convert.ToInt32(ccd.GetMonthOfDate()));
        //        ht.Add("Year_NUM", Convert.ToInt32(ccd.GetYearOfDate()));
        //        ht.Add("WeekInMonth_IDX", Convert.ToInt32(ccd.GetWeekNumberOfMonthISO8601(insertDate)));
        //        ht.Add("WeekInYear_IDX", Convert.ToInt32(ccd.GetWeekNumberOfYearISO8601(insertDate)));
        //        ht.Add("Quarter_IDX", Convert.ToInt32(ccd.GetQuarterOfYear()));
        //        ht.Add("Half_IDX", Convert.ToInt32(ccd.GetHalfOfYear()));
        //        ht.Add("WorkDay_TP", 1);
        //        ht.Add("Remark_CMT", "");

        //        int iResult = biz.InsertCalendar(ht);

        //    }
        //}
}