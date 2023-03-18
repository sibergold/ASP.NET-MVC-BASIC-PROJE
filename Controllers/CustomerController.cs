using Microsoft.AspNetCore.Mvc;
using OOP_Projesi.Entity;
using OOP_Projesi.ProjeContext;

namespace OOP_Projesi.Controllers
{
    public class CustomerController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var values = context.Customers.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CustomerAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CustomerAdd(Customer p)
        {
            context.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
       
        public IActionResult CustomerDelete(int id) 
        {
             var values=context.Customers.Where(x=>x.CustomerId==id).FirstOrDefault();
            context.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateCustomer(int id) 
        {
            var values = context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();

            return View(values); 
        }
        [HttpPost]
        public IActionResult UpdateCustomer(Customer p)
        {
            var values = context.Customers.Where(x => x.CustomerId == p.CustomerId).FirstOrDefault();
            values.CustomerName=p.CustomerName;
            values.CustomerCity=p.CustomerCity;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
