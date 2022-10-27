using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    /// <summary>
    /// Класс типа товара.
    /// </summary>
    public class ProductTypes
    {
        /// <summary>
        /// Id типа продукта.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип продукта.
        /// </summary>
        [Required]
        [Display(Name = "Категория товара")]
        public string ProductType { get; set; }
    }
}
