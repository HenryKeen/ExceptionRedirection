using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Exception;
using Machine.Fakes;
using Machine.Specifications;

namespace ExceptionRedirection.Tests
{
    internal class HttpRedirectionModuleTests : WithSubject<HttpRedirectionModule>
    {
        Establish that = () =>
            {
                
            };

        Because of = () =>
            Subject.Init(The<HttpApplication>());


    }
}
