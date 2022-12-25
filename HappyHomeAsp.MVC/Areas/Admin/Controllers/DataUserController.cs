using HappyHomeAsp.MVC.DataBase;
using HappyHomeAsp.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappyHomeAsp.MVC.Controllers
{
    public class DataUserController : Controller
    {
        // GET: Admin/DataUser
        public ActionResult Index()
        {
            List<User> users = UserDAO.findAll();
            return View(users);
        }

        public ActionResult EditUser(int id)
        {
            User user = UserDAO.findUserById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUser(int id, User user)
        {
            String username = user.UserName;
            String password = user.PassWord;
            if (string.IsNullOrEmpty(username))
            {
                ModelState.AddModelError("errorUserName", "Phải Nhập Tên Đăng Nhập!");
                return View(user);
            }
            else if (string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("errorPass", "Phải Nhập Mật Khẩu!");
                return View(user);
            }
            else
            {
                UserDAO.updateUserAdmin(id, user.UserName, user.PassWord, user.Role);
               return RedirectToAction("Index");
            }
        }
            public ActionResult AddUser()
            {
                return View();
            }

            [HttpPost]
            public ActionResult AddUser(User user)
            {
                String username = user.UserName;
                String password = user.PassWord;
                if (string.IsNullOrEmpty(username))
                {
                    ModelState.AddModelError("errorUserName", "Phải Nhập Tên Đăng Nhập!");
                    return View(user);
                }
                else if (string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("errorPass", "Phải Nhập Mật Khẩu!");
                    return View(user);
                }
                else
                {
                    UserDAO.addUserAdmin(user);
                    return RedirectToAction("Index");
                }
            }

            public ActionResult DeleteUser(int id)
            {
                UserDAO.deleteUserAdmin(id);
                return RedirectToAction("Index");
            }
    }
}
