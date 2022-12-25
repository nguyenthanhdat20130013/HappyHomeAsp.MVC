using HappyHomeAsp.MVC.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;

namespace HappyHomeAsp.MVC.Models
{
    public class Article
    {
        private int article_id;

        private int article_category_id;

        private string title;

        private string content;

        private string img;


        public Article()
        {
        }

        public Article(int article_id, int article_category_id, string title, string content)
        {
            this.Article_id = article_id;
            this.Article_category_id = article_category_id;
            this.Title = title;
            this.Content = content;
        }

        public Article(int article_id, string title, string content, string img_url)
        {
            this.Title = title;
            this.Content = content;
            this.Img = img_url;
        }

        public int Article_id { get => article_id; set => article_id = value; }
        public int Article_category_id { get => article_category_id; set => article_category_id = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string Img { get => img; set => img = value; }



    }
}



