using System;

namespace Mvcify.Common.Exceptions
{
    public class ExceptionBase : ApplicationException
    {
        public ExceptionBase()
        {

        }

        public ExceptionBase(string message)
            : base(message)
        {

        }

        public ExceptionBase(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
