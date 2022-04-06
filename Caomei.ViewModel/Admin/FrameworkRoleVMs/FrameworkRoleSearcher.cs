// WTM默认页面 Wtm buidin page
using Caomei.Core;
using System.ComponentModel.DataAnnotations;

namespace Caomei.ViewModel.Admin.ViewModels.FrameworkRoleVMs
{
    public class FrameworkRoleSearcher : BaseSearcher
    {
        [Display(Name = "FrameworkUser.RoleCode")]
        public string RoleCode { get; set; }

        [Display(Name = "FrameworkUser.RoleName")]
        public string RoleName { get; set; }
    }
}