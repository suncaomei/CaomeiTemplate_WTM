using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace Caomei.ViewModel.Admin.FrameworkUserVMs
{
    public partial class FrameworkUserSearcher : BaseSearcher
    {
        [Display(Name = "FrameworkUser.ITCode")]
        public string ITCode { get; set; }

        [Display(Name = "FrameworkUser.Name")]
        public string Name { get; set; }

        [Display(Name = "Sys.IsValid")]
        public bool? IsValid { get; set; }

        protected override void InitVM()
        {
        }
    }
}