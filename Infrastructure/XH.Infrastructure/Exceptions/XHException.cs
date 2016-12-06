using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace XH.Infrastructure.Exceptions
{
    [Serializable]
    public class XHException : Exception
    {
        /// <summary>
        /// Creates a new <see cref="XHException"/> object.
        /// </summary>
        public XHException()
        {

        }

        /// <summary>
        /// Creates a new <see cref="XHException"/> object.
        /// </summary>
        public XHException(SerializationInfo serializationInfo, StreamingContext context)
            : base(serializationInfo, context)
        {

        }

        /// <summary>
        /// Creates a new <see cref="XHException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        public XHException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Creates a new <see cref="XHException"/> object.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Inner exception</param>
        public XHException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
