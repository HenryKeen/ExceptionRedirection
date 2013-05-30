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

        public void HandleException(HttpResponse responseBase, Exception exception)
        {
            var route = _exceptionRouteProvider.GetRoute(exception);

            if (route != null)
            {
                responseBase.RedirectToRoute(route);
                responseBase.End();
            }
        }
    }
}
