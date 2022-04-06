using Caomei.Core;
using Caomei.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Caomei.ViewModel.Admin.FrameworkUserVMs
{
    public partial class FrameworkUserVM : BaseCRUDVM<FrameworkUser>
    {
        [Display(Name = "Model.FrameworkRole")]
        public List<string> SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs { get; set; }

        [Display(Name = "Model.FrameworkGroup")]
        public List<string> SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs { get; set; }

        public FrameworkUserVM()
        {
        }

        protected override void InitVM()
        {
            SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs = DC.Set<FrameworkUserRole>().Where(y => y.UserCode == Entity.ITCode).Join(DC.Set<FrameworkRole>(), ur => ur.RoleCode, role => role.RoleCode, (ur, role) => role.GetID().ToString()).ToList();
            SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs = DC.Set<FrameworkUserGroup>().Where(y => y.UserCode == Entity.ITCode).Join(DC.Set<FrameworkGroup>(), ur => ur.GroupCode, group => group.GroupCode, (ur, group) => group.GetID().ToString()).ToList();
        }

        public override DuplicatedInfo<FrameworkUser> SetDuplicatedCheck()
        {
            var rv = CreateFieldsInfo(SimpleField(x => x.ITCode));
            return rv;
        }

        public override async Task DoAddAsync()
        {
            if (SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs != null)
            {
                List<Guid> todelete = new List<Guid>();
                todelete.AddRange(DC.Set<FrameworkUserRole>().AsNoTracking().Where(x => x.UserCode == Entity.ITCode).Select(x => x.ID));
                foreach (var item in todelete)
                {
                    DC.DeleteEntity(new FrameworkUserRole { ID = item });
                }
                var codes = DC.Set<FrameworkRole>().AsNoTracking().CheckIDs(SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs).Select(x => x.RoleCode).ToList();
                foreach (var id in codes)
                {
                    FrameworkUserRole r = new FrameworkUserRole
                    {
                        RoleCode = id,
                        UserCode = Entity.ITCode
                    };
                    DC.AddEntity(r);
                }
            }

            if (SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs != null)
            {
                List<Guid> todelete = new List<Guid>();
                todelete.AddRange(DC.Set<FrameworkUserGroup>().AsNoTracking().Where(x => x.UserCode == Entity.ITCode).Select(x => x.ID));
                foreach (var item in todelete)
                {
                    DC.DeleteEntity(new FrameworkUserGroup { ID = item });
                }
                var codes = DC.Set<FrameworkGroup>().AsNoTracking().CheckIDs(SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs).Select(x => x.GroupCode).ToList();
                foreach (var id in codes)
                {
                    FrameworkUserGroup g = new FrameworkUserGroup
                    {
                        GroupCode = id,
                        UserCode = Entity.ITCode
                    };
                    DC.AddEntity(g);
                }
            }

            await base.DoAddAsync();
        }

        public override async Task DoEditAsync(bool updateAllFields = false)
        {
            if (SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs != null)
            {
                List<Guid> todelete = new List<Guid>();
                todelete.AddRange(DC.Set<FrameworkUserRole>().AsNoTracking().Where(x => x.UserCode == Entity.ITCode).Select(x => x.ID));
                foreach (var item in todelete)
                {
                    DC.DeleteEntity(new FrameworkUserRole { ID = item });
                }
                var codes = DC.Set<FrameworkRole>().AsNoTracking().CheckIDs(SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs).Select(x => x.RoleCode).ToList();
                foreach (var id in codes)
                {
                    FrameworkUserRole r = new FrameworkUserRole
                    {
                        RoleCode = id,
                        UserCode = Entity.ITCode
                    };
                    DC.AddEntity(r);
                }
            }

            if (SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs != null)
            {
                List<Guid> todelete = new List<Guid>();
                todelete.AddRange(DC.Set<FrameworkUserGroup>().AsNoTracking().Where(x => x.UserCode == Entity.ITCode).Select(x => x.ID));
                foreach (var item in todelete)
                {
                    DC.DeleteEntity(new FrameworkUserGroup { ID = item });
                }
                var codes = DC.Set<FrameworkGroup>().AsNoTracking().CheckIDs(SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs).Select(x => x.GroupCode).ToList();
                foreach (var id in codes)
                {
                    FrameworkUserGroup g = new FrameworkUserGroup
                    {
                        GroupCode = id,
                        UserCode = Entity.ITCode
                    };
                    DC.AddEntity(g);
                }
            }

            await base.DoEditAsync();
            await Wtm.RemoveUserCache(Entity.ITCode);
        }

        public override async Task DoDeleteAsync()
        {
            await base.DoDeleteAsync();
        }
    }
}