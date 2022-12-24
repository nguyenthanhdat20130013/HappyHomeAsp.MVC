using HappyHomeAsp.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class BlogListSidebarLeftPageController : Controller
    {
        // GET: BlogListSidebarLeftPage
        public ActionResult Index()
        {
            //
            ManageData manage = new ManageData();
            ArrayList articles = new ArrayList();
            articles = manage.selectAllArticle();
            ArrayList articleImgs = new ArrayList();

            //listNameType cua Layout
            List<ProductType> listNameType = manage.getNameProductTypes();
            ViewBag.listType = listNameType;

            return View(articles);
        }
    }
}