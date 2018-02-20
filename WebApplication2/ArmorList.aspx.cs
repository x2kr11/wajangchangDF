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
    public partial class ArmorList : System.Web.UI.Page
    {
        #region 전역변수 정의
        #endregion

        #region 이벤트 정의
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //ddl 바인딩
                GetAdventureList();
                //GridView 바인딩
                GetArmorEpciList();
            }
            else
                GetArmorEpciList();
        }

        protected void btnAdventure_Click(object sender, EventArgs e)
        {

        }

        protected void gvArmorList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvArmorList.PageIndex = e.NewPageIndex;
            GetArmorEpciList();
        }
        #endregion

        #region UI 이벤트 정의
        private void GetAdventureList()
        {
            ListItem item;

            Biz wBiz = new Biz();
            DataSet ds = wBiz.GetAdventureList();

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow[] drAdventureList = ds.Tables[0].Select();

                for (int i = 0; i < drAdventureList.Length; i++)
                {
                    item = new ListItem();
                    item.Value = drAdventureList[i]["adventureName"].ToString();
                    item.Text = drAdventureList[i]["adventureName"].ToString();
                    ddlGirin.Items.Add(item);
                }

                ddlGirin.Items.FindByText("스쿠").Selected = true;
            }
        }
        private void GetArmorEpciList()
        {
            Hashtable ht = new Hashtable();
            ht.Add("adventure_NM", ddlGirin.Value);
            ht.Add("item_NM", ddlArmor.Value);

            Biz wBiz = new Biz();
            DataSet ds = wBiz.GetHellEpicList(ht);

            gvArmorList.DataSource = ds;
            gvArmorList.DataBind();

            gvCount.Text = ds.Tables[1].Rows[0][0].ToString();
        }

        #endregion
    }
}