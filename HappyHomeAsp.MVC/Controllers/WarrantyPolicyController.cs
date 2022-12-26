using HappyHomeAsp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class WarrantyPolicyController : Controller
    {
        // GET: WarrantyPolicy
        public ActionResult Index()
        {
            //listNameType cua Layout
            ManageData manage = new ManageData();
            List<ProductType> listNameType = manage.getNameProductTypes();
            ViewBag.listType = listNameType;
            return View();
        }
    }
}