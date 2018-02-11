using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace eHR.Framework.Common
{
    /// <summary>
    /// 작성자 : 고동남
    /// 작성일 : 2012.09.13
    /// 내  용 : 엑셀에 관련 Helper
    /// </summary>
    public static partial class Helper
    {
        /// <summary>
        /// 작성자 : 고동남
        /// 작성일 : 2012.09.13
        /// 내  용 : 엑셀에 있는 데이터를 DataTable로 반환을 하며 DataTable로 파싱 한 이후에 해당 파일은 삭제 합니다.
        ///          IncludeHeader는 기본으로 True를 사용 합니다.
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static DataTable GetDataTableFromExcelTempFile(string fileName)
        {
            return GetDataTableFromExcelTempFile(fileName, true);
        }

        /// <summary>
        /// 작성자 : 고동남
        /// 작성일 : 2012.09.13
        /// 내  용 : 엑셀에 있는 데이터를 DataTable로 반환을 하며 DataTable로 파싱 한 이후에 해당 파일은 삭제 합니다.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="isIncludeHeader"></param>
        /// <returns></returns>
        public static DataTable GetDataTableFromExcelTempFile(string fileName, bool isIncludeHeader)
        {
            string strConnectionString          = string.Empty;
            string strConnectionStringFormat    = string.Empty;

            #region # Provider Connection String 생성 
            //IMEX=1 -> 문자형 Type 선언
            if (System.IO.Path.GetExtension(fileName).Equals(".xlsx"))
            {
                //excelConnStrFormat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FilePath + ";Extended Properties=Excel 12.0";
                strConnectionStringFormat = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;HDR={0};IMEX=1;\"";
            }
            else
            {
                strConnectionStringFormat = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0;HDR={0};IMEX=1;\"";
            }
            
            //헤더 유무
            if (isIncludeHeader == true)
                strConnectionString = string.Format(strConnectionStringFormat, "YES");
            else
                strConnectionString = string.Format(strConnectionStringFormat, "NO");
            #endregion

            OleDbConnection conn = new OleDbConnection(strConnectionString);
            conn.Open();

            #region # 엑셀 워크시트명 가져오기 
            DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });// 'Sheets
            string strSheet = schemaTable.Rows[0]["Table_Name"].ToString();
            conn.Close();
            #endregion

            //전체조회
            string strQuery = "select * from [" + strSheet + "]";

            //전체조회
            OleDbCommand        cmd = new OleDbCommand(strQuery, conn);
            OleDbDataAdapter    apt = new OleDbDataAdapter();
            apt.SelectCommand       = cmd;

            DataTable dtExcel = new DataTable();

            apt.Fill(dtExcel);

            // Temp Excel 삭제 ( UpLoad용 엑셀은 데이터 추출과 동시에 삭제를 한다. )
            if (System.IO.File.Exists(fileName)) 
                System.IO.File.Delete(fileName);

            #region # Dispose 
            try
            {
                if (conn != null)
                {
                    conn.Dispose();
                    conn = null;
                }

                if (apt != null)
                {
                    apt.Dispose();
                    apt = null;
                }

                if (cmd != null)
                {
                    cmd.Dispose();
                    cmd = null;
                }
            }
            catch   { }
            finally { }
            #endregion

            return dtExcel;
        }
    }
}
