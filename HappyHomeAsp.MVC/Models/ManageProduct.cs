using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Xml.Linq;


namespace HappyHomeAsp.MVC.Models
{
    public class ManageProduct
    {
        public void insertType(string typeId)
        {
           
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "INSERT INTO product_type (type_name) values (@typeId)";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@typeId",typeId);
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                    }
                    con.Close();
                    
                }
            }
        }
        public void addProduct(Product product)
        {
            int ptype =   Int32.Parse(product.Product_type);
            string pnamw = product.Name;
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "INSERT INTO product (name, price, price_sell, info, code, brand, color, size, attribute, status, product_type, product_insurance) values (@name, @price, @price_sell, @info, @code, @brand, @color, @size, @attribute, @status, @product_type, @product_insurance)";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@name", pnamw);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@price_sell", product.Price_sell);
                    cmd.Parameters.AddWithValue("@info", product.Info);
                    cmd.Parameters.AddWithValue("@code", product.Code);
                    cmd.Parameters.AddWithValue("@brand",product.Brand);
                    cmd.Parameters.AddWithValue("@color", product.Color);
                    cmd.Parameters.AddWithValue("@size", product.Size);
                    cmd.Parameters.AddWithValue("@attribute", product.Attribute);
                    cmd.Parameters.AddWithValue("@status", product.Status);
                    cmd.Parameters.AddWithValue("@product_type", ptype);
                    cmd.Parameters.AddWithValue("@product_insurance", product.Product_insurance);                   
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                    }
                    con.Close();

                }
            }
        }
        public void updateProduct(Product product)
        {
            int ptype = Int32.Parse(product.Product_type);
            string pnamw = product.Name;
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string sql = "UPDATE product SET name = @name  , price = @price , price_sell = @price_sell , info = @info, code = @code, brand = @brand, color = @color, size = @size, attribute = @attribute, status = @status, product_type = @product_type, product_insurance = @product_insurance WHERE product_id = @product_id  ";
                using (MySqlCommand cmd = new MySqlCommand(sql))
                {

                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@product_id", product.Product_id);
                    cmd.Parameters.AddWithValue("@name", pnamw);
                    cmd.Parameters.AddWithValue("@price", product.Price);
                    cmd.Parameters.AddWithValue("@price_sell", product.Price_sell);
                    cmd.Parameters.AddWithValue("@info", product.Info);
                    cmd.Parameters.AddWithValue("@code", product.Code);
                    cmd.Parameters.AddWithValue("@brand", product.Brand);
                    cmd.Parameters.AddWithValue("@color", product.Color);
                    cmd.Parameters.AddWithValue("@size", product.Size);
                    cmd.Parameters.AddWithValue("@attribute", product.Attribute);
                    cmd.Parameters.AddWithValue("@status", product.Status);
                    cmd.Parameters.AddWithValue("@product_type", ptype);
                    cmd.Parameters.AddWithValue("@product_insurance", product.Product_insurance);
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                    }
                    con.Close();

                }
            }
        }

    }
}