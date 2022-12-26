using HappyHomeAsp.MVC.Models;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace HappyHomeAsp.MVC.Controllers
{
    public class ProductCartPageController : Controller
    {
        // GET: ProductCartPage
        private const string CartSession = "CartSession";
        ArrayList arrayList = new ArrayList();
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            ManageData manage = new ManageData();
           
            arrayList = manage.selectAllProduct2();
            List<ProductType> listNameType = manage.getNameProductTypes();
            ViewBag.listType = listNameType;

            return View(list);
        }
        public JsonResult DeleteAll()
        {
            Session[CartSession] = null;
            return Json(new { status = true });
        }
        public JsonResult Delete(long id) {
        var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x =>x.product.Product_id == id);
            Session[CartSession] = sessionCart;
            return Json(new { status = true });
        }
        public JsonResult Update(string cartModel)
        {
            var jsonCart = new JavaScriptSerializer().Deserialize<List<CartItem>>(cartModel);
            var sessionCart = (List<CartItem>)Session[CartSession];

            foreach (var item in sessionCart)
            {
                var jsonItem = jsonCart.SingleOrDefault(x => x.product.Product_id == item.product.Product_id);
                if (jsonItem != null)
                {
                    item.Quantity = jsonItem.Quantity;
                }
            }
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }
        public ActionResult AddItem(long productId, int quantity)
        {
            int id = Int32.Parse(productId.ToString());
            Product product = new Product();
            ManageData manage = new ManageData();
            product = manage.getProductFromId(id);
           
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.product.Product_id == productId))
                {

                    foreach (var item in list)
                    {
                        if (item.product.Product_id == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                //Gán vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Payment()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        

        public ActionResult Success()
        {
            return View();
        }
        public ActionResult UnSuccess()
        {
            return View();
        }

    }
}