using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using ExceptionRedirection;
using Machine.Fakes;
using Machine.Specifications;

namespace ExceptionRedirection.Tests
{
    internal class When_handling_errors_in_the_http_module : WithSubject<HttpRedirectionModule>
    {
        static InvalidOperationException _exception;

        Establish that = () =>
        {
            Subject.Init(The<HttpApplication>());

            Subject.ExceptionHandler = The<IExceptionHandler>();
        };

        Because of = () =>
            Subject.OnError(new object(), EventArgs.Empty);

        It handles_the_exception = () =>
            The<IExceptionHandler>().WasToldTo(x => x.HandleException(Param.IsAny<Exception>()));
    }
}
