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

        public IActionResult Index()
        {
            ViewData["productTypeId"] = new SelectList(_db.ProductTypes.ToList(), "Id", "ProductType");            
            return View(_db.Products.Include(c=>c.ProductTypes).ToList());
        }

        #region Создание продукта

        //Create Get action Method
        public IActionResult Create()
        {
            return View();
        }

        //Create Get action Method
        [HttpPost]
        public async Task<IActionResult> Create(Products products, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    var name = Path.Combine(_he.WebRootPath + "Images", Path.GetFileName(image.FileName));
                    await image.CopyToAsync(new FileStream(name, FileMode.Create));
                    products.Image = "Images/" + image.FileName;
                }

                if (image == null)
                {
                    products.Image = "Images/noimage.jpg";
                }
                _db.Products.Add(products);
                await _db.SaveChangesAsync();
                //TempData["save"] = "Product type has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(products);
        }
        #endregion

        #region Редактирование продукта.

        //Edit Get action Method
        public ActionResult Edit()
        {            
            return View();
        }

        //Edit Post action Method
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(Products products)
        {            
            return View();
        }
        #endregion

        #region Получение информации о продукте.

        //Details Get action Method
        public ActionResult Details()
        {
            return View();
        }

        //Details Post action Method
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Details(Products products)
        {
            return View();
        }
        #endregion

        #region Удаление продукта.

        //Delete Get action Method
        public ActionResult Delete()
        {
            return View();
        }

        //Delete Post action Method
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(Products products)
        {
            return View();
        }
        #endregion
    }
}
