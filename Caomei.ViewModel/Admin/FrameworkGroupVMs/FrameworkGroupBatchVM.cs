// WTM默认页面 Wtm buidin page
using Caomei.Core;

namespace Caomei.ViewModel.Admin.ViewModels.FrameworkGroupVMs
{
    public class FrameworkGroupBatchVM : BaseBatchVM<FrameworkGroup, BaseVM>
    {
        public FrameworkGroupBatchVM()
        {
            ListVM = new FrameworkGroupListVM();
        }
    }
}