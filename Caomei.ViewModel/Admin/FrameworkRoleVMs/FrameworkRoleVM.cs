// WTM默认页面 Wtm buidin page
using Caomei.Core;

namespace Caomei.ViewModel.Admin.ViewModels.FrameworkRoleVMs
{
    public class FrameworkRoleVM : BaseCRUDVM<FrameworkRole>
    {
        public override DuplicatedInfo<FrameworkRole> SetDuplicatedCheck()
        {
            var rv = CreateFieldsInfo(SimpleField(x => x.RoleName));
            rv.AddGroup(SimpleField(x => x.RoleCode));
            return rv;
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            if (FC.ContainsKey("Entity.RoleCode"))
            {
                FC.Remove("Entity.RoleCode");
            }
            base.DoEdit(updateAllFields);
        }
    }
}