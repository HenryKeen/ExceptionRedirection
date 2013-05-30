using System;
using System.Diagnostics;
using System.Web;

namespace ExceptionRedirection
{
    public class HttpRedirectionModule : IHttpModule
    {
        public IExceptionHandler ExceptionHandler { get; set; }

        public void Init(HttpApplication context)
        {
            ExceptionHandler = new ExceptionHandler(new ExceptionRouteProvider());

            context.Error += (sender, e) => OnError(new HttpContextWrapper(((HttpApplication)sender).Context));
        }

        public void OnError(HttpContextBase context)
        {
            ExceptionHandler.HandleException(context.Response, GetLastError(context));
        }

        Exception GetLastError(HttpContextBase context)
        {
            return context.Server.GetLastError();
        }

        public void Dispose()
        {
            
        }
    }
}