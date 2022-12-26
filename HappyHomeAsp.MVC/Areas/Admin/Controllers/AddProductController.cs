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
        public ActionResult Index2(FormCollection collection)
        {
            string id = Request.Form["id"];
            int product_id = Int32.Parse(id.Trim());
            string name = Request.Form["name"];
            string pri = Request.Form["price"];
            int price = Int32.Parse(pri.Trim());
            string pc = Request.Form["price_sell"];
            int price_sell = Int32.Parse(pc.Trim());
            string info = Request.Form["info"];
            string code = Request.Form["code"];
            string brand = Request.Form["brand"];
            string color = Request.Form["color"];
            string size = Request.Form["size"];
            string attribute = Request.Form["attribute"] ;
            string st = Request.Form["id"];
            int status = Int32.Parse(st.Trim());
            string product_type = Request.Form["type"];
            string product_insurance = Request.Form["insurance"];
            
            Product add = new Product(product_id,  name,  price,  price_sell,  info,  code,  brand,  color,  size,  attribute,  status,  product_type,  product_insurance);
            ManageProduct manage = new ManageProduct();
            manage.addProduct(add);

            return  RedirectToAction("Index", "DataProduct");
        }

    }
}