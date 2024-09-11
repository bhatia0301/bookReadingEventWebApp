using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExceptions.Exceptions
{
    public class CustomCommentException : Exception
    {
        public CustomCommentException() { }
        public CustomCommentException(string message) : base(message){ }
        public CustomCommentException(string message, Exception inner) : base(message, inner) { }

        public CustomCommentException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info,context)
        {
            
        }

    }
}
