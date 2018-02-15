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
    public partial class InsertID : System.Web.UI.Page
    {
        #region 상수정의
        #endregion

        #region 전역변수 정의
        #endregion

        #region 이벤트 정의
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SetInsertCacID(txtName.Text);
                GetCacIdList();
            }
            catch(Exception ex)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "error", "<script>alert('아이디를 확인해주세요.');</script>");
            }
        }

        protected void gvCacList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCacList.PageIndex = e.NewPageIndex;
            GetCacIdList();
        }
        #endregion

        #region UI 메소드
        private void SetInsertCacID(String cacNM)
        {
            string CharacterID = Library.Network.GetCharacterID(cacNM);

            if (string.IsNullOrEmpty(CharacterID))
                return;

            JObject JsonData = Library.Network.GetCharacterInfo(CharacterID);
            if (JsonData == null)
                return;         

            string AdventureName = JsonData["adventureName"].ToString();
            string GuildId = JsonData["guildId"].ToString();


            System.Text.StringBuilder QueryBuilder = new System.Text.StringBuilder();
            QueryBuilder.AppendFormat("update character_info set serverId='{0}', characterId='{1}', characterName='{2}', adventureName='{3}', guildId='{4}' where characterId='{5}' IF @@ROWCOUNT=0", Library.Network.SERVER_NAME, CharacterID, cacNM, AdventureName, GuildId, CharacterID);
            QueryBuilder.AppendFormat("insert into character_info(serverId, characterId, characterName, adventureName, guildId) values('{0}','{1}','{2}','{3}','{4}')", Library.Network.SERVER_NAME, CharacterID, cacNM, AdventureName, GuildId);
            Library.Database.Query(QueryBuilder.ToString());
        }
        private void GetCacIdList()
        {
            Hashtable ht = new Hashtable();
            ht.Add("cac_Id", txtName.Text);

            Biz wBiz = new Biz();
            DataSet ds = new DataSet();

            ds = wBiz.GetCacIdList(ht);

            gvCacList.DataSource = ds;
            gvCacList.DataBind();
        }
        #endregion
    }
}