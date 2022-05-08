using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prjEShopping.Models;

namespace prjEShopping.Controllers
{
    public class HomeController : Controller
    {
        prjEShoppingEntities db = new prjEShoppingEntities(); 

        // GET: Home
        public ActionResult Index(int categoryID = 1)
        {
            ViewBag.CategoryName = db.Category.Where(m => m.CategoryID == categoryID).FirstOrDefault().CategoryName;
            CategoryProductVM vm = new CategoryProductVM()
            {
                Category = db.Category.ToList(),
                Products = db.Products.Where(m => m.CategoryID == categoryID.ToString()).ToList()
            };
            return View(vm);
        }

        public ActionResult OnSale()
        {
            CategoryProductVM vm = new CategoryProductVM()
            {
                Category = db.Category.ToList(),
                Products = db.Products.ToList()
            };
            return View(vm);
        }

        public ActionResult Map()
        {
            return View();
        }

        public ActionResult MyCart()
        {
            return View();
        }

        public ActionResult Orders()
        {
            Orders orders = new Orders();
            orders.OrderDate = DateTime.Now;
            return View(orders);
        }

        [HttpPost]
        public ActionResult Orders(Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            return View();
        }

        public ActionResult Complete()
        {
            return View();
        }

        public ActionResult Search(string SearchProducts)
        {
            var Products = db.Products.ToList();
            string searchP = null;
            searchP = (from s in db.Products
                       where s.ProductName.Contains(SearchProducts)
                       select s.ProductName).FirstOrDefault();
            if (!String.IsNullOrEmpty(searchP))
            {
                var result = (from s in db.Products
                              where s.ProductName.Contains(SearchProducts)
                              select s).ToList();
                return View(result);
            }
            else 
                return View(Products);
        }
    }
}