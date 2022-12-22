using HappyHomeAsp.MVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class DiningRoomController : Controller
    {
        // GET: DiningRoom
        public ActionResult Index()
        {
            ManageData manageData = new ManageData();
            
            ArrayList products = manageData.selectAllProduct();

            ViewBag.listProduct = products;
            ViewBag.total = products.Count;

            return View(products);
        }

    }
}