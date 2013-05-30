using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionRedirection
{
    public static class ExceptionRouteTable
    {
        public static ExceptionRouteCollection Routes { get; private set; }

        static ExceptionRouteTable()
        {
            Routes = new ExceptionRouteCollection();
        }
    }
}
