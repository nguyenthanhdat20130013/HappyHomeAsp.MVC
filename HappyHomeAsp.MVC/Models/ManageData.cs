using MySql.Data.MySqlClient;

using System;
using System.Collections;
using System.Collections.Generic;
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

            string sql = "select * from product";

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
    }
}