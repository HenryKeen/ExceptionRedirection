using System;
using System.Collections.Generic;
using System.Web.Routing;

namespace ExceptionRedirection
{
    public class ExceptionRouteProvider : IExceptionRouteProvider
    {
        public RouteValueDictionary GetRoute(Exception exception)
        {
            Type typeOfException = exception.GetType();

            if (ExceptionRouteTable.Routes.ContainsKey(typeOfException))
                return ExceptionRouteTable.Routes[typeOfException];

            return null;
        }
    }
}