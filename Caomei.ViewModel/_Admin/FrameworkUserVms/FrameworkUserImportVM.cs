using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace Caomei.ViewModel.Admin.FrameworkUserVMs
{
    public partial class FrameworkUserTemplateVM : BaseTemplateVM
    {
        [Display(Name = "FrameworkUser.Email")]
        public ExcelPropety Email_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.Email);

        [Display(Name = "Sys.Gender")]
        public ExcelPropety Gender_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.Gender);

        [Display(Name = "Sys.Mobile")]
        public ExcelPropety CellPhone_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.CellPhone);

        [Display(Name = "FrameworkUser.HomePhone")]
        public ExcelPropety HomePhone_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.HomePhone);

        [Display(Name = "FrameworkUser.Address")]
        public ExcelPropety Address_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.Address);

        [Display(Name = "FrameworkUser.ZipCode")]
        public ExcelPropety ZipCode_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.ZipCode);

        [Display(Name = "FrameworkUser.ITCode")]
        public ExcelPropety ITCode_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.ITCode);

        [Display(Name = "Sys.Password")]
        public ExcelPropety Password_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.Password);

        [Display(Name = "FrameworkUser.Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.Name);

        [Display(Name = "Sys.IsValid")]
        public ExcelPropety IsValid_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.IsValid);

        [Display(Name = "Sys.CreateTime")]
        public ExcelPropety CreateTime_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.CreateTime, true);

        [Display(Name = "Sys.UpdateTime")]
        public ExcelPropety UpdateTime_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.UpdateTime, true);

        [Display(Name = "Sys.CreateBy")]
        public ExcelPropety CreateBy_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.CreateBy);

        [Display(Name = "Sys.UpdateBy")]
        public ExcelPropety UpdateBy_Excel = ExcelPropety.CreateProperty<FrameworkUser>(x => x.UpdateBy);

        protected override void InitVM()
        {
        }
    }

    public class FrameworkUserImportVM : BaseImportVM<FrameworkUserTemplateVM, FrameworkUser>
    {
        //import
    }
}