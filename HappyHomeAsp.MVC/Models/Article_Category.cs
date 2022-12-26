using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;

namespace HappyHomeAsp.MVC.Models
{
    public class Article_Category
    {
        private int article_category_id;

        private string article_category_name;


        public Article_Category()
        {
        }

        public Article_Category(int article_category_id, string article_category_name)
        {
            this.article_category_id = article_category_id;
            this.article_category_name = article_category_name;
        }

        public int Article_category_id { get => article_category_id; set => article_category_id = value; }
        public string Article_category_name { get => article_category_name; set => article_category_name = value; }
    }
}
