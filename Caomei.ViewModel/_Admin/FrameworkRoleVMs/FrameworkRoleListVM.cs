using System.Collections.Generic;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.FrameworkRoleVMs
{
    public class FrameworkRoleListVM : BasePagedListVM<FrameworkRole, FrameworkRoleSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("FrameworkRole", GridActionStandardTypesEnum.Create, "","Admin", dialogWidth: 800),
                this.MakeStandardAction("FrameworkRole", GridActionStandardTypesEnum.Edit, "","Admin", dialogWidth: 800),
                this.MakeStandardAction("FrameworkRole", GridActionStandardTypesEnum.Delete, "", "Admin",dialogWidth: 800),
                this.MakeStandardAction("FrameworkRole", GridActionStandardTypesEnum.Details, "","Admin", dialogWidth: 800),
                this.MakeStandardAction("FrameworkRole", GridActionStandardTypesEnum.BatchDelete, "","Admin", dialogWidth: 800),
                this.MakeStandardAction("FrameworkRole", GridActionStandardTypesEnum.Import, "","Admin", dialogWidth: 800),
                this.MakeAction("FrameworkRole","PageFunction",Localizer["Sys.PageFunction"],Localizer["Sys.PageFunction"], GridActionParameterTypesEnum.SingleId,"Admin",800).SetShowInRow(),
                this.MakeStandardAction("FrameworkRole", GridActionStandardTypesEnum.ExportExcel, "","Admin"),
            };
        }

        protected override IEnumerable<IGridColumn<FrameworkRole>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkRole>>{
                this.MakeGridHeader(x => x.RoleCode, 120),
                this.MakeGridHeader(x => x.RoleName, 120),
                this.MakeGridHeader(x => x.RoleRemark),
                this.MakeGridHeaderAction(width: 300)
            };
        }

        public override IOrderedQueryable<FrameworkRole> GetSearchQuery()
        {
            var query = DC.Set<FrameworkRole>()
                .CheckContain(Searcher.RoleCode, x => x.RoleCode)
                .CheckContain(Searcher.RoleName, x => x.RoleName)
                .Select(x => new FrameworkRole
                {
                    ID = x.ID,
                    RoleCode = x.RoleCode,
                    RoleName = Localizer[x.RoleName],
                    RoleRemark = x.RoleRemark,
                })//
                .OrderBy(x => x.RoleCode);
            return query;
        }
    }
}