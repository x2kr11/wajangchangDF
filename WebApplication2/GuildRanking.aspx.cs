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
        private interface TimelineQuery
        {
            string ToInsertQuery();
        }

        private struct TimelineHellEpic : TimelineQuery
        {
            string CharacterId;
            string ItemId;
            string ItemName;
            string ChannelName;
            Int16 ChannelNo;
            string dungeonName;
            string Date;

            public TimelineHellEpic(string CharacterId_, JToken JsonData)
            {
                CharacterId = CharacterId_;
                ItemId = JsonData["itemId"].ToString();
                ItemName = JsonData["itemName"].ToString();
                ChannelName = JsonData["channelName"].ToString();
                ChannelNo = Int16.Parse(JsonData["channelNo"].ToString());
                dungeonName = JsonData["dungeonName"].ToString();
                Date = JsonData["date"].ToString();
            }

            public string ToInsertQuery()
            {
                System.Text.StringBuilder InsertQueryBuilder = new System.Text.StringBuilder();
                InsertQueryBuilder.AppendFormat("('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}')", CharacterId, ItemId, ItemName, ChannelName, ChannelNo, dungeonName, Date);
                return InsertQueryBuilder.ToString();
            }
        }

        private struct TimelineSealedLock : TimelineQuery
        {
            string CharacterId;
            string ItemId;
            string ItemName;
            bool Booster;
            string Date;

            public TimelineSealedLock(string CharacterId_, JToken JsonData)
            {
                CharacterId = CharacterId_;
                ItemId = JsonData["itemId"].ToString();
                ItemName = JsonData["itemName"].ToString();
                Booster = JsonData["booster"].ToString() != "false";
                Date = JsonData["date"].ToString();
            }

            public string ToInsertQuery()
            {
                System.Text.StringBuilder InsertQueryBuilder = new System.Text.StringBuilder();
                InsertQueryBuilder.AppendFormat("('{0}', '{1}', '{2}', {3}, '{4}')", CharacterId, ItemId, ItemName, Booster ? 1 : 0, Date);
                return InsertQueryBuilder.ToString();
            }
        }

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
            //TempFunction();
            RefreshCharacterIds();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //content_log 지우기전 잠시 동기화 호출 함수
        private void TempFunction()
        {
            DataRowCollection Rows = Library.Database.Query("select * from content_log").Tables[0].Rows;
            List<string> HellValues = new List<string>();
            List<string> SealedLockValues = new List<string>();
            foreach (DataRow Row in Rows)
            {
                int Code = Int32.Parse(Row["code"].ToString());
                if (Code == 505)
                {
                    JObject DataJson = JObject.Parse(Row["data"].ToString());
                    HellValues.Add(string.Format("('{0}', '{1}', '{2}', '{3}', {4}, '{5}', '{6}')", Row["characterId"], DataJson["itemId"], DataJson["itemName"], DataJson["channelName"], DataJson["channelNo"], DataJson["dungeonName"], Convert.ToDateTime(Row["date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                }
                else if (Code == 501)
                {
                    JObject DataJson = JObject.Parse(Row["data"].ToString());


                    SealedLockValues.Add(string.Format("('{0}', '{1}', '{2}', {3}, '{4}')", Row["characterId"], DataJson["itemId"], DataJson["itemName"], DataJson["booster"].ToString() == "false" ? 0 : 1, Convert.ToDateTime(Row["date"].ToString()).ToString("yyyy-MM-dd HH:mm:ss")));
                }

                if (HellValues.Count >= 1000)
                {
                    string ResultValues = HellValues.Aggregate(((i, j) => i + "," + j));
                    //string ResultQuery = "insert into timeline_hell_epic(characterId, itemId, itemName, channelName, channelNo, dungeonName, date) Values " + ResultValues;
                    Library.Database.Query("insert into timeline_hell_epic(characterId, itemId, itemName, channelName, channelNo, dungeonName, date) Values " + ResultValues);
                    HellValues.Clear();
                }

                if (SealedLockValues.Count >= 1000)
                {
                    string ResultValues = SealedLockValues.Aggregate(((i, j) => i + "," + j));
                    Library.Database.Query("insert into timeline_sealedlock(characterId, itemId, itemName, booster, date) Values " + ResultValues);
                    SealedLockValues.Clear();
                }
            }

            if (HellValues.Count > 0)
            {
                string ResultValues = HellValues.Aggregate(((i, j) => i + "," + j));
                Library.Database.Query("insert into timeline_hell_epic(characterId, itemId, itemName, channelName, channelNo, dungeonName, date) Values " + ResultValues);
                HellValues.Clear();
            }

            if (SealedLockValues.Count > 0)
            {
                string ResultValues = SealedLockValues.Aggregate(((i, j) => i + "," + j));
                Library.Database.Query("insert into timeline_sealedlock(characterId, itemId, itemName, booster, date) Values " + ResultValues);
                SealedLockValues.Clear();
            }
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
        protected void CachingCharacter(string CharacterName)
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
            DataSet ReservedDatas = Library.Database.Query("select characterId, isNew from reserved_refresh_characterIds");
            DataRowCollection ReservedIdsRows = ReservedDatas.Tables[0].Rows;
            if (ReservedIdsRows.Count == 0) //예약된 characterid들이 없으면 다시 갱신할수 있도록 모든 characterid insert
            {
                DataSet CharacterInfoDatas = Library.Database.Query("select characterId from character_info");
                DataTable CharacterInfoTable = CharacterInfoDatas.Tables[0];

                if (CharacterInfoTable.Rows.Count > 0)
                {
                    DataRowCollection ContentLogRows = Library.Database.Query("select characterId from content_log group by characterId").Tables[0].Rows;
                    Dictionary<string, bool> CharacterIdCaching = new Dictionary<string, bool>();
                    foreach(DataRow ContentLogRow in ContentLogRows)
                    {
                        CharacterIdCaching.Add(ContentLogRow["characterId"].ToString(), true);
                    }

                    System.Text.StringBuilder InsertQueryBuilder = new System.Text.StringBuilder();
                    InsertQueryBuilder.Append("insert into reserved_refresh_characterIds(characterId, isNew) values ");
                    bool IsFirst = true;
                    foreach (DataRow Row in CharacterInfoTable.Rows)
                    {
                        if (!IsFirst)
                            InsertQueryBuilder.Append(',');
                        string CharacterId = Row["characterId"].ToString();
                        bool IsNew = !CharacterIdCaching.ContainsKey(CharacterId);
                        InsertQueryBuilder.AppendFormat("('{0}', {1})", CharacterId, IsNew ? 1 : 0);
                        IsFirst = false;
                    }

                    Library.Database.Query(InsertQueryBuilder.ToString());
                }
            }
            else
            {
                List<string> ReservedCachingIds = new List<string>();
                foreach (DataRow ReservedIdsRow in ReservedIdsRows)
                {
                    bool OutIsNew = true;
                    if(bool.TryParse(ReservedIdsRow["isNew"].ToString(), out OutIsNew))
                    {
                        if(!OutIsNew)
                        {
                            ReservedCachingIds.Add(ReservedIdsRow["characterId"].ToString());
                        }
                    }
                }

                if(ReservedCachingIds.Count == 0)
                {
                    ReservedCachingIds.Add(ReservedIdsRows[0]["characterId"].ToString());
                }

                string DeleteCharacterIds = '\''+ ReservedCachingIds.Aggregate(((i, j) => i + "\',\'" + j)) + '\'';

                System.Text.StringBuilder DeleteQueryBuilder = new System.Text.StringBuilder();
                DeleteQueryBuilder.AppendFormat("delete from reserved_refresh_characterIds where characterId in ({0})", DeleteCharacterIds);
                Library.Database.Query(DeleteQueryBuilder.ToString());

                foreach(string CharacterId in ReservedCachingIds)
                {
                    string Url = Library.Network.GetTimelineUrl(CharacterId);
                    InsertTimelineUrl(CharacterId, Url);
                }
                
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
            List<string> TimeLineHellEpicValues = new List<string>();
            List<string> TimeLineSealedLockValues = new List<string>();
            while (!string.IsNullOrEmpty(TimelineUrl))
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
                        TimeLineSealedLockValues.Add(new TimelineSealedLock(CharacterId, TimelineRowData).ToInsertQuery());
                        TimeLineHellEpicValues.Add(new TimelineHellEpic(CharacterId, TimelineRowData).ToInsertQuery());
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

            if(TimeLineHellEpicValues.Count > 0)
            {
                string ResultValues = TimeLineHellEpicValues.Aggregate(((i, j) => i + "," + j));
                Library.Database.Query("insert into timeline_hell_epic(characterId, itemId, itemName, channelName, channelNo, dungeonName, date) values " + ResultValues);
            }

            if (TimeLineSealedLockValues.Count > 0)
            {
                string ResultValues = TimeLineSealedLockValues.Aggregate(((i, j) => i + "," + j));
                Library.Database.Query("insert into timeline_hell_epic(characterId, itemId, itemName, booster, date) values " + ResultValues);
            }

            



        }
    }
}