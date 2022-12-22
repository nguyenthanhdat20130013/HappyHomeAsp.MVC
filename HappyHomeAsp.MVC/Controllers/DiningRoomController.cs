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

namespace HappyHomeAsp.MVC.Controllers
{
    public class DiningRoomController : Controller
    {
        // GET: DiningRoom
        public ActionResult Index()
        {
            List<Product> products = new List<Product>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM product";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Product pro = new Product(sdr.GetInt32(0), sdr.GetString(1),
                                sdr.GetInt32(2), sdr.GetInt32(3), sdr.GetString(4), sdr.GetString(5),
                                sdr.GetString(6), sdr.GetString(7), sdr.GetString(8), sdr.GetString(9),
                                sdr.GetInt32(10), sdr.GetString(11), sdr.GetString(12));
                            products.Add(pro);

                             
                        }
                    }
                    con.Close();
                }
            }

            return View(products);
        }

    }
}