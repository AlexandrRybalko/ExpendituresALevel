using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpendituresALevel.Filters.Exceptions
{
    public class CategoryNotExistException : ApiException
    {
        public CategoryNotExistException(string message) : base(message, ErrorCodes.CategoryNotFound)
        {

        }
    }
}