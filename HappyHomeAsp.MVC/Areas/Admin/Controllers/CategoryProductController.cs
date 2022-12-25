using HappyHomeAsp.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Areas.Admin.Controllers
{
    public class CategoryProductController : Controller
    {
        ProductType type = new ProductType();
        // GET: Admin/CategoryProduct
        public ActionResult Index()
        {
            ManageData manage = new ManageData();
            List<ProductType> listNameType = manage.getNameProductTypes();
            ViewBag.listType = listNameType;
            return View();
        }
       public ActionResult add_type()
        {
            ViewBag.maloai = type.type_id;
            ViewBag.tenloai = type.type;
            return View();
        }
        [HttpPost]
        public ActionResult add_type(FormCollection collection)
        {
            var id = Request.Form["id"];
            var type = Request.Form["type"];
            ManageProduct manage = new ManageProduct();
            manage.insertType(type);
            return RedirectToAction("Index");
        }
    }
}