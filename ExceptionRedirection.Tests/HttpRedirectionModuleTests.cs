using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Machine.Fakes;
using Machine.Specifications;

namespace ExceptionRedirection.Tests
{
    internal class When_handling_http_application_errors : WithSubject<HttpRedirectionModule>
    {
        static Exception _exception;

        Establish that = () =>
        {
            _exception = new Exception();

            Subject.ExceptionHandler = The<IExceptionHandler>();

            The<HttpContextBase>().WhenToldTo(x => x.Response)
                .Return(The<HttpResponseBase>());

            The<HttpContextBase>().WhenToldTo(x => x.Server)
                .Return(The<HttpServerUtilityBase>());

            The<HttpServerUtilityBase>().WhenToldTo(x => x.GetLastError())
                .Return(_exception);
        };

        Because of = () =>
            Subject.OnError(The<HttpContextBase>());

        It calls_the_exception_handler = () =>
            The<IExceptionHandler>()
                .WasToldTo(x => x.HandleException(The<HttpResponseBase>(), _exception));
    }

    internal class When_initializing_a_HttpRedirectionModule : WithSubject<HttpRedirectionModule>
    {
        Because of = () =>
            Subject.Init(An<HttpApplication>());

        It sets_the_default_exception_handler = () =>
            Subject.ExceptionHandler.ShouldBe(typeof(ExceptionHandler));
    }
}
