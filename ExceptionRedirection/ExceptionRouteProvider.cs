using System;
using System.Web.Routing;

namespace ExceptionRedirection
{
    public class ExceptionRouteProvider : IExceptionRouteProvider
    {
        public RouteValueDictionary GetRoute(Exception exception)
        {
            throw new NotImplementedException();
        }
    }
}