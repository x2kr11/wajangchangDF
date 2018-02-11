using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eHR.Framework;
using System.Text;
using eHR.Framework.Common;

namespace eHR.Framework
{
    public partial class Utils
    {
        public static List<GtFileUploadInfo> ParseUploadFileInfo(string src)
        {
            List<GtFileUploadInfo> lst = new List<GtFileUploadInfo>();
            if (src.Length > 0)
            {
                string[] arrFiles = src.Split('|');
                foreach (string file in arrFiles)
                {
                    string[] arrFile = file.Split(',');

                    GtFileUploadInfo gfui = new GtFileUploadInfo();
                    gfui.OriFileName = arrFile[0].Trim();
                    gfui.SaveAsFileName = arrFile[1].Trim();
                    gfui.FileSize = Convert.ToInt64(arrFile[2].Trim());
                    gfui.SubPath = arrFile[3].Trim();
                    gfui.CustomParam = arrFile[4].Trim();
                    gfui.JopTp = arrFile[5].Trim();

                    lst.Add(gfui);
                }
            }
            return lst;
        }

        public static List<GtFileUploadInfo> ParseDeleteFileInfo(string src)
        {
            List<GtFileUploadInfo> lst = new List<GtFileUploadInfo>();
            string[] arrFiles = src.Split('|');
            foreach (string file in arrFiles)
            {
                string[] arrFile = file.Split(',');

                GtFileUploadInfo gfui = new GtFileUploadInfo();
                gfui.FileId = arrFile[0].Trim();
                gfui.FileSeq = Convert.ToInt16(arrFile[1].Trim());
                lst.Add(gfui);
            }
            return lst;
        }
        /// <summary>
        /// 아이디 생성을 위한 시간을 받아옴
        /// </summary>
        public static string GenerateFileID()
        {
            return DateTime.Now.ToString("yyyyMMddHHmmssfffffff");
        }

        public static string GetFullSubFolder()
        {
            string strFileID = GenerateFileID();
            string strYY = strFileID.Substring(0, 4);
            string strMM = strFileID.Substring(4, 2);
            string strDD = strFileID.Substring(6, 2);

            return strYY + "_" + strMM + "_" + strDD + "_" + strFileID;
        }

        /// <summary>
        /// 파일 필터를 설정한다.
        /// </summary>
        /// <param name="filterKey"></param>
        /// <returns></returns>
        public static string GetFileFilterWithAppConfig(string filterKey)
        {
            string strResult = string.Empty;
            strResult = string.Format("FileFilter({0})|{0}",eHR.Framework.Common.Helper.GetAppConfig(filterKey));
            return strResult;
        }

    }
}