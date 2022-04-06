// WTM默认页面 Wtm buidin page
using Caomei.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caomei.ViewModel.Admin.ViewModels.FrameworkMenuVMs
{
    public class FrameworkMenuBatchVM : BaseBatchVM<FrameworkMenu, FrameworkMenu_BatchEdit>
    {
        public FrameworkMenuBatchVM()
        {
        }

        protected override void InitVM()
        {
        }

        public override bool DoBatchDelete()
        {
            if (Ids != null)
            {
                foreach (var item in Ids)
                {
                    FrameworkMenu f = new FrameworkMenu { ID = Guid.Parse(item) };
                    DC.CascadeDelete(f);
                }
            }
            DC.SaveChanges();
            return true;
        }
    }

    public class FrameworkMenu_BatchEdit : BaseVM
    {
        public List<Guid> IDs { get; set; }

        [Display(Name = "Sys.ShowOnMenu")]
        public bool ShowOnMenu { get; set; }

        [Display(Name = "Sys.ParentFolder")]
        public Guid? ParentId { get; set; }

        public List<ComboSelectListItem> AllParents { get; set; }

        [Display(Name = "Sys.Icon")]
        public string Icon { get; set; }
    }
}