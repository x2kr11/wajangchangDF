using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eHR.Framework
{
    /// <summary>
    /// 업로드된 파일 정보를 관리 합니다.
    /// </summary>
    public class GtFileUploadInfo
    {
        private int _fileSeq = 0;
        /// <summary>
        /// 업로드한 파일 원본 이름 입니다.
        /// </summary>
        public string OriFileName { get; set; }

        /// <summary>
        /// 실제 저장된 파일 이름 입니다.
        /// </summary>
        public string SaveAsFileName { get; set; }

        /// <summary>
        /// 업로드된 파일 크기 입니다.
        /// </summary>
        public double FileSize { get; set; }

        /// <summary>
        /// 파일의 seq
        /// </summary>
        public int FileSeq 
        {  
            get
            {
                return _fileSeq;
            }
            set
            {
                _fileSeq = value;
            }
        }

        public string FileId { get; set; }

        public string SubPath{ get; set; }

        public string CustomParam { get; set; }

        public string JopTp { get; set; }

    }
}