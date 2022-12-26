using HappyHomeAsp.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            ManageData manage = new ManageData();
            List<ProductType> listNameType = manage.getNameProductTypes();
            ViewBag.listType = listNameType;



            ManageData mdt = new ManageData();
            List<Product> productTypeListBestSell = mdt.GetProductBestSell(6);
            ViewBag.productTypeListBestSell = productTypeListBestSell;


            // danh sach sp moi
            List<Product> productTypeListNew = mdt.GetProductNew(6);
            ViewBag.productTypeListNew = productTypeListNew;
            List<String> listSlideImg = mdt.GetSlideImg(4);
            ViewBag.listSlideImg = listSlideImg;
            return View();
        }
    }
}