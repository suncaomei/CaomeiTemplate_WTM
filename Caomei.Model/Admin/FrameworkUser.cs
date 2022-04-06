using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Caomei.Core
{
    /// <summary>
    /// 用户
    /// </summary>
	[Table("FrameworkUsers")]
    [Display(Name = "Model.FrameworkUser")]
    public class FrameworkUser : FrameworkUserBase
    {
        [Display(Name = "FrameworkUser.Email")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        [RegularExpression("^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "Validate.{0}formaterror")]
        public string Email { get; set; }

        [Display(Name = "Sys.Gender")]
        public GenderEnum? Gender { get; set; }

        [Display(Name = "FrameworkUser.CellPhone")]
        [RegularExpression("^[1][34578][0-9]{9}$", ErrorMessage = "Validate.{0}formaterror")]
        public string CellPhone { get; set; }

        [Display(Name = "FrameworkUser.HomePhone")]
        [StringLength(30, ErrorMessage = "Validate.{0}stringmax{1}")]
        [RegularExpression("^[-0-9\\s]{8,30}$", ErrorMessage = "Validate.{0}formaterror")]
        public string HomePhone { get; set; }

        [Display(Name = "FrameworkUser.Address")]
        [StringLength(200, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Address { get; set; }

        [Display(Name = "FrameworkUser.ZipCode")]
        [RegularExpression("^[0-9]{6,6}$", ErrorMessage = "Validate.{0}formaterror")]
        public string ZipCode { get; set; }
    }
}