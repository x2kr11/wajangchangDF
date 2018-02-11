using System;
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
using System.Web.Security;

namespace eHR.Framework.Common
{
    public static partial class Helper
    {
        /// <summary>
        /// 컬럼 구분자로 사용 합니다.
        /// (char)2값을 반환합니다.
        /// </summary>
        public static string COL_DELI_STR = Convert.ToString((char)2);

        /// <summary>
        /// (char)2값을 반환합니다.
        /// 컬럼 구분자로 사용 합니다.
        /// </summary>
        public static char COL_DELI_CHR = (char)2;

        /// <summary>
        /// (char)4값을 반환합니다.
        /// 행 구분자로 사용 합니다.
        /// </summary>
        public static string ROW_DELI_STR = Convert.ToString((char)4);
        /// <summary>
        /// (char)4값을 반환합니다.
        /// 행 구분자로 사용 합니다.
        /// </summary>
        public static char ROW_DELI_CHR = (char)4;

        /// <summary>
        /// DataTable을 특정 구분자를 기준으로 문자열로 변환 합니다.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="headerVisible"></param>
        /// <returns></returns>
        public static string DataTable2String(System.Data.DataTable dataTable, bool headerVisible)
        {
            //sbResult의 인스턴스가 생성되지 않았으면 생성하도록 합니다.
            System.Text.StringBuilder sbResult = new System.Text.StringBuilder();

            //헤더를 텍스트에 쓰는지 여부
            string strHeader = string.Empty;

            if (headerVisible)
            {
                foreach (System.Data.DataColumn col in dataTable.Columns)
                {
                    sbResult.Append(col.ColumnName);
                    sbResult.Append(COL_DELI_STR);
                }
                strHeader = Helper.RemoveLastDelimeter(sbResult.ToString(), COL_DELI_STR);
                strHeader += ROW_DELI_STR;
            }

            //	데이터를 텍스트로 변환
            string strRowData = string.Empty;
            foreach (System.Data.DataRow row in dataTable.Rows)
            {
                sbResult.Clear();

                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    sbResult.Append(row[i].ToString());
                    sbResult.Append(COL_DELI_STR);
                }
                strRowData += Helper.RemoveLastDelimeter(sbResult.ToString(), COL_DELI_STR);
                strRowData += ROW_DELI_STR;
            }
            strRowData = Helper.RemoveLastDelimeter(strRowData, ROW_DELI_STR);
            return strRowData;
        }

