using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;
using System.Xml.Linq;

namespace HappyHomeAsp.MVC.Models
{
    class Image
    {
        private int img_id;

        private int product_id;

        private string img_url;

        public Image()
        {
        }
        public Image(int img_id, int product_id, string img_url)
        {
            this.img_id = img_id;
            this.product_id = product_id;
            this.Img_url = img_url;
        }

        public int Img_id { get => img_id; set => img_id = value; }
        public int Product_id { get => product_id; set => product_id = value; }
        public string Img_url { get => img_url; set => img_url = value; }

        public override string ToString()
        {
            Console.WriteLine("img_id: " + img_id);
            Console.WriteLine("product_id: " + product_id);

            Console.WriteLine("img_url: " + Img_url);

            Console.WriteLine("------------------------");
            return "";
        }

    }
}
