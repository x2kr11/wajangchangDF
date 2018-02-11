using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using eHR.Framework.Common;

namespace eHR.Framework.SequentialNumber
{
    /// <summary>
    /// 채번
    /// </summary>
    public class Sequential
    {
        private string _division1 = string.Empty;

        /// <summary>
        /// 생성자 오버로딩
        /// </summary>
        /// <param name="dt"></param>
        public Sequential(DataTable dt)
        {
            this.SetSequential(dt);
        }

        /// <summary>
        /// 구분1 값
        /// </summary>
        public string Division1
        {
            get { return _division1; }
        }

        private string _division2 = string.Empty;

        /// <summary>
        /// 구분2 값
        /// </summary>
        public string Division2
        {
            get { return _division2; }
        }
        private string _division3 = string.Empty;
        /// <summary>
        /// 구분3 값
        /// </summary>
        public string Division3
        {
            get { return _division3; }
        }
        private string _divisionYear = string.Empty;

        /// <summary>
        /// 년도
        /// </summary>
        public string DateYear
        {
            get { return _divisionYear; }
        }
        private string _divisionMonth = string.Empty;
        /// <summary>
        /// 월
        /// </summary>
        public string DateMonth
        {
            get { return _divisionMonth; }
        }
        private string _padCount = string.Empty;
        /// <summary>
        /// 채번 뒤의 숫자 갯수 
        /// </summary>
        public string PadCount
        {
            get { return _padCount; }
        }
        private int _number = 0;

        /// <summary>
        /// 번호 
        /// </summary>
        public int Number
        {
            get { return _number; }
        }
        private DateTime _create_DT = new DateTime();

        /// <summary>
        /// 생성일 
        /// </summary>
        public DateTime CreateDT
        {
            get { return _create_DT; }
        }
        private string _create_ID = string.Empty;

        /// <summary>
        /// 등록 아이디 
        /// </summary>
        public string CreateID
        {
            get { return _create_ID; }
        }
        private DateTime _mondify_DT = new DateTime();

        /// <summary>
        /// 수정일 
        /// </summary>
        public DateTime MondifyDT
        {
            get { return _mondify_DT; }
        }
        private string _mondify_ID = string.Empty;

        /// <summary>
        /// 수정 아이디 
        /// </summary>
        public string MondifyID
        {
            get { return _mondify_ID; }
        }

        private string _display1 = string.Empty;
        /// <summary>
        /// 채번1
        /// </summary>
        public string Display1
        {
            get { return _display1; }
        }
       
        private string _display2 = string.Empty;

        /// <summary>
        /// 채번2 언더바
        /// </summary>
        public string Display2
        {
            get { return _display2; }
        }

        /// <summary>
        /// 채번 채우기
        /// </summary>
        /// <param name="dt"></param>
        public void SetSequential(DataTable dt)
        {
            DataRow dr = dt.Rows[0];

            _division1  = dr.ToEmptyString("Division1");
            _division2  = dr.ToEmptyString("Division2");
            _division3  = dr.ToEmptyString("Division3");
            _divisionYear = dr.ToEmptyString("DivisionYear");
            _divisionMonth = dr.ToEmptyString("DivisionMonth");
            _padCount    = dr.ToEmptyString("PadCount");
            _number      = dr.ToColumnInt( "Number");
            _display1   = dr.ToEmptyString("Display1");
            _display2   = dr.ToEmptyString("Display2");

            if (!string.IsNullOrEmpty(dr.ToEmptyString("Create_DT"))) //Create_DT 컬럼 널값 체크
                _create_DT = (DateTime)dr["Create_DT"];

            _create_ID = dr.ToEmptyString("Create_ID");
            
            if (!string.IsNullOrEmpty(dr.ToEmptyString("Modify_DT"))) //Mondify_DT 컬럼 널값 체크
                _mondify_DT = (DateTime)dr["Modify_DT"];

            _mondify_ID = dr.ToEmptyString("Modify_ID"); 
        }
    }
}
