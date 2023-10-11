namespace e_commerce.Models
{
    /// <summary>
    /// Класс сессии пользователя.
    /// </summary>
    public class SessionUserVm
    {
        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Роль пользователя.
        /// </summary>
        public string RoleName { get; set; }
    }
}