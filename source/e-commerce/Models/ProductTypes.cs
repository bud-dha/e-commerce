using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    /// <summary>
    /// Класс типа продукта.
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
        [Display(Name = "Тип продукта")]
        public string ProductType { get; set; } = "Пельмени";
    }
}
