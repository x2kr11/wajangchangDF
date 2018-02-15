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
        protected readonly string UP_CMM_CACID_L = "Up_CMM_CacID_L";
        #endregion

        public SqlConnection getConn()
        {
            dbConn = new SqlConnection(ConnectionString);
            return dbConn;
        }


        public DataSet GetContentLog(Hashtable ht)
        {
            SqlCommand cmd = new SqlCommand(UP_CMM_CONTENT_L,getConn());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@adventure_NM", ht["adventure_NM"]);
            SqlDataAdapter da = new SqlDataAdapter(cmd);            
            dbConn.Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "select");
            dbConn.Close();
            return ds;
        }

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
    }
}