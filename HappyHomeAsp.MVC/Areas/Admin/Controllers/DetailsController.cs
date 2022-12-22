using HappyHomeAsp.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Areas.Admin.Controllers
{
    public class DetailsController : Controller
    {
        // GET: Admin/Details
        public ActionResult Index(int id)
        {
            ManageData manage = new ManageData();
            ArrayList products = new ArrayList();
            products = manage.selectAllProduct2();
            Product result = null;
            foreach (Product p in products )
            {
                if (p.Product_id.Equals(id))
                {
                    result= p;
                }
            }
            return View(result);
        }
    }
}