﻿using HappyHomeAsp.MVC.Models;
using System;
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

            return View();
        }
    }
}