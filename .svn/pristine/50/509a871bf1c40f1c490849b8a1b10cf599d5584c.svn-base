using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eHR.Framework.Mail
{
    public class AttachFile
    {
        private Dictionary<string, string> _attachFiles = new Dictionary<string, string>();

        public AttachFile() { }

        /// <summary>
        /// 첨부파일 정보를 추가 합니다.
        /// </summary>
        /// <param name="emailAccount"></param>
        /// <param name="receiverName"></param>
        public void Add(string fileFullPath)
        {
            if (!this._attachFiles.ContainsKey(fileFullPath))
                this._attachFiles.Add(fileFullPath, fileFullPath);
            else
                this._attachFiles[fileFullPath] = fileFullPath;
        }

        /// <summary>
        /// 첨부파일 정보를 모두 제거 합니다.
        /// </summary>
        public void Clear()
        {
            this._attachFiles.Clear();
        }

        /// <summary>
        /// 특정 첨부파일 정보를 제거 합니다.
        /// </summary>
        /// <param name="emailAccount"></param>
        public void Remove(string fileFullPath)
        {
            if (this._attachFiles.ContainsKey(fileFullPath))
                this._attachFiles.Remove(fileFullPath);
        }

        /// <summary>
        /// Attach된 파일 수를 반환 합니다.
        /// </summary>
        public int Count
        {
            get 
            { 
                return this._attachFiles.Count;
            }
        }

        /// <summary>
        /// 첨부 파일 정보를 반환 합니다.
        /// </summary>
        public string[] Files
        {
            get
            {
                int i = 0;
                string[] arr = new string[this._attachFiles.Count];

                foreach (KeyValuePair<String, String> info in this._attachFiles)
                {
                    arr[i] = info.Value;
                    i += 1;
                }

                return arr;
            }
        }
    }
}
