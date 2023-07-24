using System.Linq;
using e_commerce.Data;
using e_commerce.Models;
using e_commerce.Utility;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace e_commerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class OrderController : Controller
    {
        private ApplicationContext _db;

        public OrderController(ApplicationContext db)
        {
            _db = db;
        }

        #region Просмотр заказа

        //GET Checkout actioin method
        public IActionResult Checkout()
        {
            return View();
        }

        //POST Checkout action method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Checkout(Order anOrder)
        {
            List<Products> products = HttpContext.Session.Get<List<Products>>("products");
            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.PorductId = product.Id;
                    anOrder.OrderDetails.Add(orderDetails);
                }
            }

            anOrder.OrderNo = GetOrderNo();
            _db.Orders.Add(anOrder);
            await _db.SaveChangesAsync();
            HttpContext.Session.Set("products", new List<Products>());
            return View();
        }
        #endregion


        /// <summary>
        /// Возвращает номер заказа.
        /// </summary>        
        public string GetOrderNo()
        {
            int rowCount = _db.Orders.ToList().Count() + 1;
            return rowCount.ToString("000");
        }
    }
}
