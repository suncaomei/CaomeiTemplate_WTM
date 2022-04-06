// WTM默认页面 Wtm buidin page
using Caomei.Core;

namespace Caomei.ViewModel.Admin.ViewModels.FrameworkRoleVMs
{
    public class FrameworkRoleBatchVM : BaseBatchVM<FrameworkRole, BaseVM>
    {
        public FrameworkRoleBatchVM()
        {
            ListVM = new FrameworkRoleListVM();
        }
    }
}