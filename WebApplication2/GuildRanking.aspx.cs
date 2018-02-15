using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json.Linq;
using System.Data;

namespace WebApplication2
{
    public partial class GuildRanking : System.Web.UI.Page
    {
        private struct TimelineData
        {
            string CharacterId;
            Int16 Code;
            string Name;
            string Data;
            string Date;

            public TimelineData(string CharacterId_, JToken JsonData)
            {
                CharacterId = CharacterId_;
                Code = Int16.Parse(JsonData["code"].ToString());
                Name = JsonData["name"].ToString();
                Data = JsonData["data"].ToString();
                Date = JsonData["date"].ToString();
            }

            public DateTime GetDateTime()
            {
                return Convert.ToDateTime(Date);
            }

            public string ToInsertQuery()
            {
                System.Text.StringBuilder InsertQueryBuilder = new System.Text.StringBuilder();
                InsertQueryBuilder.AppendFormat("('{0}', {1}, '{2}', '{3}', '{4}')", CharacterId, Code, Name, Data, Date);
                return InsertQueryBuilder.ToString();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            RefreshCharacterIds();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //한국 던파 현재 시간기준 초기화된 날짜 및 시간 (목요일 새벽6시)
        private DateTime GetStandardResetDate()
        {
            DateTime NowDateTime = DateTime.Now;
            DateTime ResetStandardDateTime = NowDateTime.AddHours(-6);
            Int32 DecreaseDay = (((Int32)ResetStandardDateTime.DayOfWeek + 3) % 7);
            TimeSpan DecreaseTimeSpan = new TimeSpan(DecreaseDay, 0, NowDateTime.Minute, NowDateTime.Second);
            NowDateTime -= DecreaseTimeSpan;
            NowDateTime = NowDateTime.AddHours(6 - NowDateTime.Hour);

            return NowDateTime;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CachingCharacter(this.TextBox1.Text);
           
        }

        //검색한 캐릭터에 대해 정보가 없으면 data insert 처리(log를 수집하기 위함)
        private void CachingCharacter(string CharacterName)
        {
            string CharacterID = Library.Network.GetCharacterID(CharacterName);

            if (string.IsNullOrEmpty(CharacterID))
                return;

            JObject JsonData = Library.Network.GetCharacterInfo(CharacterID);
            if (JsonData == null)
                return;
            this.TextBox2.Text = JsonData.ToString();

            string AdventureName = JsonData["adventureName"].ToString();
            string GuildId = JsonData["guildId"].ToString();


            System.Text.StringBuilder QueryBuilder = new System.Text.StringBuilder();
            QueryBuilder.AppendFormat("update character_info set serverId='{0}', characterId='{1}', characterName='{2}', adventureName='{3}', guildId='{4}' where characterId='{5}' IF @@ROWCOUNT=0", Library.Network.SERVER_NAME, CharacterID, CharacterName, AdventureName, GuildId, CharacterID);
            QueryBuilder.AppendFormat("insert into character_info(serverId, characterId, characterName, adventureName, guildId) values('{0}','{1}','{2}','{3}','{4}')", Library.Network.SERVER_NAME, CharacterID, CharacterName, AdventureName, GuildId);
            Library.Database.Query(QueryBuilder.ToString());
        }

        //로그를 갱신할 캐릭터 id들을 예약하는 처리
        private void RefreshCharacterIds()
        {
            DataSet ReservedDatas = Library.Database.Query("select characterId from reserved_refresh_characterIds");
            DataTable ReservedIdsTable = ReservedDatas.Tables[0];
            if (ReservedIdsTable.Rows.Count == 0) //예약된 characterid들이 없으면 다시 갱신할수 있도록 모든 characterid insert
            {
                DataSet CharacterInfoDatas = Library.Database.Query("select characterId from character_info");
                DataTable CharacterInfoTable = CharacterInfoDatas.Tables[0];

                if (CharacterInfoTable.Rows.Count > 0)
                {
                    System.Text.StringBuilder InsertQueryBuilder = new System.Text.StringBuilder();
                    InsertQueryBuilder.Append("insert into reserved_refresh_characterIds(characterId) values ");
                    bool IsFirst = true;
                    foreach (DataRow Row in CharacterInfoTable.Rows)
                    {
                        if (!IsFirst)
                            InsertQueryBuilder.Append(',');
                        InsertQueryBuilder.AppendFormat("('{0}')", Row["characterId"].ToString());
                        IsFirst = false;
                    }

                    Library.Database.Query(InsertQueryBuilder.ToString());
                }
            }
            else
            {
                
                DataRow Row = ReservedIdsTable.Rows[0];
                string CharacterId = Row["characterId"].ToString();
                string Url = Library.Network.GetTimelineUrl(CharacterId);

                System.Text.StringBuilder DeleteQueryBuilder = new System.Text.StringBuilder();
                DeleteQueryBuilder.AppendFormat("delete from reserved_refresh_characterIds where characterId='{0}'", CharacterId);
                Library.Database.Query(DeleteQueryBuilder.ToString());

                InsertTimelineUrl(CharacterId, Url);
            }

            
        }



        private void InsertTimelineUrl(string CharacterId, string TimelineUrl)
        {
            
            DateTime LastDateTime = DateTime.MinValue;

            {
                System.Text.StringBuilder SelectQueryBuilder = new System.Text.StringBuilder();
                SelectQueryBuilder.AppendFormat("select top 1 date from content_log where characterId = '{0}' order by date desc", CharacterId);
                DataSet LastDateTimeDatas = Library.Database.Query(SelectQueryBuilder.ToString());
                if(LastDateTimeDatas.Tables[0].Rows.Count > 0)
                {
                    
                    LastDateTime = Convert.ToDateTime(LastDateTimeDatas.Tables[0].Rows[0]["date"].ToString());
                }
            }
            List<TimelineData> TimeLineDatas = new List<TimelineData>();
            while(!string.IsNullOrEmpty(TimelineUrl))
            {
                JObject TimelineJsonData = Library.Network.GetDFJsonResult(TimelineUrl);

                JToken TimelineUrlToken = TimelineJsonData["timeline"];
                TimelineUrl = TimelineUrlToken["nextUrl"].ToString();
                if (!string.IsNullOrEmpty(TimelineUrl) && !TimelineUrl.Contains("apikey="))  //api 똑바로 안만들어놔서 예외처리
                {
                    TimelineUrl += ("&apikey=" + Library.Network.API_KEY);
                }

                JArray TimelineRows = (JArray)TimelineUrlToken["rows"];
                if (TimelineRows != null)
                {
                    foreach (JToken TimelineRowData in TimelineRows)
                    {
                        TimelineData LogData = new TimelineData(CharacterId, TimelineRowData);

                        if (LastDateTime >= LogData.GetDateTime())
                        {
                            TimelineUrl = null;
                            break;
                        }
                            

                        TimeLineDatas.Add(LogData);
                        //InsertQueryBuilder.AppendFormat("('{0}', {1}, '{2}', '{3}', '{4}')", CharacterId, TimelineRowData["code"], TimelineRowData["name"], TimelineRowData["data"], TimelineRowData["date"]);
                    }
                }
            }

            if(TimeLineDatas.Count > 0)
            {
                System.Text.StringBuilder InsertQueryBuilder = new System.Text.StringBuilder();
                InsertQueryBuilder.Append("insert into content_log(characterId, code, name, data, date) values ");
                //과거 데이터부터 insert
                for (int i = TimeLineDatas.Count - 1; i >= 0; i--)
                {
                    if(i < TimeLineDatas.Count - 1)
                    {
                        InsertQueryBuilder.Append(',');
                    }
                    InsertQueryBuilder.Append(TimeLineDatas[i].ToInsertQuery());
                }

                Library.Database.Query(InsertQueryBuilder.ToString());
            }
            



        }
    }
}