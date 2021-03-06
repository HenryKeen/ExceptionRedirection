﻿using System;
using System.Web.Routing;

namespace ExceptionRedirection
{
    public interface IExceptionRouteProvider
    {
        RouteValueDictionary GetRoute(Exception exception);
    }
}