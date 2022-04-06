using Caomei.Core;
using Caomei.Core.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Caomei.Model
{
    public class _PlaceHolder_
    {
    }

    [MiddleTable]
    public class FrameworkRoleFrameworkUser_MT_Wtm : BasePoco
    {
        [Display(Name = "Model.FrameworkRole")]
        public FrameworkRole FrameworkRole { get; set; }

        [Display(Name = "Model.FrameworkRole")]
        public Guid? FrameworkRoleId { get; set; }

        [Display(Name = "Model.FrameworkUser")]
        public FrameworkUser FrameworkUser { get; set; }

        [Display(Name = "Model.FrameworkUser")]
        public Guid? FrameworkUserId { get; set; }
    }

    [MiddleTable]
    public class FrameworkGroupFrameworkUser_MT_Wtm : BasePoco
    {
        [Display(Name = "Model.FrameworkGroup")]
        public FrameworkGroup FrameworkGroup { get; set; }

        [Display(Name = "Model.FrameworkGroup")]
        public Guid? FrameworkGroupId { get; set; }

        [Display(Name = "Model.FrameworkUser")]
        public FrameworkUser FrameworkUser { get; set; }

        [Display(Name = "Model.FrameworkUser")]
        public Guid? FrameworkUserId { get; set; }
    }
}