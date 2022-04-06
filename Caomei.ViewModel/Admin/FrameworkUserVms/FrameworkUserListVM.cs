using Caomei.Core;
using Caomei.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Caomei.ViewModel.Admin.FrameworkUserVMs
{
    public partial class FrameworkUserListVM : BasePagedListVM<FrameworkUser_View, FrameworkUserSearcher>
    {
        protected override IEnumerable<IGridColumn<FrameworkUser_View>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkUser_View>>{
                this.MakeGridHeader(x => x.ITCode),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Gender),
                this.MakeGridHeader(x => x.CellPhone),
                this.MakeGridHeader(x => x.FrameworkUser_Role),
                this.MakeGridHeader(x => x.FrameworkUser_Group),
                this.MakeGridHeader(x => x.IsValid),
                this.MakeGridHeader(x => x.PhotoId),

                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<FrameworkUser_View> GetSearchQuery()
        {
            var query = DC.Set<FrameworkUser>()

                .CheckContain(Searcher.ITCode, x => x.ITCode)
                .CheckContain(Searcher.Name, x => x.Name)
                .CheckEqual(Searcher.IsValid, x => x.IsValid)
                .Select(x => new FrameworkUser_View
                {
                    ID = x.ID,

                    ITCode = x.ITCode,
                    Name = x.Name,
                    Gender = x.Gender,
                    CellPhone = x.CellPhone,
                    FrameworkUser_Role = DC.Set<FrameworkUserRole>().Where(y => y.UserCode == x.ITCode)
                        .Join(DC.Set<FrameworkRole>(), ur => ur.RoleCode, role => role.RoleCode, (ur, role) => role).Select(y0 => y0.RoleName).ToSepratedString(null, ","),
                    FrameworkUser_Group = DC.Set<FrameworkUserGroup>().Where(y => y.UserCode == x.ITCode)
                        .Join(DC.Set<FrameworkGroup>(), ug => ug.GroupCode, group => group.GroupCode, (ug, group) => group).Select(y0 => y0.GroupName).ToSepratedString(null, ","),
                    IsValid = x.IsValid,
                    PhotoId = x.PhotoId,
                })
                .OrderBy(x => x.ID);
            return query;
        }
    }

    public class FrameworkUser_View : FrameworkUser
    {
        //public string FrameworkUser_ITCode { get; set; }
        //public string FrameworkUser_Name { get; set; }
        //public GenderEnum? FrameworkUser_Gender { get; set; }
        //public string FrameworkUser_CellPhone { get; set; }
        public string FrameworkUser_Role { get; set; }

        public string FrameworkUser_Group { get; set; }
        //public bool? FrameworkUser_IsValid { get; set; }
        //public Guid? FrameworkUser_Photo { get; set; }
    }
}