using CustomRoutesExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomRoutesExample.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: 
       
        
        
        public ActionResult Index(string category = null, int ordinal = -1)
        {
            // /Categories -> Category is empty, so we're at the main directive
            if (string.IsNullOrEmpty(category) && ordinal == -1)
            {
            var products = ProductManager.GetProducts();
            var categories = products.Select(p => p.Category).Distinct();
            return View("CategoryList", categories);
            }
            // /Categories/Gadgets -> Block of code executed since Category isn't NULL anymore
            else if (!string.IsNullOrEmpty(category) && ordinal == -1)
            {
            var products = ProductManager.GetProducts().Where(p => p.Category == category);
            ViewBag.Category = category;
            return View("ProductList", products);
            }
            // /Categories/Gadgets/1 -> The number at the end references the particular item that you want in the Product List
            else
            {
            var products = ProductManager.GetProducts().Where(p => p.Category == category).ToList();
            var product = products[ordinal];
            return View("ProductDetail", product);
            }
        }

        public ActionResult Details(string category, int id)
        {
          var product = ProductManager.GetProducts().FirstOrDefault(p => p.Category == category && p.ProductId == id);
          return View("ProductDetail", product);
        }
    }
}