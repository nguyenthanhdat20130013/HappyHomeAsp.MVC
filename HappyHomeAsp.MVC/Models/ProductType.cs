using System;

namespace HappyHomeAsp.MVC.Models
{
    public class ProductType
    {
        public string type_id { get; set; }
        public string type { get; set; }
        public ProductType(string type_id, string type)
        {
            this.type_id = type_id;
            this.type = type;
        }

        public ProductType()
        {
        }
    }

}