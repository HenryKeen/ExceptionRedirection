using System.Web;

namespace Exception
{
    public class HttpRedirectionModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}