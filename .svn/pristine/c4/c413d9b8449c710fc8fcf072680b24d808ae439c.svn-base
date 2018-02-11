using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eHR.Framework.Base
{
    public class ShParam
    {
        public ShParam() { }
        /// <summary>
        /// value값을 암호화 합니다.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public ShParam(string name, object value)
        {
            this.Name = name;
            this.Value = value;
        }

        /// <summary>
        /// encYN값이 true이면 암호화 합니다.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="encYN"></param>
        public ShParam(string name, object value, bool encYN) 
        {
            this.Name = name;
            this.Value = value;    
            this.EncYN = encYN;
        }

        private object _value;
        private string _name;
        private bool _encYN = true;

        public object Value
        {
            get { return _value; }
            set { _value = value; }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public bool EncYN
        {
            get { return _encYN; }
            set { _encYN = value; }
        }

        public void Add(string name, object value, bool encYn)
        {
            this.Name = name;
            this.Value = value;
            this.EncYN = encYn;
        }
    }
}
