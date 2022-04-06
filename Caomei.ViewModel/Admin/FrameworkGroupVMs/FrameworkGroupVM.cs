// WTM默认页面 Wtm buidin page
using Caomei.Core;

namespace Caomei.ViewModel.Admin.ViewModels.FrameworkGroupVMs
{
    public class FrameworkGroupVM : BaseCRUDVM<FrameworkGroup>
    {
        public override DuplicatedInfo<FrameworkGroup> SetDuplicatedCheck()
        {
            var rv = CreateFieldsInfo(SimpleField(x => x.GroupName));
            rv.AddGroup(SimpleField(x => x.GroupCode));
            return rv;
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            if (FC.ContainsKey("Entity.GroupCode"))
            {
                FC.Remove("Entity.GroupCode");
            }

            base.DoEdit(updateAllFields);
        }
    }
}