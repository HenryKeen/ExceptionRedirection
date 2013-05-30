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
        readonly IExceptionRouteProvider _exceptionRouteProvider;

        public ExceptionHandler(IExceptionRouteProvider exceptionRouteProvider)
        {
            _exceptionRouteProvider = exceptionRouteProvider;
        }

        public void HandleException(HttpResponseBase response, Exception exception)
        {
            var route = _exceptionRouteProvider.GetRoute(exception);

            if (route != null)
            {
                response.RedirectToRoute(route);
                response.End();
            }
        }
    }
}
