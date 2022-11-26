using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Areas.Admin.Controllers
{
    public class Error404Controller : Controller
    {
        // GET: Admin/Error404
        public ActionResult Index()
        {
            return View();
        }
    }
}