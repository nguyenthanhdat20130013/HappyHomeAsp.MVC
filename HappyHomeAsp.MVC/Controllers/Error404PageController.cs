using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class Error404PageController : Controller
    {
        // GET: Error404Page
        public ActionResult Index()
        {
            return View();
        }
    }
}