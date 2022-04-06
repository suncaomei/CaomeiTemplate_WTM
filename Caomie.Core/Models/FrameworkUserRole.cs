using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caomei.Core
{
    [Table("FrameworkUserRoles")]
    public class FrameworkUserRole : BasePoco
    {
        [Required]
        public string UserCode { get; set; }

        [Required]
        [Display(Name = "FrameworkUser.Role")]
        public string RoleCode { get; set; }
    }
}