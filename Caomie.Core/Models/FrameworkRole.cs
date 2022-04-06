using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caomei.Core
{
    /// <summary>
    /// FrameworkRole
    /// </summary>
    [Table("FrameworkRoles")]
    public class FrameworkRole : BasePoco
    {
        [Display(Name = "FrameworkUser.RoleCode")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Validate.{0}number")]
        [StringLength(100, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string RoleCode { get; set; }

        [Display(Name = "FrameworkUser.RoleName")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string RoleName { get; set; }

        [Display(Name = "Sys.Remark")]
        public string RoleRemark { get; set; }

        [Display(Name = "Sys.Tenant")]
        public string TenantCode { get; set; }

        [NotMapped]
        [Display(Name = "Sys.UsersCount")]
        public int UsersCount { get; set; }
    }
}