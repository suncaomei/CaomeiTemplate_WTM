// WTM默认页面 Wtm buidin page
using Caomei.Core;
using System.ComponentModel.DataAnnotations;

namespace Caomei.ViewModel.Admin.ViewModels.FrameworkGroupVMs
{
    public class FrameworkGroupSearcher : BaseSearcher
    {
        [Display(Name = "FrameworkUser.GroupCode")]
        public string GroupCode { get; set; }

        [Display(Name = "FrameworkUser.GroupName")]
        public string GroupName { get; set; }
    }
}