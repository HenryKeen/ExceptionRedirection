﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Routing;
using Machine.Fakes;
using Machine.Specifications;

namespace ExceptionRedirection.Tests
{
    internal class When_handling_an_exception_with_a_route : WithSubject<ExceptionHandler>
    {
        static RouteValueDictionary _route;
        static Exception _exception;

        Establish that = () =>
        {
            Subject = new ExceptionHandler(The<MockResponse>(), The<IExceptionRouteProvider>());

            _exception = new InvalidOperationException();

            _route = new RouteValueDictionary();
            The<IExceptionRouteProvider>().WhenToldTo(x => x.GetRoute(_exception))
                .Return(_route);
        };

        Because of = () =>
            Subject.HandleException(_exception);

        It redirects_to_the_exception_route = () =>
            The<MockResponse>().WasToldTo(x => x.RedirectToRoute(_route));
    }

    internal class When_handling_an_exception_without_a_route : WithSubject<ExceptionHandler>
    {
        static RouteValueDictionary _route;
        static Exception _exception;

        Establish that = () =>
        {
            Subject = new ExceptionHandler(The<MockResponse>(), The<IExceptionRouteProvider>());

            _exception = new InvalidOperationException();

            _route = null;

            The<IExceptionRouteProvider>().WhenToldTo(x => x.GetRoute(_exception))
                .Return(_route);
        };

        Because of = () =>
            Subject.HandleException(_exception);

        It does_not_redirect = () =>
            The<MockResponse>().WasNotToldTo(x => x.RedirectToRoute(_route));
    }

    /// <summary>
    /// Mock of HttpResponseBase because HttpResponseBase constructor is protected so cannot be created by Moq directly
    /// </summary>
    public class MockResponse : HttpResponseBase
    {
    }
}
