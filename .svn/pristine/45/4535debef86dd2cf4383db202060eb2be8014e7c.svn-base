using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System;
using Skcc;

namespace eHR.Framework
{
    /// <summary>
    /// The exception that is thrown when a non-fatal application error occurs.
    /// </summary>
    public class ShAppException : SkccException
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public ShAppException()
            : base()
        {
        }

        public ShAppException(int code)
            : base(code)
        {
        }

        /// <summary>
        /// Initializes with a specified error message.
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public ShAppException(string message)
            : base(message)
        {
        }

        public ShAppException(string message, int code)
            : base(message, code)
        {
        }

        /// <summary>
        /// Initializes with a specified error 
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.
        /// </param>
        /// <param name="exception">The exception that is the cause of the current exception. 
        /// If the innerException parameter is not a null reference, the current exception 
        /// is raised in a catch block that handles the inner exception.
        /// </param>
        public ShAppException(string message, Exception exception) :
            base(message, exception)
        {
        }

        public ShAppException(string message, int code, Exception exception) :
            base(message, code, exception)
        {
        }

        /// <summary>
        /// Initializes with serialized data.
        /// </summary>
        /// <param name="info">The object that holds the serialized object data.</param>
        /// <param name="context">The contextual information about the source or destination.
        /// </param>
        protected ShAppException(SerializationInfo info, StreamingContext context) :
            base(info, context)
        {
        }


    }
}
