using e_commerce.Data;
using e_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private ApplicationContext _db;

        public ProductTypesController(ApplicationContext db)
        {
            _db = db;
        }

        #region Возврат

        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

        //POST Index action method
        [HttpPost]
        public IActionResult Index(string category)
        {
            var productTypes = _db.ProductTypes.Where(c => c.ProductType == category).ToList();

            if (category == null)
            {
                productTypes = _db.ProductTypes.ToList();
            }

            return View(productTypes);
        }

        #endregion

        #region Создание типа продукта.

        //Create Get action Method
        public ActionResult Create()
        {
            return View();
        }

        //Create Post action Method
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }

        #endregion

        #region Редактирование типа продукта.

        //Edit Get action Method
        public ActionResult Edit(int? id)
        {
            var productType = _db.ProductTypes.Find(id);

            if (id == null)
                return NotFound();

            if (productType == null)
                return NotFound();

            return View(productType);
        }

        //Edit Post action Method
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }

        #endregion

        #region Удаление типа продукта

        //Delete Get action Method
        public ActionResult Delete(int? id)
        {
            var productType = _db.ProductTypes.Find(id);

            if (id == null)
                return NotFound();

            if (productType == null)
                return NotFound();

            return View(productType);
        }

        //Delete Post action Method
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Delete(int? id, ProductTypes productTypes)
        {
            var productType = _db.ProductTypes.Find(id);

            if (id == null)
                return NotFound();

            if (id != productTypes.Id)
                return NotFound();

            if (productType == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                _db.ProductTypes.Remove(productType);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }

        #endregion
    }
}