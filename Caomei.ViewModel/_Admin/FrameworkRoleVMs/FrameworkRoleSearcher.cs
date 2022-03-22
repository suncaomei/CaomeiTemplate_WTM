using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.FrameworkRoleVMs
{
    public class FrameworkRoleSearcher : BaseSearcher
    {
        [Display(Name = "Sys.RoleCode")]
        public string RoleCode { get; set; }

        [Display(Name = "Sys.RoleName")]
        public string RoleName { get; set; }
    }
}