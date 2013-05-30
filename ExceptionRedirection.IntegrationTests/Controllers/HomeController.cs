using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExceptionRedirection.IntegrationTests.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            throw new InvalidOperationException();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}
