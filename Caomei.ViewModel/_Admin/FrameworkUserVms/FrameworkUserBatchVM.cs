using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;

namespace Caomei.ViewModel.Admin.FrameworkUserVMs
{
    public partial class FrameworkUserBatchVM : BaseBatchVM<FrameworkUser, FrameworkUser_BatchEdit>
    {
        public FrameworkUserBatchVM()
        {
            ListVM = new FrameworkUserListVM();
            LinkedVM = new FrameworkUser_BatchEdit();
        }

        public override bool DoBatchEdit()
        {
            var entityList = DC.Set<FrameworkUser>().AsNoTracking().CheckIDs(Ids.ToList()).ToList();
            List<Guid> todelete = new List<Guid>();
            foreach (var entity in entityList)
            {
                if (LinkedVM.SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs != null)
                {
                    todelete = new List<Guid>();
                    todelete.AddRange(DC.Set<FrameworkUserRole>().AsNoTracking().Where(x => x.UserCode == entity.ITCode).Select(x => x.ID));
                    foreach (var item in todelete)
                    {
                        DC.DeleteEntity(new FrameworkUserRole { ID = item });
                    }
                    foreach (var id in LinkedVM.SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs)
                    {
                        FrameworkUserRole r = new FrameworkUserRole
                        {
                            RoleCode = id,
                            UserCode = entity.ITCode
                        };
                        DC.AddEntity(r);
                    }
                }

                if (LinkedVM.SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs != null)
                {
                    todelete = new List<Guid>();
                    todelete.AddRange(DC.Set<FrameworkUserGroup>().AsNoTracking().Where(x => x.UserCode == entity.ITCode).Select(x => x.ID));
                    foreach (var item in todelete)
                    {
                        DC.DeleteEntity(new FrameworkUserGroup { ID = item });
                    }
                    foreach (var id in LinkedVM.SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs)
                    {
                        FrameworkUserGroup r = new FrameworkUserGroup
                        {
                            GroupCode = id,
                            UserCode = entity.ITCode
                        };
                        DC.AddEntity(r);
                    }
                }
            }

            return base.DoBatchEdit();
        }
    }

    /// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class FrameworkUser_BatchEdit : BaseVM
    {
        [Display(Name = "FrameworkUser.Email")]
        public string Email { get; set; }

        [Display(Name = "Sys.Gender")]
        public GenderEnum? Gender { get; set; }

        [Display(Name = "Sys.Mobile")]
        public string CellPhone { get; set; }

        [Display(Name = "FrameworkUser.HomePhone")]
        public string HomePhone { get; set; }

        [Display(Name = "FrameworkUser.Address")]
        public string Address { get; set; }

        [Display(Name = "FrameworkUser.ZipCode")]
        public string ZipCode { get; set; }

        [Display(Name = "FrameworkUser.Role")]
        public Guid? RoleId { get; set; }

        [Display(Name = "FrameworkUser.Role")]
        public List<string> SelectedFrameworkRoleFrameworkUser_MT_WtmsIDs { get; set; }

        [Display(Name = "FrameworkUser.Group")]
        public Guid? GroupId { get; set; }

        [Display(Name = "FrameworkUser.Group")]
        public List<string> SelectedFrameworkGroupFrameworkUser_MT_WtmsIDs { get; set; }

        protected override void InitVM()
        {
        }
    }
}