using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;

namespace HappyHomeAsp.MVC.Models
{
    public class Img_Article
    {
        private int img_article_id;

        private int article_id;
        private string url;


        public Img_Article()
        {
        }

        public Img_Article(int img_article_id, int article_id, string url)
        {
            this.img_article_id = img_article_id;
            this.article_id = article_id;
            this.url = url;
        }

        public int Img_article_id { get => img_article_id; set => img_article_id = value; }
        public int Article_id { get => article_id; set => article_id = value; }
        public string Url { get => url; set => url = value; }
    }
}
