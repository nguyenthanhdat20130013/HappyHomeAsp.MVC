using HappyHomeAsp.MVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Mvc;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace HappyHomeAsp.MVC.Controllers
{
    public class DiningRoomController : Controller
    {
        // GET: DiningRoom
        public ActionResult Index(int productTypeId)
        {
            ManageData manage = new ManageData();
            ArrayList products = new ArrayList();
            if (productTypeId >= 0)
            {
                products = manage.selectAllProductFromType(productTypeId);
            }
            else
            {
                products = manage.selectAllProduct2();
            }
            List<ProductType> listNameType = manage.getNameProductTypes();
            ViewBag.listType = listNameType;

            ViewBag.productTypeName = manage.getNameProductType(productTypeId);
            return View(products);
        }

    }
}