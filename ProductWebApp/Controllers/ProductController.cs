using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductWebApp.Models;
using System.Net.Http;

namespace ProductWebApp.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        //

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            HttpClient client = new HttpClient();
            Product product = null;
            client.BaseAddress = new Uri("http://localhost:31486/api/");
            HttpResponseMessage response = client.GetAsync("Product/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                 product = response.Content.ReadAsAsync<Product>().Result;
            }
            else
            {
                //Something has gone wrong, handle it here
            }
            return View(product);
        }
    }
}
