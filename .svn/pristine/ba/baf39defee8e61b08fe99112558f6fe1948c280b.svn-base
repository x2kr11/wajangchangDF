using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eHR.Framework.Mail
{
    /// <summary>
    /// 메일 받는 사람 정보를 설정 합니다.
    /// </summary>
    public class To
    {
        private Dictionary<string, string> _receivers = new Dictionary<string, string>();

        public To() { }

        /// <summary>
        /// 보내는 사람 정보를 추가 합니다.
        /// </summary>
        /// <param name="emailAccount"></param>
        /// <param name="receiverName"></param>
        public void Add(string email, string name)
        {
            if (!this._receivers.ContainsKey(email))
                this._receivers.Add(email, name);
            else
                this._receivers[email] = name;
        }

        /// <summary>
        /// 보내는 사람 정보를 모두 제거 합니다.
        /// </summary>
        public void Clear()
        {
            this._receivers.Clear();
        }

        /// <summary>
        /// 특정 이메일 계정의 보내는 사람 정보를 제거 합니다.
        /// </summary>
        /// <param name="emailAccount"></param>
        public void Remove(string email)
        {
            if (this._receivers.ContainsKey(email))
                this._receivers.Remove(email);
        }

        /// <summary>
        /// 받는 사람 정보를 반환 합니다.
        /// </summary>
        public Dictionary<string, string> Receivers
        {
            get
            {
                return this._receivers;
            }
        }
    }
}
