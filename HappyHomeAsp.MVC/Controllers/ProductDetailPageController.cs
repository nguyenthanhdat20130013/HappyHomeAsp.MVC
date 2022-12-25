using HappyHomeAsp.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class ProductDetailPageController : Controller
    {
        // GET: ProductDetailPage
        public ActionResult Index(int id)
        {

            ManageData manage = new ManageData();
            Product product = manage.getProductFromId(id);
            List<Product> productsBestSell = manage.GetProductBestSell(3);
            ViewBag.get3ProductsBestSell = productsBestSell;
            int type = int.Parse(product.Product_type);
            List<Product> relatedProducts = manage.selectNProductFromType(type, 3);
            ViewBag.related3Products = relatedProducts;
            List<ProductType> listNameType = manage.getNameProductTypes();
            ViewBag.listType = listNameType;

            return View(product);
        }

        public ActionResult AddToCart(int productId)
        {
            // Retrieve the product from the database using its id
            ManageData manage = new ManageData();
            var product = manage.getProductFromId(productId);

            // Add the product to the cart
            var cart = (Dictionary<int, int>)Session["cart"];
            if (cart == null)
            {
                cart = new Dictionary<int, int>();
            }
            if (cart.ContainsKey(productId))
            {
                cart[productId]++;
            }
            else
            {
                cart[productId] = 1;
            }
            Session["cart"] = cart;

            return RedirectToAction("Index");
        }


    }
}