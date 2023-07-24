using System.ComponentModel.DataAnnotations;

namespace e_commerce.Areas.Admin.Models
{
    public class UserRoleVM
    {
        [Required]
        [Display(Name = "User")]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string RoleId { get; set; }
    }
}
