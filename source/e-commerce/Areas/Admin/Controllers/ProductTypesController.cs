using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_commerce.Models;

namespace e_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Create Get action Method
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
                //_db.ProductTypes.Add(productTypes);
                //await _db.SaveChangesAsync();
                TempData["save"] = "Product type has been saved";
                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }
    }
}
