namespace e_commerce.Areas.Admin.Models
{
    public class UserRoleMaping
    {
        /// <summary>
        /// Id пользователя.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Id роли.
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Название роли.
        /// </summary>
        public string RoleName { get; set; }

    }
}