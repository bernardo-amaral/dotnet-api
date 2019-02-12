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
    public class MercadoLivreParser
    {
        public List<ProductItem> search(String parameter)
        {
            try
            {
                List<ProductItem> items = new List<ProductItem>();

                WebClient client = new WebClient();
                string downloadString = client.DownloadString(@"https://lista.mercadolivre.com.br/"+parameter);

                var parser = new HtmlParser();
                var document = parser.ParseDocument(downloadString);
                var blueListItemsCssSelector = document.QuerySelectorAll("div.item__info-container");

                foreach (var item in blueListItemsCssSelector)
                {
                    String title = item.QuerySelectorAll("a.item__info-title").First().Text().Trim();
                    String price = item.QuerySelectorAll("div.item__price").First().Text().Trim();
                    String image = "";//item.QuerySelectorAll("a.item-image").First().InnerHtml;
                    ProductItem obj = new ProductItem(title, price, image, "mercadolivre");
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
