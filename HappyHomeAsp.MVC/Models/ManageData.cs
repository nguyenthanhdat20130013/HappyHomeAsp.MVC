using HappyHomeAsp.MVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Configuration;
using System.Data.Common;
using System.Runtime.Remoting.Messaging;

namespace HappyHomeAsp.MVC.Models
{

	class ManageData
	{

		public ManageData()
		{


		}

		public ArrayList selectNArticleNew(int n)
		{
			ArrayList listArticle = new ArrayList();
           string spl = "SELECT a.article_id, a.title, a.content, i.url FROM article a INNER JOIN img_article i ON a.article_id = i.article_id GROUP BY a.article_id ORDER BY a.article_id DESC LIMIT " + n;
			MySqlCommand command = new MySqlCommand();
			MySqlConnection connect = KetNoi.GetDBConnection();
			command.Connection = connect;

			command.CommandText = spl;
            /*
            		using (DbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                            Article a = new Article(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                            listArticle.Add(a);
                            }
                        }
                    }
            */
           
            Article a = new Article(1,"ffffffffffff", "fffffffffffffffff", "~/Template/img/blog/10thumb.jpg");
            Article a1 = new Article(2, "gggggggg", "ggggggggggggggg", "~/Template/img/home/home1-post2.jpg");
            Article a2 = new Article(3, "hhhhhhhhhhhhh", "hhhhhhhhhhhhh", "~/Template/img/home/home1-post3.jpg");
            listArticle.Add(a);
            listArticle.Add(a1);
            listArticle.Add(a2);
            return listArticle;
        }
        public ArrayList selectNProductNew(int n)
        {
            ArrayList listProduct = new ArrayList();
			string sql = "SELECT p.product_id, p.name, p.price, p.price_sell, p.info FROM product p ORDER BY p.product_id DESC LIMIT " + n;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connect = KetNoi.GetDBConnection();
            command.Connection = connect;

            command.CommandText = sql;
            /*
                   	using (DbDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        Product p = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4));
                                        listProduct.Add(p);
                                    }
                                }
                            }
            */
            Product p = new Product(1, "San pham so 1", 1222222, 1 ,"fffff");
            Product p1 = new Product(1, "San pham so 2", 10, 1, "fffff");
            Product p2 = new Product(1, "San pham so 3", 100, 1, "fffff");
            Product p3 = new Product(1, "San pham so 4", 1000, 1, "fffff");
            Product p4 = new Product(1, "San pham so 5", 10000, 1, "fffff");
            Product p5 = new Product(1, "San pham so 6", 100000, 1, "fffff");

            listProduct.Add(p);
            listProduct.Add(p1);
            listProduct.Add(p2);
            listProduct.Add(p3);
            listProduct.Add(p4);
            listProduct.Add(p5);

                    

            return listProduct;
        }


        public ArrayList selectNProductBest(int n)
        {
            ArrayList listProduct = new ArrayList();
            string sql = "SELECT product.product_id, product.name, product.price, product.price_sell SUM(order_detail.amount) AS soLgDaBan FROM product INNER JOIN order_detail ON order_detail.id_product = product.product_id GROUP BY order_detail.id_product ORDER BY soLgDaBan DESC LIMIT " + n;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connect = KetNoi.GetDBConnection();
            command.Connection = connect;

            command.CommandText = sql;
            /*       	using (DbDataReader reader = command.ExecuteReader())
                            {
                                if (reader.HasRows)
                                {
                                    while (reader.Read())
                                    {
                                        Product p = new Product(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetString(4));
                                        listProduct.Add(p);
                                    }
                                }
                            }
            */
            Product p = new Product(1, "San pham so 1", 1222222, 1111111, "bbbbbbbbbbbbbbbbbb");
            Product p1 = new Product(1, "San pham so 2", 111111, 111111111, "bbbbbbbbbbbbbbbbbbbbb");
            Product p2 = new Product(1, "San pham so 3", 111111111, 11111, "bbbbbbbbbbbbbbbb");
            Product p3 = new Product(1, "San pham so 4", 1111111111, 1111111, "bbbbbbbbbbbbbbbb");
            Product p4 = new Product(1, "San pham so 5", 111111, 1111111, "bbbbbbbbbbbbbbbbb");
            Product p5 = new Product(1, "San pham so 6", 1111111, 1111111, "bbbbbbbbbbbbbbbbbbbb");

            listProduct.Add(p);
            listProduct.Add(p1);
            listProduct.Add(p2);
            listProduct.Add(p3);
            listProduct.Add(p4);
            listProduct.Add(p5);

            return listProduct;
        }

        public ArrayList selectNImgProduct(int n, int product_id)
		{
			ArrayList listimg = new ArrayList();
            string sql = "SELECT i.img_url FROM image i where i.product_id = "+ product_id+" LIMIT " + n;
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connect = KetNoi.GetDBConnection();
            command.Connection = connect;

            command.CommandText = sql;
            /*         using (DbDataReader reader = command.ExecuteReader())
                     {
                         if (reader.HasRows)
                         {
                             while (reader.Read())
                             {
                                 listimg.Add(reader.GetString(0));

                             }
                         }
                     }
            */
            listimg.Add("https://homeoffice.com.vn/images/detailed/53/ban-cafe-tron-go-tram-cfd68111-01.png");
            listimg.Add("https://homeoffice.com.vn/images/detailed/53/ban-cafe-tron-go-tram-cfd68111-03.jpg");
            return listimg;
        }

        public ArrayList selectNImgSlideImg()
        {
            ArrayList listimg = new ArrayList();
            string sql = "SELECT i.slider_url FROM slideimg";
            MySqlCommand command = new MySqlCommand();
            MySqlConnection connect = KetNoi.GetDBConnection();
            command.Connection = connect;

            command.CommandText = sql;
            /*         using (DbDataReader reader = command.ExecuteReader())
                     {
                         if (reader.HasRows)
                         {
                             while (reader.Read())
                             {
                                 listimg.Add(reader.GetString(0));

                             }
                         }
                     }
            */
            listimg.Add("~/Template/img/home/home1-banner1.jpg");
            listimg.Add("~/Template/img/home/home1-banner2.jpg");
            listimg.Add("~/Template/img/home/home1-banner3.jpg");

            return listimg;
        }




    }
	
}