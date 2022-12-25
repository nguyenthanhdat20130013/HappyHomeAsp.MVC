using HappyHomeAsp.MVC.DataBase;
using HappyHomeAsp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User userlogin)
        {
            String username = userlogin.UserName;
            String password = userlogin.PassWord;
            if (string.IsNullOrEmpty(username))
            {
                ModelState.AddModelError("errorUserName", "Phải Nhập Tên Đăng Nhập!");
            }
            else if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("errorPass", "Phải Nhập Mật Khẩu!");
            }
            else
            {
                User user = UserDAO.findUser(username, password);
                if (user != null)
                {
                    if (user.Role != 1)
                    {
                        ModelState.AddModelError("errorRole", "Bạn Không có quyền đăng nhập");
                    }
                    else
                    if (user.Status != 0)
                    {
                        // add Session
                        //Session["User"] = user;
                        Session.Add("user", user);
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError("errorStatus", "Tài Khoản của bạn đã bị khoá.");
                    }
                }
                else
                {
                    ModelState.AddModelError("error", "Thông tin đăng nhập không đúng.");
                }  
            }
            return View(userlogin);
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Index");
        }
    }

}
