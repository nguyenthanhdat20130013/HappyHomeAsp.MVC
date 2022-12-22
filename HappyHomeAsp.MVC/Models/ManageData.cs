using MySql.Data.MySqlClient;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;

using System.Text;

namespace HappyHomeAsp.MVC.Models
{

    class ManageData
    {

        public ManageData()
        {
            

        }

        public  ArrayList selectAllProduct()
        {

            ArrayList listProduct = new ArrayList();

            string sql = "select * from product where product_type = "+"ghe";

            MySqlCommand command = new MySqlCommand();
            MySqlConnection connect = KetNoi.GetDBConnection();

            command.Connection = connect;

            command.CommandText = sql;

            using (DbDataReader reader = command.ExecuteReader())
            {

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        Product p = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7), reader.GetString(8), reader.GetString(9), reader.GetInt32(10), reader.GetString(11), reader.GetString(12));


                        listProduct.Add(p);

                    }
                }
            }

            return listProduct;

        }
        public  ArrayList selectAllImageForProduct(int productId)
        {

            ArrayList listImage = new ArrayList();

            string sql = "select * from image where image.product_id = " + productId + " LIMIT 1";

            MySqlCommand command = new MySqlCommand();

            MySqlConnection connect = KetNoi.GetDBConnection();

            command.Connection = connect;

            command.CommandText = sql;

            using (DbDataReader reader = command.ExecuteReader())
            {

                if (reader.HasRows)
                {

                    while (reader.Read())
                    {

                        Image i = new Image(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));


                        listImage.Add(i);

                    }
                }
            }

            return listImage;

        }

        public ArrayList selectAllProduct2()
        {
            ArrayList products = new ArrayList();
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
                    return products;
                }
            }
        }

        public ArrayList selectAllArticle()
        {
            ArrayList articles = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM article";

               

                            Article ar = new Article(sdr.GetInt32(0), sdr.GetInt32(1), sdr.GetString(2), sdr.GetString(3));
                            articles.Add(ar);
                        }
                    }
                    con.Close();
                    return articles;
                }
            }
        }
        public ArrayList selectAllImageArticle(int articleId)
        {
            ArrayList articles = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM img_article where article_id = " + articleId;
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Img_Article imgAr = new Img_Article(sdr.GetInt32(0), sdr.GetInt32(1), sdr.GetString(2));
                            articles.Add(imgAr);
                        }
                    }
                    con.Close();
                    return articles;
                }

            }
        }
    }
}