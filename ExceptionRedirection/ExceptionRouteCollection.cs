using System;
using System.Collections.Generic;
using System.Web.Routing;

namespace ExceptionRedirection
{
    public class ExceptionRouteCollection : Dictionary<Type, RouteValueDictionary>
    {
        public void MapRoute<T>(RouteValueDictionary route)
        {
            Add(typeof(T), route);
        }

        public void MapRoute<T>(object route)
        {
            Add(typeof(T), new RouteValueDictionary(route));
        }
    }
}