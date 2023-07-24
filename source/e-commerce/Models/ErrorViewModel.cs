
namespace e_commerce.Models
{
    public class ErrorViewModel
    {
        /// <summary>
        /// Id запроса.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Видемость Id запроса.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}