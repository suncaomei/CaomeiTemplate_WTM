using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Caomei.Core
{
    /// <summary>
    /// FrameworkUser
    /// </summary>
    [Table("FrameworkUsers")]
    public abstract class FrameworkUserBase : BasePoco
    {
        [Display(Name = "FrameworkUser.ITCode")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string ITCode { get; set; }

        [Display(Name = "Sys.Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Validate.{0}required")]
        [StringLength(32, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Password { get; set; }

        [Display(Name = "FrameworkUser.Name")]
        [Required(ErrorMessage = "Validate.{0}required")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Name { get; set; }

        [Display(Name = "Sys.IsValid")]
        public bool IsValid { get; set; }

        [Display(Name = "FrameworkUser.Photo")]
        public Guid? PhotoId { get; set; }

        [Display(Name = "FrameworkUser.Photo")]
        [JsonIgnore]
        public FileAttachment Photo { get; set; }

        [Display(Name = "Sys.Tenant")]
        public string TenantCode { get; set; }
    }
}