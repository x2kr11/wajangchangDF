using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class DetailList : System.Web.UI.Page
    {
        #region 전역변수 정의
        private string _strFilter = "itemName = '물소리의 기억' OR itemName = '샛별의 숨소리' OR itemName= '반짝임의 향기' OR " +
                                    "itemName = '파르스의 황금잔' OR itemName = '바벨로니아의 상징' OR itemName = '로제타스톤'";
        #endregion

        #region 이벤트 정의
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAdventureList();

                GetContentLog();
            }
            else
                GetContentLog();

        }
        protected void btnAdventure_Click(object sender, EventArgs e)
        {

        }

        protected void gvGirinList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGirinList.PageIndex = e.NewPageIndex;
            GetContentLog();
        }
        #endregion

        #region UI 이벤트 정의
        /// <summary>
        /// ddl 바인딩
        /// </summary>
        private void GetAdventureList()
        {
            ListItem item;
            
            Biz wBiz = new Biz();
            DataSet ds = wBiz.GetAdventureList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow[] drAdventureList = ds.Tables[0].Select();

                for(int i = 0; i < drAdventureList.Length; i++)
                {
                    item = new ListItem();
                    item.Value = drAdventureList[i]["adventureName"].ToString();
                    item.Text = drAdventureList[i]["adventureName"].ToString();
                    ddlGirin.Items.Add(item);
                }
                item = new ListItem();
                item.Value = "ALL";
                item.Text = "ALL";
                item.Selected = true;

                ddlGirin.Items.Insert(0, item);           
            }
        }

        /// <summary>
        /// 아이템 리스트 조회
        /// </summary>
        private void GetContentLog()
        {
            Hashtable ht = new Hashtable();
            ht.Add("adventure_NM", ddlGirin.Value);

            Biz wBiz = new Biz();
            DataSet ds = wBiz.GetContentLog(ht);

            DataTable dt = ds.Tables[0];

            dt.Columns.Add(new DataColumn("itemId", typeof(string)));
            dt.Columns.Add(new DataColumn("itemName", typeof(string)));
            dt.Columns.Add(new DataColumn("channelName", typeof(string)));
            dt.Columns.Add(new DataColumn("channelNo", typeof(string)));
            dt.Columns.Add(new DataColumn("dungeonName", typeof(string)));

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                JToken dfJson = JToken.Parse(dt.Rows[i]["data"].ToString());
                dt.Rows[i]["itemId"] = dfJson["itemId"];
                dt.Rows[i]["itemName"] = dfJson["itemName"];
                dt.Rows[i]["channelName"] = dfJson["channelName"];
                dt.Rows[i]["channelNo"] = dfJson["channelNo"];
                dt.Rows[i]["dungeonName"] = dfJson["dungeonName"];
            }
            DataRow[] drTemp;
            DataTable dtTemp = dt.Clone();
            drTemp = dt.Select(_strFilter);

            for(int i= 0; i<drTemp.Length; i++)
            {
                dtTemp.Rows.Add(drTemp[i].ItemArray);
            }
            dtTemp.DefaultView.Sort = "date desc";
            
            gvGirinList.DataSource = dtTemp;
            gvGirinList.DataBind();
        }
        #endregion
    }
}