using HappyHomeAsp.MVC.DataBase;
using HappyHomeAsp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeMVC.Controllers
{
    public class HomeWebController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection collection)
        {
            var username = collection["username"];
            var password = collection["password"];
            if (string.IsNullOrEmpty(username))
            {
                ModelState.AddModelError("errorUserName", "Phải Nhập Tên Đăng Nhập!");
            } else if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("errorPass", "Phải Nhập Mật Khẩu!");
            }
            else { 
            
                User user = UserDAO.findUser(username, password);
                if (user != null)
                {
                    if (user.Status != 0)
                    {
                        // add Session
                        //Session["User"] = user;
                        Session.Add("user", user);
                        return RedirectToAction("Index");
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
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }
        public ActionResult Account()
        {
            var userSession = (User)Session["User"];
            User user = UserDAO.findUserById(userSession.Id);
            //ViewBag.User = user;
            return View(user);
        }

        /* [HttpGet]
         public ActionResult editAccount(FormCollection collection)
         {
             var id = (int)Session["id"];
             var passWord = collection["password"];
             var fullName = collection["fullname"];
             var email = collection["email"];
             var phoneNum = collection["phone_num"];
             var address = collection["address"];
             UserDAO.updateUser(id,passWord,fullName,email,phoneNum,address);
             return RedirectToAction("Account");
         }*/

        [HttpPost]
        public ActionResult Account(User updateUser)
        {
            var userSession = (User)Session["User"];
            if (String.IsNullOrEmpty(updateUser.Email))
            {
                ModelState.AddModelError("errorEmail", "Phải Nhập Email!");
            }
            else
            if (String.IsNullOrEmpty(updateUser.PassWord))
            {
                ModelState.AddModelError("errorPass", "Phải Nhập Mật Khẩu!");
            }
            else
            if (String.IsNullOrEmpty(updateUser.FullName))
            {
                ModelState.AddModelError("errorFullName", "Phải Nhập Tên");
            }
            else
            if (String.IsNullOrEmpty(updateUser.PhoneNum))
            {
                ModelState.AddModelError("errorPhoneNum", "Phải Nhập Mật Khẩu!");
            }
            else
            if (String.IsNullOrEmpty(updateUser.Address))
                {
                ModelState.AddModelError("errorAddress", "Phải Nhập Mật Khẩu!");
                }
            else
            {
                UserDAO.updateUser(userSession.Id, updateUser.PassWord, updateUser.FullName, updateUser.Email, updateUser.PhoneNum, updateUser.Address);
                ModelState.AddModelError("successUpdate", "Cập nhật thông tin thành công!");
                //return View(updateUser);
            }   
            return View(updateUser);
            //return RedirectToAction("Account");
        }
    }
}
