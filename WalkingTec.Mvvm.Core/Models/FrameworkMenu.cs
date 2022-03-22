using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkingTec.Mvvm.Core
{
    /// <summary>
    /// FrameworkMenu
    /// </summary>
    [Table("FrameworkMenus")]
    public class FrameworkMenu : TreePoco<FrameworkMenu>
    {
        [Display(Name = "Sys.PageName")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public string PageName { get; set; }

        [Display(Name = "Sys.ActionName")]
        public string ActionName { get; set; }

        [Display(Name = "Codegen.ModuleName")]
        public string ModuleName { get; set; }

        [Display(Name = "Sys.FolderOnly")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public bool FolderOnly { get; set; }

        [Display(Name = "Sys.IsInherit")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public bool IsInherit { get; set; }

        [Display(Name = "Sys.Privileges")]
        public List<FunctionPrivilege> Privileges { get; set; }

        /// <summary>
        /// ClassName
        /// </summary>
        /// <value></value>
        public string ClassName { get; set; }

        /// <summary>
        /// MethodName
        /// </summary>
        /// <value></value>
        public string MethodName { get; set; }

        [Display(Name = "Sys.Domain")]
        public string Domain { get; set; }

        [Display(Name = "Sys.ShowOnMenu")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public bool ShowOnMenu { get; set; }

        [Display(Name = "Sys.IsPublic")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public bool IsPublic { get; set; }

        [Display(Name = "Sys.DisplayOrder")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public int? DisplayOrder { get; set; }

        [Display(Name = "Sys.IsInside")]
        [Required(ErrorMessage = "Validate.{0}required")]
        public bool? IsInside { get; set; }

        /// <summary>
        /// Url
        /// </summary>
        /// <value></value>
        public string Url { get; set; }

        [Display(Name = "Sys.Icon")]
        [StringLength(50)]
        public string Icon { get; set; }
    }
}