using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkingTec.Mvvm.Core
{
    [Table("FrameworkUserRoles")]
    public class FrameworkUserRole : BasePoco
    {
        [Required]
        public string UserCode { get; set; }

        [Required]
        [Display(Name = "Sys.Role")]
        public string RoleCode { get; set; }
    }
}