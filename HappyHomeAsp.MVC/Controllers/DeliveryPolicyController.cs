using HappyHomeAsp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class DeliveryPolicyController : Controller
    {
        // GET: DeliveryPolicy
        public ActionResult Index()
        {
            ManageData manage = new ManageData();
            List<ProductType> listNameType = manage.getNameProductTypes();
            ViewBag.listType = listNameType;
            return View();
        }
    }
}