using System;
using System.Collections.Generic;
using System.Web.Routing;

namespace ExceptionRedirection
{
    public class ExceptionRouteCollection : Dictionary<Type, RouteValueDictionary>
    {
        public void MapRoute<T>(RouteValueDictionary route)
        {
            if(!ContainsKey(typeof(T)))
                Add(typeof(T), route);
        }

        public void MapRoute<T>(object route)
        {
            MapRoute<T>(new RouteValueDictionary(route));
        }
    }
}