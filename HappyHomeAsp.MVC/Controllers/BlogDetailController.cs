using HappyHomeAsp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class BlogDetailController : Controller
    {
        // GET: BlogDetail
        public ActionResult Index(int id)
        {
            ManageData manage = new ManageData();
            Article ar = manage.getArticleFromId(id);
            return View(ar);
        }
    }
}