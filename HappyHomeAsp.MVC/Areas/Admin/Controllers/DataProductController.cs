using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using HappyHomeAsp.MVC.Controllers;
using HappyHomeAsp.MVC.Models;
using MySql.Data.MySqlClient;

namespace HappyHomeAsp.MVC.Areas.Admin.Controllers
{
    public class DataProductController : Controller
    {
       
        ArrayList product = new ArrayList();
        // GET: Admin/DataProduct
        public ActionResult Index()
        {
            ManageData manage = new ManageData();
            
            product = manage.selectAllProduct2();

  


            return View(product);
        }
       public ActionResult Edit(int id)
        {
            ManageData manage = new ManageData();
            List<ProductType> listNameType = manage.getNameProductTypes();
            ViewBag.listType = listNameType;
           
            Product p = new Product();
            p = manage.getProductFromId(id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection) {
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
            string attribute = Request.Form["attribute"];
            string st = Request.Form["id"];
            int status = Int32.Parse(st.Trim());
            string product_type = Request.Form["type"];
            string product_insurance = Request.Form["insurance"];

            Product add = new Product(product_id, name, price, price_sell, info, code, brand, color, size, attribute, status, product_type, product_insurance);
            ManageProduct manage = new ManageProduct();
            manage.updateProduct(add);

            return RedirectToAction("Index", "DataProduct");
        }

    }
}