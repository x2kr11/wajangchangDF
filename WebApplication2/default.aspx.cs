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
using System.Data.SqlClient;
using System.Collections;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        #region #전역변수정의
        protected int _totalCount;
        private string cacId;
        private string[] skuKai = { "스쿠님카이요","스쿠님게일요","독품은스쿠","류탄장전스쿠","귀신소환스쿠","루이즈스쿠","어둠사제스쿠","암흑기사스쿠","빙인파동스쿠","로드오브스쿠","소마스쿠"
                                    ,"심쿵스쿠","크림슨스쿠","절터는스쿠님","스쿠님용축요","스쿠님샷건요"};
        private string[] skuFiori = { "Fiori", "스쿠소마", "Scuderia", "꾸우우욱", "철컹철컹스쿠", "스쿠심판관", "스쿠홀릭", "스쿠비두", "스쿠넘약해양", "파동빙인스쿠", "메카넘약해양", "스쿠님카이좀", "스쿠딘", "LOUVER" };
        private string[] skuXian = { "시성채", "네이팜스쿠", "그라시아스쿠", "스택오버", "디멘션스쿠", "기사님축이요", "축복앤스쿠", "Publisher", "GlobalCool", "후이아이", "DeadSet", "참조주소" };
        private string[] skuLunch = { "글로리페이스", "불타는호박", "일기당백", "금삼겹", "긴그림자", "정식요원", "점프공사류탄", "버프밀땅녀", "이단심판스쿠", "각명관", "중년샷건간지", "장로드래곤", "봉사하는무녀", "총검쓰는스쿠", "버프는에반젤" };
        private string _strFlag;
        //private string[] strCacId = new string[];
        private ArrayList arrayCacID = new ArrayList();
        private int _skuCount = 1;
        string dbConnect = "server = 118.37.235.62; uid=sku2; pwd = tmzn; database = wajangchang";
        //d9ba8ef7552d6165e6e8cf6388967571 = 독품은스쿠
        #endregion

        #region #이벤트 정의
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlCondition.SelectedIndex = 1;
                txtName.Text = "스쿠";
                GetContentLog();
            }
            _strFlag = hidFlag.Value;
            //Flag에 따라 분기.
            switch (_strFlag)
            {
                case "Sku":
                    arrayCacID = GetCacIdArray(skuKai);
                    break;
                case "Fiori":
                    arrayCacID = GetCacIdArray(skuFiori);
                    break;
                case "Xian":
                    arrayCacID = GetCacIdArray(skuXian);
                    break;
                case "Lunch":
                    arrayCacID = GetCacIdArray(skuLunch);
                    break;
                default:
                    break;
            }
        }
        protected void gvList_DataBound(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ddlCondition.Value == "cacNm")
            {
                GetCacId();
                GetItemList();
                GetBoosterList();
            }
            else
                GetContentLog();
        }

        protected void btnGetDate_Click(object sender, EventArgs e)
        {
            //GetItemList(arrayCacID);
            //GetBoosterList(arrayCacID);
            switch (_strFlag)
            {
                case "Sku":
                    txtName.Text = "스쿠";
                    break;
                case "Fiori":
                    txtName.Text = "스쿠데리아";                    
                    break;
                case "Xian":
                    txtName.Text = "Developer";                   
                    break;
                case "Lunch":
                    txtName.Text = "ForTheGlory";                    
                    break;
                default:
                    break;
            }
            ddlCondition.SelectedIndex = 1;
            GetContentLog();
        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            if (ddlCondition.Value == "cacNm")
            {
                GetCacId();
                GetItemList();
                GetBoosterList();
            }            
            else
                GetContentLog();
            //GetItemList(arrayCacID);
        }
        protected void gvList2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList2.PageIndex = e.NewPageIndex;
            if (ddlCondition.Value == "cacNm")
            {
                GetCacId();
                GetItemList();
                GetBoosterList();
            }
            else
                GetContentLog();
        }       
        #endregion

        #region #UI 메소드
        private JObject GetDfJson(string url)
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

        private ArrayList GetCacIdArray(string[] cacNM)
        {
            ArrayList arrayID = new ArrayList();
            for (int i = 0; i < cacNM.Length; i++)
            {
                string url = "https://api.neople.co.kr/df/servers/cain/characters?characterName=" + cacNM[i] + "&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
                JObject dfJson = GetDfJson(url);
                JToken dfJson2 = JToken.FromObject(dfJson["rows"]);
                arrayID.Add(dfJson2[0]["characterId"].ToString());
            }
            return arrayID;
        }

        private void GetCacId()
        {
            string url = "https://api.neople.co.kr/df/servers/cain/characters?characterName=" + txtName.Text + "&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
            JObject dfJson = GetDfJson(url);
            JToken dfJson2 = JToken.FromObject(dfJson["rows"]);
            cacId = dfJson2[0]["characterId"].ToString();
        }

        private void GetBoosterList()
        {
            string url = "https://api.neople.co.kr/df/servers/cain/characters/" + cacId + "/timeline?limit=10&code=501&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
            JObject dfJson = GetDfJson(url);
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

        private void GetBoosterList(ArrayList cacId)
        {
            DataTable dt = new DataTable();
            DataRow dr = null;

            dt.Columns.Add(new DataColumn("characterName", typeof(string)));
            dt.Columns.Add(new DataColumn("name", typeof(string)));
            dt.Columns.Add(new DataColumn("date", typeof(string)));
            dt.Columns.Add(new DataColumn("itemId", typeof(string)));
            dt.Columns.Add(new DataColumn("itemName", typeof(string)));
            dt.Columns.Add(new DataColumn("booster", typeof(string)));

            for (int i = 0; i < cacId.Count; i++)
            {
                string url = "https://api.neople.co.kr/df/servers/cain/characters/" + cacId[i].ToString() + "/timeline?limit=10&code=501&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
                JObject dfJson = GetDfJson(url);
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
        private void GetItemList()
        {
            string url = "https://api.neople.co.kr/df/servers/cain/characters/" + cacId + "/timeline?limit=100&code=505&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
            JObject dfJson = GetDfJson(url);
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

            for (int i = 0; i < length; i++, _skuCount++)
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

        private void GetItemList(ArrayList cacID)
        {
            //DataTable dt = new DataTable();
            //DataRow dr = null;

            //dt.Columns.Add(new DataColumn("characterName", typeof(string)));
            //dt.Columns.Add(new DataColumn("itemId", typeof(string)));
            //dt.Columns.Add(new DataColumn("itemName", typeof(string)));
            //dt.Columns.Add(new DataColumn("date", typeof(string)));
            //dt.Columns.Add(new DataColumn("channelName", typeof(string)));
            //dt.Columns.Add(new DataColumn("channelNo", typeof(string)));
            //dt.Columns.Add(new DataColumn("dungeonName", typeof(string)));

            //for (int i = 0; i < cacID.Count; i++)
            //{
            //    string url = "https://api.neople.co.kr/df/servers/cain/characters/" + cacID[i].ToString() + "/timeline?limit=10&code=505&apikey=7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
            //    JObject dfJson = GetDfJson(url);
            //    JToken dfJson2 = JToken.FromObject(dfJson["timeline"]["rows"]);
            //    JArray items = (JArray)dfJson["timeline"]["rows"];
            //    int length = items.Count;

            //    for (int j = 0; j < length; j++)
            //    {
            //        dr = dt.NewRow();
            //        dr.ItemArray = new Object[] {dfJson["characterName"],dfJson2[j]["data"]["itemId"],dfJson2[j]["data"]["itemName"], dfJson2[j]["date"],dfJson2[j]["data"]["channelName"],dfJson2[j]["data"]["channelNo"]
            //                                 ,dfJson2[j]["data"]["dungeonName"]};
            //        dt.Rows.Add(dr);
            //    }
            //}
            //dt.DefaultView.Sort = "date DESC";
            //gvCount.Text = dt.Rows.Count.ToString();
            //gvList.DataSource = dt;
            //gvList.DataBind();           
            GetContentLog();
        }

        /// <summary>
        /// 모험단 지옥파티 아이템 리스트
        /// </summary>
        private void GetContentLog()
        {      
            Hashtable ht = new Hashtable();
            ht.Add("adventure_NM", txtName.Text);
            ht.Add("girinCheck", "N");

            Biz wDac = new Biz();
            DataSet ds = wDac.GetContentLog(ht);
            
            gvCount.Text = ds.Tables[0].Rows.Count.ToString();
            gvList.DataSource = ds.Tables[0];
            gvList.DataBind();

            gvCount2.Text = ds.Tables[1].Rows.Count.ToString();
            gvList2.DataSource = ds.Tables[1];
            gvList2.DataBind();
        }
        #endregion
    }
}