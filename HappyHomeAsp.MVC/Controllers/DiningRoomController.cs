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
        public ActionResult Index()
        {
            ManageData manage = new ManageData();
            ArrayList products = new ArrayList();
            products = manage.selectAllProduct2();

            return View(products);
        }

    }
}