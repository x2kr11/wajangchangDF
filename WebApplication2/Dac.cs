using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Dac
    {
        #region 전역변수
        string ConnectionString = ConfigurationManager.ConnectionStrings["wajangchang"].ConnectionString;
        public SqlConnection dbConn;        
        #endregion

        #region 프로시저 / SQL
        protected readonly string UP_CMM_CONTENT_L = "UP_CMM_Content_L";
        protected readonly string UP_CMM_CACID_L = "UP_CMM_CacID_L";
        protected readonly string UP_CMM_ADVENTURE_L = "UP_CMM_Adventure_L";
        protected readonly string UP_CMM_HELLEPCI_L = "UP_CMM_HellEpic_L";       
        #endregion

        public SqlConnection getConn()
        {
            dbConn = new SqlConnection(ConnectionString);
            return dbConn;
        }

        /// <summary>
        /// ContentLog 조회
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet GetContentLog(Hashtable ht)
        {
            SqlCommand cmd = new SqlCommand(UP_CMM_CONTENT_L,getConn());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adventure_NM", ht["adventure_NM"]);
            cmd.Parameters.AddWithValue("@girinCheck", ht["girinCheck"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);            
            dbConn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "select");
            dbConn.Close();
            return ds;
        }

        /// <summary>
        /// 캐릭터 리스트 조회
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet GetCacIdList(Hashtable ht)
        {
            SqlCommand cmd = new SqlCommand(UP_CMM_CACID_L, getConn());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cac_Id", ht["cac_Id"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "select");
            dbConn.Close();
            return ds;
        }

        /// <summary>
        /// 모험단 조회
        /// </summary>
        /// <returns></returns>
        public DataSet GetAdventureList()
        {
            SqlCommand cmd = new SqlCommand(UP_CMM_ADVENTURE_L, getConn());
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "select");
            dbConn.Close();
            return ds;
        }

        /// <summary>
        /// 모험단 별 에픽 리스트 조회
        /// </summary>
        /// <param name="ht"></param>
        /// <returns></returns>
        public DataSet GetHellEpicList(Hashtable ht)
        {
            SqlCommand cmd = new SqlCommand(UP_CMM_HELLEPCI_L, getConn());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adventure_NM", ht["adventure_NM"]);
            cmd.Parameters.AddWithValue("@item_NM", ht["item_NM"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            dbConn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "select");
            dbConn.Close();
            return ds;
        }
    }
}