using HappyHomeAsp.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class ProductDetailPageController : Controller
    {
        // GET: ProductDetailPage
        public ActionResult Index(int id)
        {
            ManageData manage = new ManageData();
            Product product = manage.getProductFromId(id);
            return View(product);
        }
    }
}