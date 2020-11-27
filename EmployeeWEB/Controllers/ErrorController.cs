using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeWEB.Controllers
{
    public class ErrorController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public ViewResult AccessDenied()
        {
            return View("AccessDenied");
        }

        public ViewResult NotFound()
        {
            return View("NotFound");
        }

        public ViewResult HttpError()
        {
            return View("HttpError");
        }
    }
}