using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;

namespace HappyHomeAsp.MVC.Models
{

    class ManageData
    {

        public ManageData()
        {


        }


        public ArrayList selectAllImageForProduct(int productId)
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

                        //Image i = new Image(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));


                        //listImage.Add(i);

                    }
                }
            }

            return listImage;

        }
        public List<ProductType> selectAllProductType()
        {
            List<ProductType> productTypes = new List<ProductType>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM product_type";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            ProductType pro = new ProductType(sdr.GetString(0), sdr.GetString(1));
                            productTypes.Add(pro);
                        }
                    }
                    con.Close();
                    return productTypes;
                }
            }
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

        public ArrayList selectAllProductFromType(int typeId)
        {
            ArrayList products = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM product WHERE product_type =" + typeId;
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

        public List<Product> selectNProductFromType(int typeId, int n)
        {
            List<Product> products = new List<Product>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM product WHERE product_type = " + typeId + " LIMIT "+ n;
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

        public Product getProductFromId(int id)
        {
            ArrayList products = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM product where product_id = " + id;
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
                            return pro;
                        }
                    }
                    con.Close();
                    return null;
                }
            }
        }
        public List<Product> GetProductBestSell(int n)
        {
            List<Product> products = new List<Product>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT product.*, SUM(order_detail.amount) AS soLgDaBan FROM product" +
                    " INNER JOIN order_detail ON order_detail.id_product = product.product_id GROUP BY order_detail.id_product ORDER BY soLgDaBan DESC LIMIT " + n;
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

        public List<Product> GetAllProductBestSell()
        {
            List<Product> products = new List<Product>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT product.*, SUM(order_detail.amount) AS soLgDaBan FROM product" +
                    " INNER JOIN order_detail ON order_detail.id_product = product.product_id GROUP BY order_detail.id_product ORDER BY soLgDaBan DESC";
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

        public List<Product> GetProductNew(int n)
        {
            List<Product> products = new List<Product>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM product p ORDER BY p.product_id DESC LIMIT " + n;
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

        public List<String> GetSlideImg(int n)
        {
            List<String> urlSlides = new List<String>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT slider_url from slideimg LIMIT " + n;
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            urlSlides.Add(sdr.GetString(0));
                        }
                    }
                    con.Close();
                    return urlSlides;
                }
            }
        }

        public Article getArticleFromId(int id)
        {
            ArrayList products = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM article where article_id = " + id;
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Article ar = new Article(sdr.GetInt32(0), sdr.GetInt32(1),
                                sdr.GetString(2), sdr.GetString(3));
                            return ar;
                        }
                    }
                    con.Close();
                    return null;
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
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
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
        public ArrayList selectAllImageProduct(int productId)
        {
            ArrayList images = new ArrayList();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM image where product_id = " + productId;
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Image img_p = new Image(sdr.GetInt32(0), sdr.GetInt32(1), sdr.GetString(2));
                            images.Add(img_p);
                        }
                    }
                    con.Close();
                    return images;
                }
            }
        }

        public String getNameProductType(int typeId)
        {
            List<ProductType> productTypes = new List<ProductType>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT type_name FROM product_type where type_id = " + typeId;
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            return sdr.GetString(0);
                        }
                    }
                    con.Close();
                    return "";
                }
            }
        }
        public List<ProductType> getNameProductTypes()
        {
            List<ProductType> productTypes = new List<ProductType>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT * FROM product_type GROUP BY type_id ";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            productTypes.Add(new ProductType(sdr.GetString(0), sdr.GetString(1)));
                        }
                    }
                    con.Close();
                    return productTypes;
                }
            }
        }





    }
}
