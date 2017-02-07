using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using ProductWebApi.Data;
using System.Net.Http;
using System.Net;

namespace ProductWebApi.Controllers
{
    public class ProductController : ApiController
    {
        private WebApiEntities context;
        //private List<Product> Products = new List<Product>();

        public ProductController()
        {
            context = new WebApiEntities();
            //Products.Add(new Product { Id = 1, Name = "Product1", Quantity = 20 });
            //Products.Add(new Product { Id = 2, Name = "Product2", Quantity = 10 });
            //Products.Add(new Product { Id = 3, Name = "Product3", Quantity = 30 });
        }

        public IEnumerable<Product> Get()
        {
            return context.Products;
        }

        public Product Get(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Post(Product product)
        {
            context.Products.AddObject(product);
            context.SaveChanges();
        }

        public void Put([FromUri]int id, [FromBody]Product product)
        {
            context.Products.ApplyCurrentValues(product);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Products.DeleteObject(context.Products.FirstOrDefault(p => p.Id == id));
            context.SaveChanges();
        }

        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }

    }
}
