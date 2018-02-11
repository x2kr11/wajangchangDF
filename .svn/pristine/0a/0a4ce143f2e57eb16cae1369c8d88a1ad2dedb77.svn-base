using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using eHR.Framework;


namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region #전역변수정의
        protected int _totalCount;
        private string cacId;
        private string[] skuKai = { "스쿠님카이요","스쿠님게일요","독품은스쿠","류탄장전스쿠","귀신소환스쿠","루이즈스쿠","어둠사제스쿠","암흑기사스쿠","빙인파동스쿠","로드오브스쿠","소마스쿠"
                                    ,"심쿵스쿠","크림슨스쿠","절터는스쿠님","스쿠님용축요","스쿠님샷건요"};
        private string[] skuKaiID = new string[16];
        private int _skuCount = 1;
        //d9ba8ef7552d6165e6e8cf6388967571 = 독품은스쿠
        #endregion

        #region #이벤트 정의
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtName.Text = "독품은스쿠";
                getCacId();
                getItemList();
                getBoosterList();
            }

        }
        protected void gvList_DataBound(object sender, EventArgs e)
        {
            
        }

        protected void btnSku_Click(object sender, EventArgs e)
        {
            getCacIdArray();
            getItemList(skuKaiID);
            getBoosterList(skuKaiID);
        }


        protected void btnGetDate_Click(object sender, EventArgs e)
        {
            getCacId();
            getItemList();
            getBoosterList();
        }
        #endregion
        #region #UI 메소드
        private JObject getDfJson(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/json";
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream recvStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(recvStream, Encoding.GetEncoding("utf-8"));
            string json = readStream.ReadToEnd();
            JObject Json = JObject.Parse(json);
            return Json;
        }

        private void getCacIdArray()
        {
            for (int i = 0; i < skuKai.Length; i++)
            {
                string url = "https://api.neople.co.kr/df/servers/cain/characters?characterName=" + skuKai[i] + "&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
                JObject dfJson = getDfJson(url);
                JToken dfJson2 = JToken.FromObject(dfJson["rows"]);
                skuKaiID[i] = dfJson2[0]["characterId"].ToString();
            }
        }

        private void getCacId()
        {
            string url = "https://api.neople.co.kr/df/servers/cain/characters?characterName=" + txtName.Text + "&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
            JObject dfJson = getDfJson(url);
            JToken dfJson2 = JToken.FromObject(dfJson["rows"]);
            cacId = dfJson2[0]["characterId"].ToString();
        }

        private void getBoosterList()
        {
            string url = "https://api.neople.co.kr/df/servers/cain/characters/" + cacId + "/timeline?limit=10&code=501&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
            JObject dfJson = getDfJson(url);
            JToken dfJson2 = JToken.FromObject(dfJson["timeline"]["rows"]);
            JArray items = (JArray)dfJson["timeline"]["rows"];
            int length = items.Count;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("characterName", typeof(string)));
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("date", typeof(string)));
            dt.Columns.Add(new DataColumn("itemId", typeof(string)));
            dt.Columns.Add(new DataColumn("itemName", typeof(string)));
            dt.Columns.Add(new DataColumn("booster", typeof(string)));

            for (int i = 0; i < length; i++)
            {
                dr = dt.NewRow();
                dr.ItemArray = new Object[] { dfJson["characterName"], dfJson2[i]["name"], dfJson2[i]["date"], dfJson2[i]["data"]["itemId"], dfJson2[i]["data"]["itemName"], dfJson2[i]["data"]["booster"] };
                dt.Rows.Add(dr);
            }

            gvCount2.Text = length.ToString();
            gvList2.DataSource = dt;
            gvList2.DataBind();
        }


        private void getBoosterList(string[] cacId)
        {            
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("characterName", typeof(string)));
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("date", typeof(string)));
            dt.Columns.Add(new DataColumn("itemId", typeof(string)));
            dt.Columns.Add(new DataColumn("itemName", typeof(string)));
            dt.Columns.Add(new DataColumn("booster", typeof(string)));

            for (int i = 0; i < cacId.Length; i++)
            {
                string url = "https://api.neople.co.kr/df/servers/cain/characters/" + cacId[i] + "/timeline?limit=10&code=501&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
                JObject dfJson = getDfJson(url);
                JToken dfJson2 = JToken.FromObject(dfJson["timeline"]["rows"]);
                JArray items = (JArray)dfJson["timeline"]["rows"];              
                int length = items.Count;

                for (int j = 0; j < length; j++)
                {
                    dr = dt.NewRow();
                    dr.ItemArray = new Object[] { dfJson["characterName"], dfJson2[j]["name"], dfJson2[j]["date"], dfJson2[j]["data"]["itemId"], dfJson2[j]["data"]["itemName"], dfJson2[j]["data"]["booster"] };
                    dt.Rows.Add(dr);
                }
            }
            dt.DefaultView.Sort = "date DESC";
            gvCount2.Text = dt.Rows.Count.ToString();
            gvList2.DataSource = dt;
            gvList2.DataBind();
        }

        private void getItemList()
        {
            string url = "https://api.neople.co.kr/df/servers/cain/characters/" + cacId + "/timeline?limit=10&code=505&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
            JObject dfJson = getDfJson(url);
            JToken dfJson2 = JToken.FromObject(dfJson["timeline"]["rows"]);
            JArray items = (JArray)dfJson["timeline"]["rows"];
            int length = items.Count;

            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            DataRow dr = null;
           
            dt.Columns.Add(new DataColumn("characterName", typeof(string)));
            dt.Columns.Add(new DataColumn("itemId", typeof(string)));
            dt.Columns.Add(new DataColumn("itemName", typeof(string)));
            dt.Columns.Add(new DataColumn("date", typeof(string)));
            dt.Columns.Add(new DataColumn("channelName", typeof(string)));
            dt.Columns.Add(new DataColumn("channelNo", typeof(string)));
            dt.Columns.Add(new DataColumn("dungeonName", typeof(string)));

            for (int i = 0; i < length; i++,_skuCount++)
            {
                dr = dt.NewRow();
                dr.ItemArray = new Object[] {dfJson["characterName"],dfJson2[i]["data"]["itemId"],dfJson2[i]["data"]["itemName"], dfJson2[i]["date"],dfJson2[i]["data"]["channelName"],dfJson2[i]["data"]["channelNo"]
                                             ,dfJson2[i]["data"]["dungeonName"]};
                dt.Rows.Add(dr);
            }
            
            gvCount.Text = length.ToString();
            gvList.DataSource = dt;
            gvList.DataBind();
        }

        private void getItemList(string[] cacId)
        {            
            DataTable dt = new DataTable();
            DataRow dr = null;
            
            dt.Columns.Add(new DataColumn("characterName", typeof(string)));
            dt.Columns.Add(new DataColumn("itemId", typeof(string)));
            dt.Columns.Add(new DataColumn("itemName", typeof(string)));
            dt.Columns.Add(new DataColumn("date", typeof(string)));
            dt.Columns.Add(new DataColumn("channelName", typeof(string)));
            dt.Columns.Add(new DataColumn("channelNo", typeof(string)));
            dt.Columns.Add(new DataColumn("dungeonName", typeof(string)));


            for (int i = 0; i < cacId.Length; i++)
            {
                string url = "https://api.neople.co.kr/df/servers/cain/characters/" + cacId[i] + "/timeline?limit=10&code=505&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
                JObject dfJson = getDfJson(url);
                JToken dfJson2 = JToken.FromObject(dfJson["timeline"]["rows"]);
                JArray items = (JArray)dfJson["timeline"]["rows"];
                int length = items.Count;
                
                for (int j = 0; j < length; j++)
                {
                    dr = dt.NewRow();
                    dr.ItemArray = new Object[] {dfJson["characterName"],dfJson2[j]["data"]["itemId"],dfJson2[j]["data"]["itemName"], dfJson2[j]["date"],dfJson2[j]["data"]["channelName"],dfJson2[j]["data"]["channelNo"]
                                             ,dfJson2[j]["data"]["dungeonName"]};
                    dt.Rows.Add(dr);
                }
            }
            dt.DefaultView.Sort = "date DESC";
            gvCount.Text = dt.Rows.Count.ToString();
            gvList.DataSource = dt;
            gvList.DataBind();
        }
        #endregion

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            getCacIdArray();
            getItemList(skuKaiID);
        }
    }
}