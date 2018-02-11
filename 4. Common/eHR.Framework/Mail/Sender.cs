using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eHR.Framework.Mail
{
    /// <summary>
    /// 메일을 보내는 사람 정보 입니다.
    /// </summary>
    public class Sender
    {
        private string _name;
        /// <summary>
        /// 보내는 사람 이름 입니다.
        /// </summary>
        public string Name 
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value; 
            }
        }

        private string _email;
        /// <summary>
        /// 보내는 사람 이메일 주소 입니다.
        /// </summary>
        public string Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }
    }
}
