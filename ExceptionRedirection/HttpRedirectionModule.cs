using System;
using System.Diagnostics;
using System.Web;

namespace ExceptionRedirection
{
    public class HttpRedirectionModule : IHttpModule
    {
        HttpApplication _context;

        public IExceptionHandler ExceptionHandler { get; set; }

        public void Init(HttpApplication context)
        {
            _context = context;

            ExceptionHandler = new ExceptionHandler(_context.Response, new ExceptionRouteProvider());

            context.Error += OnError;
        }

        public void OnError(object sender, System.EventArgs e)
        {
            ExceptionHandler.HandleException(GetLastError());
        }

        public virtual Exception GetLastError()
        {
            return _context.Server.GetLastError();
        }

        public void Dispose()
        {
            
        }
    }
}