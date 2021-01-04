using ExpendituresALevel.Controllers;
using ExpendituresALevel.Filters.Exceptions;
using log4net;
using System;
using System.Net;
using System.Web.Mvc;

namespace ExpendituresALevel.Filters
{
    public class MyExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        //public override void OnException(HttpActionExecutedContext actionExecutedContext)
        //{
        //    base.OnException(actionExecutedContext);

        //    var httpStatusCode = HttpStatusCode.InternalServerError;

        //    if (actionExecutedContext.Exception is CategoryNotExistException)
        //        httpStatusCode = HttpStatusCode.NotFound;

        //    if (actionExecutedContext.Exception is NoDataException)
        //        httpStatusCode = HttpStatusCode.NotFound;

        //    if (actionExecutedContext.Exception is NullReferenceException)
        //        httpStatusCode = HttpStatusCode.BadRequest;

        //    actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(httpStatusCode, actionExecutedContext.Exception.Message);
        //}

        public void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is CategoryNotExistException)
            {
                ILog logger = LogManager.GetLogger("CategoryLogger");
                logger.Error(filterContext.Exception.ToString());
            }
            else if (filterContext.Exception is Exception)
            {
                ILog logger = LogManager.GetLogger("Logger");
                logger.Error(filterContext.Exception.ToString());
            }
        }
    }
}