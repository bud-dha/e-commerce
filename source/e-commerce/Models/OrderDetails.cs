using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce.Models
{
    /// <summary>
    /// Класс деталей о заказе.
    /// </summary>
    public class OrderDetails
    {
        public int Id { get; set; }

        /// <summary>
        /// Id заказа.
        /// </summary>
        [Display(Name = "Order")]
        public int OrderId { get; set; }

        /// <summary>
        /// Id товара.
        /// </summary>
        [Display(Name = "Product")]
        public int PorductId { get; set; }

        /// <summary>
        /// Заказ.
        /// </summary>
        [ForeignKey("OrderId")]
        public Order Order { get; set; }

        /// <summary>
        /// Товар.
        /// </summary>
        [ForeignKey("PorductId")]
        public Products Product { get; set; }
    }
}
