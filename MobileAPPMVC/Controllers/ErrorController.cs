using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobileAPPMVC.Controllers
{
    public class ErrorController : Controller
    {
        [Route("Error")]
        public IActionResult Index()
        {
            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            string errorMessage = exceptionHandlerFeature.Error.Message;
            string exceptionPath = exceptionHandlerFeature.Path;
            string exceptionTrace = exceptionHandlerFeature.Error.StackTrace;

            ViewBag.ErrorMessage = errorMessage;

            return View("Error");
        }
    }
}
