using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductWebApp.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Quantity { set; get; }
    }
}