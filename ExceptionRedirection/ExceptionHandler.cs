using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ExceptionRedirection
{
    public class ExceptionHandler : IExceptionHandler
    {
        readonly HttpResponseBase _responseBase;
        readonly IExceptionRouteProvider _exceptionRouteProvider;

        public ExceptionHandler(HttpResponseBase responseBase, IExceptionRouteProvider exceptionRouteProvider)
        {
            _responseBase = responseBase;
            _exceptionRouteProvider = exceptionRouteProvider;
        }

        public void HandleException(Exception exception)
        {
            var route = _exceptionRouteProvider.GetRoute(exception);

            _responseBase.RedirectToRoute(route);
        }
    }
}
