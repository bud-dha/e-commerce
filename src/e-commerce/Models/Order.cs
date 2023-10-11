using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace e_commerce.Models
{
    /// <summary>
    /// Класс заказа.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Id заказа.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер заказа.
        /// </summary>
        [Display(Name = "Order No")]
        public string OrderNo { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Номер телефона.
        /// </summary>
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Адрес электронной почты.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Адрес проживания.
        /// </summary>
        [Required]
        public string Address { get; set; }

        /// <summary>
        /// Дата заказа.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Детали заказа.
        /// </summary>
        public virtual List<OrderDetails> OrderDetails { get; set; }


        /// <summary>
        /// Создает экземпляр класса.
        /// </summary>
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
    }
}