        /// <summary>
        /// DataRow 를 DataTable로 변환 합니다.
        /// </summary>
        /// <param name="datarows"></param>
        /// <returns></returns>
        public static DataTable DataRows2DataTable(DataRow[] datarows)
        {
            if (datarows.Length <= 0)
                return null;

            DataTable dt = new DataTable();
            //컬럼만들기
            foreach (DataColumn dc in datarows[0].Table.Columns)
                dt.Columns.Add(new DataColumn(dc.ColumnName, dc.DataType));

            DataRow newrow = null;
            //데이타 넣기
            foreach (DataRow dr in datarows)
            {
                newrow = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    newrow[i] = dr[i];
                }
                dt.Rows.Add(newrow);
            }
            return dt;
        }

        /// <summary>
        /// 서버에서 저장된 파일 정보를 파일컨트롤에 뿌리기 위해서 컬럼단위로 string배열로 반환합니다.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="uploadPath"></param>
        /// <returns>str[0]- 파일이름 , str[1] - uri리스트(컨트롤에서 더블클릭시 파일다운로드되는 경로), str[2] -파일GUI(파일풀패스 파일아이디 파일seq) 배열안의 구분자는 *</returns>
        public static string[] ConvertRowData(DataTable dataTable, string uploadPath)
        {
            string[] str = { "", "", "" };
            string strRow = eHR.Framework.Common.Helper.COL_DELI_STR;
            string strUploadPath = uploadPath;
            foreach (DataRow item in dataTable.Rows)
            {
                string strPath = item[1].ToString().Replace("\\", "/");
                string strDomain = string.Format("/UserControl/UploadD.aspx?oldFileNm={0}&newFileNm={1}&subFolder={2}", item[0].ToString(), item[0].ToString(), item[1].ToString());

                string strFilePath = Path.Combine(strUploadPath, item[1].ToString(), item[0].ToString());
                strFilePath = strFilePath.Replace("\\", "\\\\");
                string strKeyInfo = strRow + item[2].ToString() + strRow + item[3].ToString() + "*";

                str[0] = str[0].ToString() + item[0].ToString() + "*";
                str[1] += "/UploadFiles/" + strPath + "/" + item[0].ToString() + "*";
                str[2] += strFilePath + strKeyInfo;

            }
            for (int i = 0; i < str.Length; i++)
            {
                string strValue = str[i].ToString();

                str[i] = strValue.Substring(0, strValue.Length - 1);
            }
            return str;
        }

        /// <summary>
        /// dataTable의 row sum을 계산하여 반환합니다.
        /// </summary>
        /// <param name="dt">계산할 dataTable</param>
        /// <param name="sumIdxSt">계산 할 datatable의 시작 column Index</param>
        /// <param name="sumIdxEd">계산 할 datatable의 종료 column Index</param>
        /// <param name="bRowSumYn">Row 총합계 계산 추가 여부</param>
        /// <param name="bColSumYn">Col 총합계 계산 추가 여부</param>
        /// <param name="addColNm">Total </param>
        /// <returns></returns>
        public static DataTable AddCoulumSum(DataTable dt, int sumIdxSt, int sumIdxEd, bool bRowSumYn, bool bColSumYn, string addColNm)
        {
            //테이블에 sum컬럼추가
            if (bRowSumYn)
            {
                dt.Columns.Add(addColNm, typeof(string));
            }
            //합계 구할 idx 값 구하기 
            int iSize = sumIdxEd - sumIdxSt + 1;

            //합계 저장 할 int 배열 선언 
            int[] iColSum = new int[iSize + 1];
            //
            foreach (DataRow dr in dt.Rows)
            {
                int iRowTotal = 0;
                int e = 0;
                for (int i = sumIdxSt; i <= sumIdxEd; i++)
                {
                    //column 토탈 
                    iColSum[e] += Convert.ToInt16(dr[i].ToString());
                    //row토탈 
                    iRowTotal += Convert.ToInt16(dr[i].ToString());
                    e++;
                }

                if (bRowSumYn)
                {
                    dr[addColNm] = iRowTotal;
                }
                iColSum[iSize] += iRowTotal;
            }

            //하단 Summary
            if (bColSumYn)
            {
                int iSum = sumIdxEd;
                if (bRowSumYn)
                {
                    iSum += 1;
                }

                DataRow drAdd = dt.NewRow();
                int j = 0;
                for (int i = sumIdxSt; i <= iSum; i++)
                {
                    drAdd[i] = iColSum[j];
                    j++;
                }
                dt.Rows.Add(drAdd);
            }
            return dt;
        }


        public static DataTable CreateDataTable(string[] columnNames)
        {
            DataTable dataTable = new DataTable();
            foreach (string columnName in columnNames)
            {
                dataTable.Columns.Add(columnName, typeof(System.String));
            }

            return dataTable;
        }

        /// <summary>
        /// 데이터 셋 압축 출기
        /// </summary>
        /// <param name="bytDs"></param>
        /// <returns></returns>
        public static DataSet DecompressDataSet(byte[] bytDs)
        {
            DataSet outDs = new DataSet();
            MemoryStream inMs = new MemoryStream(bytDs);
            inMs.Seek(0, 0); //스트림으로 가져오기

            //1. 압축객체 생성- 압축 풀기
            DeflateStream zipStream = new DeflateStream(inMs,
            CompressionMode.Decompress, true);
            byte[] outByt = ReadFullStream(zipStream);
            zipStream.Flush();
            zipStream.Close();
            MemoryStream outMs = new MemoryStream(outByt);
            outMs.Seek(0, 0); //2. 스트림으로 다시변환
            outDs.RemotingFormat = SerializationFormat.Binary;

            //3. 데이터셋으로 Deserialize
            BinaryFormatter bf = new BinaryFormatter();
            outDs = (DataSet)bf.Deserialize(outMs, null);
            return outDs;
        }

        /// <summary>
        /// 문자열로부터 인스턴스를 Deserialize 합니다.
        /// </summary>
        /// <param name="serializedString">Deserialize 할 문자열</param>
        /// <returns>Deserialize 된 인스턴스</returns>
        public static DataSet DeserializeFromString(string serializedString)
        {
            return DecompressDataSet(Convert.FromBase64String(serializedString));
        }

        /// <summary>
        /// 데이터 셋 압축
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static string CompressDataSet(DataSet ds)
        {
            ds.RemotingFormat = SerializationFormat.Binary;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, ds);
            byte[] inbyt = ms.ToArray();

            //2. 데이터 압축
            System.IO.MemoryStream objStream = new MemoryStream();
            System.IO.Compression.DeflateStream objZS = new System.IO.Compression.DeflateStream(objStream, System.IO.Compression.CompressionMode.Compress);
            objZS.Write(inbyt, 0, inbyt.Length);
            objZS.Flush();
            objZS.Close();
            return Convert.ToBase64String(objStream.ToArray());
        }

        /// <summary>
        /// 컬럼에 데이터 타입 넣기
        /// </summary>
        /// <param name="ctl"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static DataColumn GetColumn(string ctl, Type t)
        {
            DataColumn dc = new DataColumn(ctl, t);
            return dc;
        }

    }
}
