using System;
using AngleSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using AngleSharp.Dom;
using AngleSharp.Html.Parser;

namespace api_net.Classes
{
    public class AmazonParser
    {

        public List<ProductItem> search(String parameter)
        {
            try
            {
                List<ProductItem> items = new List<ProductItem>();
                WebClient client = new WebClient();
                string downloadString = client.DownloadString(@"https://www.amazon.com.br/s?k="+parameter.Replace(" ", "-"));
                var parser = new HtmlParser();
                var document = parser.ParseDocument(downloadString);
                var blueListItemsCssSelector = document.QuerySelectorAll("div.rush-component div.sg-row");
                foreach (var item in blueListItemsCssSelector)
                {
                    String title = (item.QuerySelectorAll("h5 a.a-size-medium").Count() > 0) ? item.QuerySelectorAll("h5 a.a-size-medium").First().Text().Trim() : "?????";
                    String price = (item.QuerySelectorAll("span.a-price").Count() > 0) ? item.QuerySelectorAll("span.a-price").First().Text().Trim() : "????";
                    String image = "";

                    ProductItem obj = new ProductItem(title, price, image, "amazon");
                    items.Add(obj);
                }
                return items;
            }
            catch (DomException)
            {
                return null;
            }
        }
    }
}
