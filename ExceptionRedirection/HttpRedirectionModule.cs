using System;
using System.Diagnostics;
using System.Web;

namespace ExceptionRedirection
{
    public class HttpRedirectionModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.Error += Error;
        }

        void Error(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            
        }
    }
}