using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System;
using Skcc;

namespace eHR.Framework
{
    /// <summary>
    /// The exception that is thrown when a non-fatal application error occurs.
    /// </summary>
    public class ShException : Exception
    {
        public ShException(string message, int code)
        {
            this.ErrMessage = message;
            this.ErrCode = code;
        }

        private string _message = "";
        public string ErrMessage
        {
            get { return _message; }
            set { _message = value; }
        }

        private int _code = -1;
        public int ErrCode
        {
            get { return _code; }
            set { _code = value; }
        }

    }
}

