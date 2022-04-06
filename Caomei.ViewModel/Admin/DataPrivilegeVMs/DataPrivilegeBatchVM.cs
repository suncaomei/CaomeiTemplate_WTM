// WTM默认页面 Wtm buidin page
using Caomei.Core;

namespace Caomei.ViewModel.Admin.ViewModels.DataPrivilegeVMs
{
    public class DataPrivilegeBatchVM : BaseBatchVM<DataPrivilege, DataPrivilege_BatchEdit>
    {
        public DataPrivilegeBatchVM()
        {
            ListVM = new DataPrivilegeListVM();
            LinkedVM = new DataPrivilege_BatchEdit();
        }
    }

    public class DataPrivilege_BatchEdit : BaseVM
    {
    }
}