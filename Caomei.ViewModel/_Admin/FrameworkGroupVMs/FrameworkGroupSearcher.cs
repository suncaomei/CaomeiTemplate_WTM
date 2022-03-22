using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.FrameworkGroupVMs
{
    public class FrameworkGroupSearcher : BaseSearcher
    {
        [Display(Name = "Sys.GroupCode")]
        public string GroupCode { get; set; }

        [Display(Name = "Sys.GroupName")]
        public string GroupName { get; set; }
    }
}