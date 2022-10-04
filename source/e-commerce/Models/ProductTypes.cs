using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Models
{
    public class ProductTypes
    {
        /// <summary>
        /// Id типа продукта.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип продукта.
        /// </summary>
        public string ProductType { get; set; }
    }
}
