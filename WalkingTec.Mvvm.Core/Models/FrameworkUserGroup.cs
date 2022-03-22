using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkingTec.Mvvm.Core
{
    [Table("FrameworkUserGroups")]
    public class FrameworkUserGroup : BasePoco
    {
        [Required]
        public string UserCode { get; set; }

        [Display(Name = "Sys.Group")]
        [Required]
        public string GroupCode { get; set; }
    }
}