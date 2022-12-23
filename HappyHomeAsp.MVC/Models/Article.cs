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

        public int Article_id { get => article_id; set => article_id = value; }
        public int Article_category_id { get => article_category_id; set => article_category_id = value; }
        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }

        public String selectFirstImageArticle()
        {
            ManageData manageData = new ManageData();
            ArrayList articles = manageData.selectAllImageArticle(article_id);
            if (articles.Count > 0)
            {
                Img_Article img_Article = (Img_Article)articles[0];
                return img_Article.Url;
            }
            return "";
        }

        public String getImageArticle(int index)
        {
            ManageData manageData = new ManageData();
            ArrayList articleImages = manageData.selectAllImageArticle(article_id);
            if (articleImages.Count > 0)
            {
                if (articleImages.Count > index)
                {
                    Img_Article img = (Img_Article)articleImages[index];
                    return img.Url;
                }
            }
            return "";
        }

    }
}
