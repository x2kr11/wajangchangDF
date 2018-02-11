using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication2.Library
{
    public static class Database
    {
        static string dbConnect = "server = 118.37.235.181; uid=sku; pwd = tmzn; database = wajangchang";
        static SqlConnection connection;
        private static SqlConnection DatabaseConnection
        {
            get
            {
                if(connection == null)
                {
                    connection = new SqlConnection(dbConnect);
                    connection.Open();
                }

                return connection;
            }
        }

        public static void Close()
        {
            if (connection != null)
                connection.Close();
        }

        public static DataSet Query(string query)
        {
            DataSet ds = new DataSet();

            //sql 조회문
            //string sql = "Select id,serverId,characterId,characterName,adventureName,quildId From character_info";

            SqlDataAdapter ad = new SqlDataAdapter(query, DatabaseConnection);

            //조회한 결과를 dataset에 저장 후 리턴
            ad.Fill(ds);

            return ds;
        }

        public static string GetCharacterID(string CharacterName)
        {
            DataSet ds = Query("select characetId from character_info");
            if(ds.Tables.Contains("character_info") && ds.Tables["character_info"].Columns.Count > 0)
            {
                return ds.Tables["character_info"].Columns[0].ToString();
            }

            return null;
        }
    }
}