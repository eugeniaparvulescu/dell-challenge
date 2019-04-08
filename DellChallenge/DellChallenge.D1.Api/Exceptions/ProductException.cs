using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DellChallenge.D1.Api.Exceptions
{
    public class ProductException : Exception
    {
        public ProductException()
        {
        }

        public ProductException(string message) : base(message)
        {
        }

        public ProductException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProductException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
