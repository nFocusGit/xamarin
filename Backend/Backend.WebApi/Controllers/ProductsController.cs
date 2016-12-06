using Backend.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Backend.WebApi.Controllers
{
    public class ProductsController : ApiController
    {
        private List<Product> products = new List<Product>();

        public ProductsController()
        {
            for (int i = 0; i < 3; i++)
            {
                Product p = new Product();
                p.Id = i;
                p.Name = "New Name: " + i;
                Char c = Convert.ToChar(i);
                p.Category = "Category: " + i;
                decimal d = (decimal)i * 2;
                p.Price = 10;
                products.Add(p);
            }

        }

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
