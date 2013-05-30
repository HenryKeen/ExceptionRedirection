using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;
using Machine.Fakes;
using Machine.Specifications;

namespace ExceptionRedirection.Tests
{
    internal class When_getting_route_for_an_exception : WithSubject<ExceptionRouteProvider>
    {
        static Exception _exception;
        static RouteValueDictionary _expectedRoute;
        static RouteValueDictionary _result;

        Establish that = () =>
        {
            _exception = new Exception();
            _expectedRoute = new RouteValueDictionary();

            ExceptionRouteTable.Routes.Clear();
            ExceptionRouteTable.Routes.MapRoute<Exception>(_expectedRoute);
        };

        Because of = () =>
            _result = Subject.GetRoute(_exception);

        It returns_the_correct_route = () =>
            _result.ShouldEqual(_expectedRoute);
    }

    internal class When_getting_route_for_an_exception_with_multiple_mappings : WithSubject<ExceptionRouteProvider>
    {
        static Exception _exception;
        static RouteValueDictionary _expectedRoute;
        static RouteValueDictionary _result;

        Establish that = () =>
        {
            _exception = new InvalidOperationException();
            _expectedRoute = new RouteValueDictionary();

            ExceptionRouteTable.Routes.Clear();
            ExceptionRouteTable.Routes.MapRoute<InvalidOperationException>(_expectedRoute);
        };

        Because of = () =>
            _result = Subject.GetRoute(_exception);

        It returns_the_correct_route = () =>
            _result.ShouldEqual(_expectedRoute);
    }

    internal class When_getting_route_for_exception_that_is_not_mapped : WithSubject<ExceptionRouteProvider>
    {
        static Exception _exception;
        static RouteValueDictionary _expectedRoute;
        static RouteValueDictionary _result;

        Establish that = () =>
        {
            _exception = new Exception();
            _expectedRoute = null;

            ExceptionRouteTable.Routes.Clear();
            ExceptionRouteTable.Routes.MapRoute<InvalidOperationException>(_expectedRoute);
        };

        Because of = () =>
            _result = Subject.GetRoute(_exception);

        It returns_a_null_route = () =>
            _result.ShouldEqual(_expectedRoute);
    }
}
