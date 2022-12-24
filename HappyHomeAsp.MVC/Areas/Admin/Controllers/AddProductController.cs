using HappyHomeAsp.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Areas.Admin.Controllers
{
    public class AddProductController : Controller
    {
       
        // GET: Admin/AddProduct

        public ActionResult Index()
        {



            Product products = new Product();
            ViewBag.Product = products;

            return View();
        }
        [HttpPost]
        public ActionResult addProduct(FormCollection collection)
        {
          
            var name = collection["product_name"];
            var type = collection["product_type"];
            ManageProduct manage = new ManageProduct();
            manage.addProduct(name, type);
            return RedirectToAction("Index");
        }
        
    }
}