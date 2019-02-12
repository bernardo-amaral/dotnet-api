using System;
using AngleSharp;
using System.Collections.Generic;
using System.Linq;

namespace api_net.Classes
{
    public class ProductItem
    {

        public String title = "";
        public String price = "";
        public String image = "";
        public String source = "";

        public ProductItem(String title, String price, String image, String source)
        {
            this.title = title;
            this.price = price.Replace("R$ ", "");
            this.image = image;
            this.source = source;
        }
    }
}
