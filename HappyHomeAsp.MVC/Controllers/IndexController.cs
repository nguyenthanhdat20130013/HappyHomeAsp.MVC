using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HappyHomeAsp.MVC.Models;

namespace HappyHomeAsp.MVC.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            // danh sach article moi
            ManageData mdt = new ManageData();
            ArrayList listArticle = new ArrayList();
            listArticle = mdt.selectNArticleNew(3);
            ViewBag.listArticle = listArticle;

            // danh sach sp moi
            ArrayList listProductNew = mdt.selectNProductNew(6);
            foreach(Product product in listProductNew)
            {
                product.ListImg = mdt.selectNImgProduct(2, product.Product_id);
            }

            ArrayList listProducNew1 = new ArrayList();
            listProducNew1.Add(listProductNew[0]);
            listProducNew1.Add(listProductNew[1]);
            ViewBag.listProductNew1 = listProducNew1;

            ArrayList listProducNew2 = new ArrayList();
            listProducNew2.Add(listProductNew[2]);
            listProducNew2.Add(listProductNew[3]);
            ViewBag.listProductNew2 = listProducNew2;

            ArrayList listProducNew3 = new ArrayList();
            listProducNew3.Add(listProductNew[4]);
            listProducNew3.Add(listProductNew[5]);
            ViewBag.listProductNew3 = listProducNew3;

            // danh sach sp ban chay
            ArrayList listProductBest = mdt.selectNProductBest(6);
            foreach (Product product in listProductBest)
            {
                product.ListImg = mdt.selectNImgProduct(2, product.Product_id);
            }

            ArrayList listProductBest1 = new ArrayList();
            listProductBest1.Add(listProductBest[0]);
            listProductBest1.Add(listProductBest[1]);
            ViewBag.listProductBest1 = listProductBest1;

            ArrayList listProductBest2 = new ArrayList();
            listProductBest2.Add(listProductBest[2]);
            listProductBest2.Add(listProductBest[3]);
            ViewBag.listProductBest2 = listProductBest2;

            ArrayList listProductBest3 = new ArrayList();
            listProductBest3.Add(listProductBest[4]);
            listProductBest3.Add(listProductBest[5]);
            ViewBag.listProductBest3 = listProductBest3;

            // slide img

            ArrayList listSlideImg = mdt.selectNImgSlideImg();
            ViewBag.listSlideImg = listSlideImg;


            ViewBag.listProductNew = listProductNew;
            return View();
        }
    }
}