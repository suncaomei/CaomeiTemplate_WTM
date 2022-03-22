using WalkingTec.Mvvm.Core;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.FrameworkRoleVMs
{
    public class FrameworkRoleBatchVM : BaseBatchVM<FrameworkRole, BaseVM>
    {
        public FrameworkRoleBatchVM()
        {
            ListVM = new FrameworkRoleListVM();
        }
    }
}