using System.ComponentModel.DataAnnotations;
using System.Linq;
using WalkingTec.Mvvm.Core;

namespace Caomei.ViewModel.HomeVMs
{
    public class RegVM : BaseVM
    {
        [Display(Name = "Sys.Account")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string ITCode { get; set; }

        [Display(Name = "Sys.Name")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Name { get; set; }

        [Display(Name = "Sys.Password")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Password { get; set; }

        [Display(Name = "Sys.NewPasswordComfirm")]
        [Required(AllowEmptyStrings = false)]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string NewPasswordComfirm { get; set; }

        /// <summary>
        /// 进行登录
        /// </summary>
        /// <returns>登录用户的信息</returns>
        public bool DoReg()
        {
            //检查两次新密码是否输入一致，如不一致则输出错误
            if (Password != NewPasswordComfirm)
            {
                MSD.AddModelError("", "两次密码不一致");
                return false;
            }

            //检查itcode是否重复
            var exist = DC.Set<FrameworkUser>().Any(x => x.ITCode.ToLower() == ITCode.ToLower());

            if (exist == true)
            {
                MSD.AddModelError("", Localizer["Sys.ItcodeDuplicate"]);
                return false;
            }

            FrameworkUser user = new FrameworkUser
            {
                ITCode = ITCode,
                Name = Name,
                Password = Utils.GetMD5String(Password),
                IsValid = true,
                //ExpiryTime = System.DateTime.Now.AddHours(24)
            };

            DC.Set<FrameworkUser>().Add(user);
            DC.SaveChanges();
            return true;
        }
    }
}