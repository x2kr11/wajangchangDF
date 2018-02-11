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
        /// <summary>
        /// 바이트를 배열로 변환
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static byte[] ReadFullStream(Stream stream)
        {
            //스트림을 Byte 배열로 변환
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        /// <summary>
        /// 작성자 : 고동남
        /// 내  용 : GT FileUpload에서 저장된 파일의 파일명을 호출 합니다.
        /// </summary>
        /// <param name="gtUploadFileInfo"></param>
        /// <returns></returns>
        public static string GetFileFullNameWithGtUploadFileInfo(string gtUploadFileInfo)
        {
            //Add 된 파일 경로를 가져온다.
            string[] strFileNameWithPath = gtUploadFileInfo.Split((char)1);
            //Add 된 파일 확장명을 가져온다.
            string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath[1]);
            //Add 된 파일 명을 가져온다.
            string strFileName = System.IO.Path.GetFileName(strFileNameWithPath[1]);

            string strFileFullName = System.IO.Path.Combine(@System.Web.HttpContext.Current.Server.MapPath(Helper.GetAppConfig("ExcelUploadPathFromOnlyData")), strFileName);

            return strFileFullName;
        }
    }
}
