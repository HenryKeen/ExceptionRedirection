using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ExceptionRedirection
{
    public interface IExceptionHandler
    {
        void HandleException(HttpResponse response, Exception exception);
    }
}
