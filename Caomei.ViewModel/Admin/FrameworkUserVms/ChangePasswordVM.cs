// WTM默认页面 Wtm buidin page
using Caomei.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Caomei.ViewModel.Admin.ViewModels.FrameworkUserVms
{
    public class ChangePasswordVM : BaseVM
    {
        [Display(Name = "FrameworkUser.ITCode")]
        public string ITCode { get; set; }

        [Display(Name = "Sys.OldPassword")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string OldPassword { get; set; }

        [Display(Name = "Sys.NewPassword")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string NewPassword { get; set; }

        [Display(Name = "Sys.NewPasswordComfirm")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string NewPasswordComfirm { get; set; }

        public override void Validate()
        {
            List<ValidationResult> rv = new List<ValidationResult>();
            if (DC.Set<FrameworkUser>().Where(x => x.ITCode == LoginUserInfo.ITCode && x.Password == Utils.GetMD5String(OldPassword)).SingleOrDefault() == null)
            {
                MSD.AddModelError("OldPassword", Localizer["Sys.OldPasswrodWrong"]);
            }
            if (NewPassword != NewPasswordComfirm)
            {
                MSD.AddModelError("NewPasswordComfirm", Localizer["Sys.PasswordNotSame"]);
            }
        }

        public void DoChange()
        {
            var user = DC.Set<FrameworkUser>().Where(x => x.ITCode == LoginUserInfo.ITCode).SingleOrDefault();
            if (user != null)
            {
                user.Password = Utils.GetMD5String(NewPassword);
            }
            DC.SaveChanges();
        }
    }
}