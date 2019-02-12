using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_net.Classes;
using Microsoft.AspNetCore.Mvc;

namespace api_net.Controllers
{
    [Route("/")]
    public class MainController : Controller
    {

        [HttpGet()]
        public string Get(int id)
        {
            return "API Server, use v1 routes for access the endpoints.";
        }

        [HttpGet("v1")]
        public string GetVOne(int id)
        {
            return "API Server, use v1 routes for access the endpoints.";
        }

        [HttpGet("v1/search/{parameter}")]
        public List<ProductItem> GetTest(String parameter)
        {
            SourcesManager sm = new SourcesManager();
            return sm.search(parameter);
        }

    }
}
