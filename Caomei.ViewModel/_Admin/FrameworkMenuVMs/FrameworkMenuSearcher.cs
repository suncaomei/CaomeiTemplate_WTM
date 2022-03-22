using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.FrameworkMenuVMs
{
    public enum FrameworkMenuMode
    { Normal = 0, RoleMode = 1, RoleSetMode = 2 }

    public class FrameworkMenuSearcher : BaseSearcher
    {
        [Display(Name = "Sys.PageName")]
        public string PageName { get; set; }

        [Display(Name = "Codegen.ModuleName")]
        public string ModuleName { get; set; }

        [Display(Name = "Sys.ActionName")]
        public string ActionName { get; set; }

        [Display(Name = "Sys.ShowOnMenu")]
        public bool? ShowOnMenu { get; set; }

        [Display(Name = "Sys.IsPublic")]
        public bool? IsPublic { get; set; }

        [Display(Name = "Sys.FolderOnly")]
        public bool? FolderOnly { get; set; }

        public Guid? RoleID { get; set; }
    }
}