using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkingTec.Mvvm.Core
{
    /// <summary>
    /// DataPrivilege
    /// </summary>
    [Table("DataPrivileges")]
    public class DataPrivilege : BasePoco
    {
        [Display(Name = "Sys.User")]
        public string UserCode { get; set; }

        [Display(Name = "Sys.Group")]
        public string GroupCode { get; set; }

        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Display(Name = "Sys.TableName")]
        public string TableName { get; set; }

        public string RelateId { get; set; }

        [Display(Name = "Sys.Domain")]
        public string Domain { get; set; }
    }
}