using System.IO;
using System.Linq;
using e_commerce.Data;
using e_commerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace e_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {       
        private ApplicationContext _db;
        private IWebHostEnvironment _he;

        public ProductController(ApplicationContext db, IWebHostEnvironment he)
        {
            _db = db;
            _he = he;
        }

        #region Возврат

        public IActionResult Index()
        {                      
            return View(_db.Products.Include(c=>c.ProductTypes).ToList());
        }

        /* Сортировка
        //POST Index action method
        [HttpPost]
        public IActionResult Index(decimal? lowAmount, decimal? largeAmount)
        {
            var products = _db.Products.Include(c => c.ProductTypes).Where(c => c.Price >= lowAmount && c.Price <= largeAmount).ToList();

            if (lowAmount == null || largeAmount == null)            
                products = _db.Products.Include(c => c.ProductTypes).ToList();            

            return View(products);
        }
        */

        #endregion

        #region Создание продукта

        //Create Get action Method
        public ActionResult Create()
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");

            return View();
        }

        //Create Get action Method
        [HttpPost]
        public async Task<IActionResult> Create(Products product, IFormFile image)
        {
            var searchProduct = _db.Products.FirstOrDefault(c => c.Name == product.Name);

            if (searchProduct != null)
            {
                ViewBag.message = "Этот продукт уже существует";
                ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
                return View(product);
            }

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images/Custom/", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    product.Image = "/Images/Custom/" + image.FileName;                   
                }

                if (image == null)                
                    product.Image = "Images/noimage.png";                      

                _db.Products.Add(product);
                await _db.SaveChangesAsync();                
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
        #endregion

        #region Редактирование продукта.

        //Edit Get action Method
        public ActionResult Edit(int? id)
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");
            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);

            if (id == null)            
                return NotFound();            
            
            if (product == null)            
                return NotFound();            

            return View(product);
        }

        //Edit Post action Method
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Products product, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "/Images/Custom/", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    product.Image = "/Images/Custom/" + image.FileName;
                }

                if (image == null)                
                    product.Image = "Images/noimage.png";                

                _db.Products.Update(product);
                await _db.SaveChangesAsync();                
                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }
        #endregion

        #region Получение информации о продукте.

        //Details Get action Method
        public ActionResult Details(int? id)
        {
            var product = _db.Products.Include(c => c.ProductTypes).FirstOrDefault(c => c.Id == id);

            if (id == null)            
                return NotFound();         
            
            if (product == null)            
                return NotFound();            

            return View(product);
        }

        #endregion

        #region Удаление продукта.

        //Delete Get action Method
        public ActionResult Delete(int? id)
        {
            var product = _db.Products.Include(c => c.ProductTypes).Where(c => c.Id == id).FirstOrDefault();

            if (id == null)            
                return NotFound();            

            if (product == null)            
                return NotFound();  
            
            return View(product);
        }

        //Delete Post action Method
        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int? id)
        {
            var product = _db.Products.FirstOrDefault(c => c.Id == id);

            if (id == null)            
                return NotFound();            
            
            if (product == null)            
                return NotFound();            

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
