using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caomei.Core
{
    [Table("FrameworkUserGroups")]
    public class FrameworkUserGroup : BasePoco
    {
        [Required]
        public string UserCode { get; set; }

        [Display(Name = "FrameworkUser.Group")]
        [Required]
        public string GroupCode { get; set; }
    }
}