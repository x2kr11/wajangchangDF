using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class GuildRanking : System.Web.UI.Page
    {
        /// <summary>
        /// 특정 시간 단위로 한번씩 호출되어 character_info 테이블의 character_id들을 모두 읽어와
        /// 던파 api에 타임라인 호출(request 요청이 많아지기에 던파 api가 요청 제한이 어떻게 규약되어있는지 확인후 문제 없게 코딩)
        /// 타임라인의 한번에 불러오는 limit제한이 있기에 해당 라인을 넘어갔을시 nexturl을 호출하여 문제 없이 기록되도록 작업
        /// </summary>
        private void UpdateContentLog()
        {

        }

        /// <summary>
        /// 이번주 Content 데이터 읽어오기
        /// </summary>
        private void LoadContentLogForWeek()
        {
            //DateTime.Now.DayOfWeek;
            //Library.Database.Query("select * from content_log where date >");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * 페이지 로드시에 백엔드와 프론트엔드의 처리 필요(UpdateContentLog, LoadContentLogForWeek)
             * 유저가 보는 페이지는 LoadContentLogForWeek(프론트엔드)
             * 데이터의 업데이트 UpdateContentLog(백엔드)
             */
        }
    }
}