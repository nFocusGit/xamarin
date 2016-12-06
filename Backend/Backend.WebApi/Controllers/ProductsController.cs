using Backend.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

// https://docs.google.com/presentation/d/1BMGkgXv1V8cbS0AD-jQAxdZNSXsexsptbX3_QWi8jo8/present#slide=id.g170d4c8953_3_18

namespace Backend.WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        private List<Product> products = new List<Product>();
        private List<Review> reviews = new List<Review>();

        public ProductsController()
        {
            // Product dummy data
            for (int i = 0; i < 10; i++)
            {
                Product p = new Product();
                p.Id = i;
                p.Name = "New Name: " + i;
                p.Category = "Category: " + i;
                decimal d = (decimal)i * 2;
                p.Price = d;
                products.Add(p);
            }

            // Review dummy data
            for (int i = 0; i < 10; i++)
            {
                Review r = new Review();
                r.Id = i;
                r.ProductId = i;
                r.Rating = i + 5;
                r.Text = "Text: " + i;
                reviews.Add(r);
            }
            for (int i = 0; i < 3; i++)
            {
                Review r = new Review();
                r.Id = i;
                r.ProductId = 3;
                r.Rating = i + 5;
                r.Text = "Text: " + i;
                reviews.Add(r);
            }

        }

        [Route("")]
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        [Route("{id}")]
        [HttpGet]
        public Product GetProduct(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product != null)
            {
                return product;
            }
            else
            {
                //MyExceptionHandler
                return null;
            }
        }

        // http://localhost:54980/products/3/reviews
        [Route("{productId}/reviews")]
        [HttpGet]
        public IEnumerable<Review> GetReviewsForProduct(int productId)
        {
            var allReviews = reviews.FindAll(r => r.ProductId == productId);
            return allReviews;
        }

        // http://stackoverflow.com/questions/21901808/need-a-complete-sample-to-handle-unhandled-exceptions-using-exceptionhandler-i
        public class MyExceptionHandler : ExceptionHandler
        {
            public override void Handle(ExceptionHandlerContext context)
            {
                //TODO: Do what you need to do
                base.Handle(context);
            }
        }
    }
}
