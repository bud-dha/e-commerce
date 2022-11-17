using System.Linq;
using e_commerce.Data;
using e_commerce.Models;
using e_commerce.Utility;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace e_Comerce.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private ApplicationContext _db;

        public HomeController(ApplicationContext db)
        {
            _db = db;
        }

        public ActionResult Index() 
        {
            return View(_db.Products.Include(c=>c.ProductTypes).ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        #region Получение информации о типе товара.

        //GET product detail action method
        public ActionResult Detail(int? id)
        {
            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);

            if (id == null)            
                return NotFound();            

            if (product == null)            
                return NotFound();   
            
            return View(product);
        }

        //POST product detail acation method
        [HttpPost]
        [ActionName("Detail")]
        public ActionResult ProductDetail(int? id)
        {
            List<Products> products = new List<Products>();
            if (id == null)
            {
                return NotFound();
            }

            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            products = HttpContext.Session.Get<List<Products>>("products");
            if (products == null)
            {
                products = new List<Products>();
            }
            products.Add(product);
            HttpContext.Session.Set("products", products);
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Удаление товара из корзины.

        //GET Remove action methdo
        [ActionName("Remove")]
        public IActionResult RemoveToCart(int? id)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]

        public IActionResult Remove(int? id)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                var product = products.FirstOrDefault(c => c.Id == id);
                if (product != null)
                {
                    products.Remove(product);
                    HttpContext.Session.Set("products", products);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region Получение корзины.

        //GET product Cart action method
        public IActionResult Cart()
        {                        
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");            
            if (products == null)
            {
                products = new List<Products>();
            }
            return View(products);
        }
        #endregion
    }
}
