using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionRedirection
{
    public interface IExceptionHandler
    {
        void HandleException(Exception exception);
    }
}
