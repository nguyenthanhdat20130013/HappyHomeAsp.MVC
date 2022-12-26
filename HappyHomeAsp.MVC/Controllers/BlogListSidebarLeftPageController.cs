using HappyHomeAsp.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace HappyHomeAsp.MVC.Controllers
{
    public class BlogListSidebarLeftPageController : Controller
    {
        // GET: BlogListSidebarLeftPage
        public ActionResult Index(int? page, int? pageSize)
        {
            if (page == null)
            {
                page = 1;
            }
            if (pageSize == null)
            {
                pageSize = 2;
            }
            ViewBag.PageSize = pageSize;
            //
            ManageData manage = new ManageData();
            ArrayList articles = new ArrayList();
            articles = manage.selectAllArticle();
            ArrayList articleImgs = new ArrayList();

            //listNameType cua Layout
            List<ProductType> listNameType = manage.getNameProductTypes();
            ViewBag.listType = listNameType;

            List<Article> articles2 = new List<Article>();
            foreach (Article article in articles)
            {
                articles2.Add(article);
            }
            return View(articles2.ToPagedList((int)page, (int)pageSize));
        }
    }
}