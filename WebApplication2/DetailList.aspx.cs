﻿using Newtonsoft.Json.Linq;
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

                ddlGirin.Items.FindByText("스쿠").Selected = true;
            }
        }

        /// <summary>
        /// 아이템 리스트 조회
        /// </summary>
        private void GetContentLog()
        {
            Hashtable ht = new Hashtable();
            ht.Add("adventure_NM", ddlGirin.Value);
            ht.Add("girinCheck", "Y");

            Biz wBiz = new Biz();
            DataSet ds = wBiz.GetContentLog(ht);

            gvGirinList.DataSource = ds;
            gvGirinList.DataBind();
        }
        #endregion
    }
}