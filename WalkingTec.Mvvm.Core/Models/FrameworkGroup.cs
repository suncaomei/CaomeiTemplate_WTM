using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkingTec.Mvvm.Core
{
    [Table("FrameworkGroups")]
    public class FrameworkGroup : BasePoco
    {
        [Display(Name = "Sys.GroupCode")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Validate.{0}number")]
        [StringLength(100, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string GroupCode { get; set; }

        [Display(Name = "Sys.GroupName")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string GroupName { get; set; }

        [Display(Name = "Sys.Remark")]
        public string GroupRemark { get; set; }

        [NotMapped]
        [Display(Name = "Sys.UsersCount")]
        public int UsersCount { get; set; }

        [Display(Name = "Sys.Tenant")]
        public string TenantCode { get; set; }
    }
}