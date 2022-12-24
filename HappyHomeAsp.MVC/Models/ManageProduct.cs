using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HappyHomeAsp.MVC.Models
{
    public class ManageProduct
    {
        public void addProduct(string name, string type)
        {
           
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "Insert into into product (name , product_type)"

                                                + " values (@name, @type) ";



                MySqlCommand cmd = new MySqlCommand(query);
                
                    cmd.Connection = con;
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = query;
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@type", type);

                    con.Close();
                    
                
            }
        }
    }
}