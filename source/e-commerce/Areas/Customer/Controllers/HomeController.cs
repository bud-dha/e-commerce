using System.IO;
using System.Linq;
using e_commerce.Data;
using e_commerce.Models;
using System.Diagnostics;
using e_commerce.Utility;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


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

        #region Получение информации о типе продукта.

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
            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);
            products = HttpContext.Session.Get<List<Products>>("products");

            if (id == null)            
                return NotFound();            
            
            if (product == null)            
                return NotFound();            
            
            if (products == null)            
                products = new List<Products>();          
                
            products.Add(product);
            HttpContext.Session.Set("products", products);
            return RedirectToAction(nameof(Index));
        }
        #endregion


        public ActionResult List() // /home/list
        {
            return View();
        }

        public ActionResult Feedback() // /home/feedback
        {
            return View();
        }

    }
}
