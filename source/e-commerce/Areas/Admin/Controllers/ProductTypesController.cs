using System.Linq;
using e_commerce.Data;
using e_commerce.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

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
                //TempData["save"] = "Product type has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }
        #endregion

        #region Редактирование типа продукта.

        //Edit Get action Method
        public ActionResult Edit(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            var productType = _db.ProductTypes.Find(id);

            if (productType==null)
            {
                return NotFound();
            }
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
                TempData["save"] = "Product type has been saved";
                return RedirectToAction(nameof(Index));
            }
            return View(productTypes);
        }
        #endregion

        #region Получение информации о типе продукта.

        //Details Get action Method
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _db.ProductTypes.Find(id);

            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        //Details Post action Method
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Details(ProductTypes productTypes)
        {
            return RedirectToAction(nameof(Index));
        }
        #endregion

        #region Удаление типа продукта

        //Delete Get action Method
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productType = _db.ProductTypes.Find(id);

            if (productType == null)
            {
                return NotFound();
            }
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
                TempData["save"] = "Product type has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }
        #endregion
    }
}
