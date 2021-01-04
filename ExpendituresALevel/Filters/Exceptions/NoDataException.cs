using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpendituresALevel.Filters.Exceptions
{
    public class NoDataException : ApiException
    {
        public NoDataException(string message) : base(message, ErrorCodes.DataNotExist)
        {

        }
    }
}