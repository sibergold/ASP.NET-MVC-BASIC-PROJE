using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using OOP_Projesi.ProjeContext;
using OOP_Projesi.Entity;

namespace OOP_Projesi.Controllers
{
    public class ProductController : Controller
    {
        Context context = new Context();

        public IActionResult Index()
        {
            var values = context.Products.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {

            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product p)
        {
            context.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(int id)
        {
            var value = context.Products.Where(x => x.ProductId == id).FirstOrDefault();
            context.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            var value=context.Products.Where(x=>x.ProductId == id).FirstOrDefault();
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product p)
        {
            var value = context.Products.Where(x => x.ProductId == p.ProductId).FirstOrDefault();
            value.ProductName = p.ProductName;
            value.ProductPrice = p.ProductPrice;
            value.ProductStock = p.ProductStock;
            context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
