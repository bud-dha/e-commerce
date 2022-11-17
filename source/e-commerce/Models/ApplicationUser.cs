using Microsoft.AspNetCore.Identity;

namespace e_commerce.Models
{
    public class ApplicationUser : IdentityUser
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия пользователя.
        /// </summary>
        public string LastName { get; set; }
    }
}
