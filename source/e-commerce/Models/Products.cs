using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Models
{
    /// <summary>
    /// Класс продута.
    /// </summary>
    public class Products
    {
        /// <summary>
        /// Id продукта.
        /// </summary>       
        public int Id { get; set; }

        /// <summary>
        /// Название продукта.
        /// </summary>
        [Required]
        [Display(Name = "Название")]
        public string Name { get; set; }

        /// <summary>
        /// Цена продукта.
        /// </summary>
        [Required]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        /// <summary>
        /// Фото продукта.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Цвет продукта.
        /// </summary>
        [Display(Name = "Цвет")]
        public string ProductColor { get; set; }

        /// <summary>
        /// Наличие продукта.
        /// </summary>
        [Required]
        [Display(Name = "Наличие")]
        public bool IsAvailable { get; set; }

        /// <summary>
        /// Id типа продукта.
        /// </summary>              
        [Required]
        [Display(Name = "Тип продукта")]
        public int ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public ProductTypes ProductTypes { get; set; }
    }
}
