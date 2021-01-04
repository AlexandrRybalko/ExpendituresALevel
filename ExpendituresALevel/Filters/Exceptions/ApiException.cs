using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpendituresALevel.Filters.Exceptions
{
    public class ApiException : Exception
    {
        public ErrorCodes ErrorCode { get; set; }

        public ApiException(string message, ErrorCodes errorCode = ErrorCodes.General) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}