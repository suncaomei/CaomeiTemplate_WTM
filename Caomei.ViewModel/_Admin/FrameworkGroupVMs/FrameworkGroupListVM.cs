using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.FrameworkGroupVMs
{
    public class FrameworkGroupListVM : BasePagedListVM<FrameworkGroup, FrameworkGroupSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("FrameworkGroup", GridActionStandardTypesEnum.Create, "","Admin", dialogWidth: 800),
                this.MakeStandardAction("FrameworkGroup", GridActionStandardTypesEnum.Edit, "","Admin", dialogWidth: 800),
                this.MakeStandardAction("FrameworkGroup", GridActionStandardTypesEnum.Delete, "", "Admin",dialogWidth: 800),
                this.MakeStandardAction("FrameworkGroup", GridActionStandardTypesEnum.BatchDelete, "","Admin", dialogWidth: 800),
                this.MakeStandardAction("FrameworkGroup", GridActionStandardTypesEnum.Import, "","Admin", dialogWidth: 800),
                this.MakeAction("FrameworkGroup","DataFunction",Localizer["DataPrivilege"],Localizer["Sys.DataPrivilege"], GridActionParameterTypesEnum.SingleId,"Admin",800,null,null,x=>x.GroupCode).SetShowInRow(),
                this.MakeStandardAction("FrameworkGroup", GridActionStandardTypesEnum.ExportExcel, "","Admin"),
            };
        }

        protected override IEnumerable<IGridColumn<FrameworkGroup>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkGroup>>{
                this.MakeGridHeader(x => x.GroupCode, 120),
                this.MakeGridHeader(x => x.GroupName, 120),
                this.MakeGridHeader(x => x.GroupRemark),
                this.MakeGridHeaderAction(width: 300)
            };
        }

        public override IOrderedQueryable<FrameworkGroup> GetSearchQuery()
        {
            var query = DC.Set<FrameworkGroup>()
                .CheckContain(Searcher.GroupCode, x => x.GroupCode)
                .CheckContain(Searcher.GroupName, x => x.GroupName)
                .OrderBy(x => x.GroupCode);
            return query;
        }
    }
}