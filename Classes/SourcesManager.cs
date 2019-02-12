using System;
using AngleSharp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api_net.Classes
{
    public class SourcesManager
    {
        public List<ProductItem> search(String parameter)
        {
            List<ProductItem> source1 = new List<ProductItem>();
            List<ProductItem> source2 = new List<ProductItem>();

            MercadoLivreParser mercadoLivre = new MercadoLivreParser();
            AmazonParser amazon = new AmazonParser();
            source1 = amazon.search(parameter);
            source2 = mercadoLivre.search(parameter);

            return source1.Concat(source2).ToList();
        }
    }
}
