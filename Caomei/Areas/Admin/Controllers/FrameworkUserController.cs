using Caomei.Core;
using Caomei.Core.Extensions;
using Caomei.Mvc;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Caomei.Admin.Controllers
{
    [AuthorizeJwtWithCookie]
    public partial class FrameworkUserController : BaseApiController
    {
        [ActionDescription("Sys.Search")]
        [HttpPost("[action]")]
        public IActionResult SearchFrameworkUser(Caomei.ViewModel.Admin.FrameworkUserVMs.FrameworkUserSearcher searcher)
        {
            if (ModelState.IsValid)
            {
                var vm = Wtm.CreateVM<Caomei.ViewModel.Admin.FrameworkUserVMs.FrameworkUserListVM>();
                vm.Searcher = searcher;
                return Content(vm.GetJson(enumToString: false));
            }
            else
            {
                return BadRequest(ModelState.GetErrorJson());
            }
        }

        [ActionDescription("Sys.Export")]
        [HttpPost("[action]")]
        public IActionResult FrameworkUserExportExcel(Caomei.ViewModel.Admin.FrameworkUserVMs.FrameworkUserSearcher searcher)
        {
            var vm = Wtm.CreateVM<Caomei.ViewModel.Admin.FrameworkUserVMs.FrameworkUserListVM>();
            vm.Searcher = searcher;
            vm.SearcherMode = ListVMSearchModeEnum.Export;
            return vm.GetExportData();
        }

        [ActionDescription("Sys.CheckExport")]
        [HttpPost("[action]")]
        public IActionResult FrameworkUserExportExcelByIds(string[] ids)
        {
            var vm = Wtm.CreateVM<Caomei.ViewModel.Admin.FrameworkUserVMs.FrameworkUserListVM>();
            if (ids != null && ids.Count() > 0)
            {
                vm.Ids = new List<string>(ids);
                vm.SearcherMode = ListVMSearchModeEnum.CheckExport;
            }
            return vm.GetExportData();
        }
    }
}