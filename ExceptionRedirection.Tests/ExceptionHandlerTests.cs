using System;
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
    internal class ExceptionHandlerTests : WithSubject<ExceptionHandler>
    {
        static RouteValueDictionary _route;
        static Exception _exception;

        Establish that = () =>
        {
            _exception = new InvalidOperationException();

            _route = new RouteValueDictionary();
            The<IExceptionRouteProvider>().WhenToldTo(x => x.GetRoute(_exception))
                .Return(_route);
        };

        Because of = () =>
            Subject.HandleException(The<HttpResponseBase>(), _exception);

        It redirects_to_the_exception_route = () =>
            The<HttpResponseBase>().WasToldTo(x => x.RedirectToRoute(_route));

        It ends_the_response = () =>
            The<HttpResponseBase>().WasToldTo(x => x.End());
    }

    internal class When_handling_an_exception_without_a_route : WithSubject<ExceptionHandler>
    {
        static RouteValueDictionary _route;
        static Exception _exception;

        Establish that = () =>
        {
            _exception = new InvalidOperationException();

            _route = null;

            The<IExceptionRouteProvider>().WhenToldTo(x => x.GetRoute(_exception))
                .Return(_route);
        };

        Because of = () =>
            Subject.HandleException(The<HttpResponseBase>(), _exception);

        It does_not_redirect = () =>
            The<HttpResponseBase>().WasNotToldTo(x => x.RedirectToRoute(_route));

        It does_not_end_the_response = () =>
            The<HttpResponseBase>().WasNotToldTo(x => x.End());
    }
}
