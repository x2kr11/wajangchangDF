using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class RealTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GetTodayEpic();

            if (IsPostBack)
            {

            }           
        }

        protected void gvList_DataBound(object sender, EventArgs e)
        {

        }

        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;
            GetTodayEpic();
        }

        private void GetTodayEpic()
        {
            Biz wBiz = new Biz();
            DataSet ds = wBiz.GetTodayEpic();

            gvList.DataSource = ds;
            gvList.DataBind();
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            GetTodayEpic();
        }
    }
}