using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caomei.Core
{
    /// <summary>
    /// FunctionPrivilege
    /// </summary>
    [Table("FunctionPrivileges")]
    public class FunctionPrivilege : BasePoco
    {
        [Display(Name = "FrameworkUser.Role")]
        public string RoleCode { get; set; }

        [Display(Name = "Sys.MenuItem")]
        public Guid MenuItemId { get; set; }

        [Display(Name = "Sys.MenuItem")]
        public FrameworkMenu MenuItem { get; set; }

        [Display(Name = "Sys.Allowed")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public bool? Allowed { get; set; }
    }
}