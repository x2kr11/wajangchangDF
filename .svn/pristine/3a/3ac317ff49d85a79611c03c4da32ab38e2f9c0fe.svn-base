using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;
using System.IO;
using System.Configuration;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

namespace eHR.Framework.Common
{
    public static partial class Helper
    {
        private static string EVENT_LOG_NAME = "HCCR";

        private static string SYSTEM_NAME = "CRNET";

        /// <summary>
        /// 이벤트 로그에 기록 합니다. <br/>
        /// 이벤트로그 디렉토리는 HINET, 이벤트로그 이름은 CR 입니다.
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="contents"></param>
        public static void WriteEventLog(System.Diagnostics.EventLogEntryType logType, string contents)
        {
            WriteEventLog(SYSTEM_NAME, EVENT_LOG_NAME, logType, contents);
        }
        /// <summary>
        /// 이벤트 로그에 기록 합니다.
        /// </summary>
        /// <param name="eventLog"></param>
        /// <param name="eventLogSource"></param>
        /// <param name="logType"></param>
        /// <param name="contents"></param>
        public static void WriteEventLog(string eventLog, string eventLogSource, System.Diagnostics.EventLogEntryType logType, string contents)
        {
            using (System.Diagnostics.EventLog eLog = new System.Diagnostics.EventLog(eventLog))
            {
                if (!(System.Diagnostics.EventLog.SourceExists(eventLogSource, Environment.MachineName)))
                    System.Diagnostics.EventLog.CreateEventSource(eventLogSource, eventLog);

                eLog.Source = eventLogSource;
                eLog.WriteEntry(contents, logType);
            }
        }


    }
}
