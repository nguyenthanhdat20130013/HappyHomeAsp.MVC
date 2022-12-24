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
       

    }
}