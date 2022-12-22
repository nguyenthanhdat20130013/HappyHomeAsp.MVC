﻿using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Data.Common;
using System.Diagnostics;

namespace HappyHomeAsp.MVC.Models
{
    class Product
    {
        private int product_id;

        private string name;

        private int price;

        private int price_cell;
        private string info;
        private string code;
        private string brand;
        private string color;

        private string size;

        private string attribute;

        private int status;

        private string product_type;

        private string product_insurance;

        public Product()
        {
        }

        public Product(int product_id, string name, int price, int price_cell, string info, string code, string brand, string color, string size, string attribute, int status, string product_type, string product_insurance)
        {
            this.product_id = product_id;
            this.name = name;
            this.price = price;
            this.price_cell = price_cell;
            this.info = info;
            this.code = code;
            this.brand = brand;
            this.color = color;
            this.size = size;
            this.attribute = attribute;
            this.status = status;
            this.product_type = product_type;
            this.product_insurance = product_insurance;
        }

        public int Price_cell { get => price_cell; set => price_cell = value; }
        public int Product_id { get => product_id; set => product_id = value; }
        public string Name { get => name; set => name = value; }
        public int Price { get => price; set => price = value; }
        public int Price_cell1 { get => price_cell; set => price_cell = value; }
        public string Info { get => info; set => info = value; }
        public string Code { get => code; set => code = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Color { get => color; set => color = value; }
        public string Size { get => size; set => size = value; }
        public string Attribute { get => attribute; set => attribute = value; }
        public int Status { get => status; set => status = value; }
        public string Product_type { get => product_type; set => product_type = value; }
        public string Product_insurance { get => product_insurance; set => product_insurance = value; }
        public override string ToString()
        {
            Console.WriteLine("product_id: " + product_id);

            Console.WriteLine("name: " + name);

            Console.WriteLine("price: " + price);

            Console.WriteLine("price_cell: " + price_cell);

            Console.WriteLine("------------------------");
            return "";
        }
       
    }
}