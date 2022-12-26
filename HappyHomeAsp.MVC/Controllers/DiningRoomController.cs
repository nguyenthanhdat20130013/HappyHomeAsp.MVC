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
using PagedList;
namespace HappyHomeAsp.MVC.Controllers
{
    public class DiningRoomController : Controller
    {
        // GET: DiningRoom
        public ActionResult Index(int productTypeId, int? page, int? pageSize)
        {
            if (productTypeId == null)
            {
                productTypeId = -1;
            }
            if (page == null)
            {
                page = 1;
            }
            if(pageSize == null)
            {
                pageSize = 2;
            }
            ViewBag.PageSize = pageSize;
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

            if (productTypeId >= 0)
            {
                ViewBag.productTypeName = manage.getNameProductType(productTypeId);
            }
            else
            { 
                ViewBag.productTypeName = "Tất cả sản phẩm";
            }
            List<Product> products2 = new List<Product>();
            foreach(Product p in products)
            {
                products2.Add(p);
            }
            ViewBag.ProductTypeId = productTypeId;
            return View(products2.ToPagedList((int)page, (int)pageSize));
        }

    }
}